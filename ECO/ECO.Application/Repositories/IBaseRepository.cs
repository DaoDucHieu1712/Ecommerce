using ECO.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories
{
    public interface IBaseRepository<TKey, TEntity> where TEntity : class
    {
        public Task<TEntity> CreateAsync(TEntity entity);
        public Task<List<TEntity>> GetAllAsync();
        public Task<TEntity> FindAsync(TKey id);
        public Task<int> DeleteAsync(TKey id);
        public Task<int> UpdateAsync(TEntity entity);
        public DataResult<TEntity> GetPaging(DataRequest request);
    }
}
