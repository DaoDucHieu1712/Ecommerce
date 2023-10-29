using ECO.Application.Repositories;
using ECO.Application.Services;
using ECO.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class BaseService<TKey, TEntity> : IBaseService<TKey, TEntity> where TEntity : class
    {
        private IBaseRepository<TKey, TEntity> _baseRepository;

        public BaseService(IBaseRepository<TKey, TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            return _baseRepository.CreateAsync(entity);
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            return _baseRepository.UpdateAsync(entity);
        }

        public Task<int> DeleteAsync(TKey id)
        {
            return _baseRepository.DeleteAsync(id);
        }

        public Task<TEntity> FindAsync(TKey id)
        {
            return _baseRepository.FindAsync(id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _baseRepository.GetAllAsync();
        }

        public DataResult<TEntity> GetPaging(DataRequest request)
        {
            return _baseRepository.GetPaging(request);
        }
    }
}
