using ECO.Application.Repositories;
using ECO.DataTable;
using ECO.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Repositories
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly ECOContext _context;
        public ECOContext DbContext { get => _context; }
        public BaseRepository(ECOContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(TKey id)
        {
            var entity = await _context.FindAsync<TEntity>(new object[] { id });
            if (entity == null)
            {
                _context.Remove<TEntity>(entity);
                await _context.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<TEntity> FindAsync(TKey id)
        {
            return await _context.FindAsync<TEntity>(new object[] { id });
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public DataResult<TEntity> GetPaging(DataRequest request)
        {
            return _context.Set<TEntity>().ToDataResult(request);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
