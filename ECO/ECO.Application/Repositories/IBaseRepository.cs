using ECO.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories
{
    public interface IBaseRepository<T, K> where T : class

    {
        Task<T> FindById(K id, Expression<Func<T, object>>[] includes);

        Task<T> FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<List<T>> GetList(params Expression<Func<T, object>>[] includes);

        Task<List<T>> GetList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task Add(T entity);

        Task<T> CreateAndGetEntity(T entity);

        Task AddMultiple(List<T> entities);

        Task Update(T entity, params string[] propertiesToExclude);

        Task Update(T entity);

        Task Remove(T entity);

        Task Remove(K id);

        Task RemoveMultiple(List<T> entities);

        Task RemoveSoft(K id);

        Task RemoveSoftMultiple(List<T> entities);

        public DataResult<T> GetPaging(DataRequest request);
    }
}
