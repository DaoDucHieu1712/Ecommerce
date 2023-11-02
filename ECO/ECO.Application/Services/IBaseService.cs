using ECO.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IBaseService<TEntityResponseDTO, TEntityRequestDTO, Tkey> where TEntityResponseDTO : class where TEntityRequestDTO : class
    {
        Task<List<TEntityResponseDTO>> GetAll();
        Task<TEntityResponseDTO> FindById(Tkey id);
        Task Add(TEntityRequestDTO entity);
        Task Update(TEntityRequestDTO entity);
        Task Remove(Tkey id);
        DataResult<TEntityResponseDTO> GetPaging(DataRequest req);
    }
}
