using ECO.Application.Repositories;
using ECO.DataTable;
using ECO.Domain.Common;
using ECO.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Repositories
{
    public class BaseRepository<T, K> : IBaseRepository<T, K> where T : BaseEntity<K>
    {
        protected readonly ECOContext _context;

        public BaseRepository(ECOContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetList(params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return await items.Include(x => x.IsDeleted == false).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {

            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return await items.Include(x => x.IsDeleted == false).Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<T> FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return await items.FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                var rs = await items.SingleOrDefaultAsync(predicate);
                return rs;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Remove(K id)
        {
            try
            {
                var entity = await FindById(id);
                await Remove(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveMultiple(List<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T entity, params string[] propertiesToExclude)
        {
            try
            {
                _context.Set<T>().Attach(entity);
                var entry = _context.Entry(entity);
                entry.State = EntityState.Modified;
                foreach (var property in propertiesToExclude)
                {
                    entry.Property(property).IsModified = false;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>().Where(x => x.IsDeleted == false);
                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return items;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>().Where(x => x.IsDeleted == false);
                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        items = items.Include(includeProperty);
                    }
                }
                return items.Where(predicate);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task AddMultiple(List<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> CreateAndGetEntity(T entity)
        {
            try
            {
                IQueryable<T> items = _context.Set<T>();
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return await items.FirstOrDefaultAsync(x => x.Id.Equals(entity.Id));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveSoft(K id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
            entity.IsDeleted = true;
            await Update(entity, "CreatedAt");
        }

        public async Task RemoveSoftMultiple(List<T> entities)
        {
            foreach (var item in entities)
            {
                var entity = await FindSingle(x => x.Id.Equals(item.Id));
                entity.IsDeleted = true;
                await Update(entity, "CreatedAt");
            }
        }
        
        public DataResult<T> GetPaging(DataRequest request)
        {
            return _context.Set<T>().ToDataResult(request);
        }
        
    }
}
