using ECO.Application.DTOs.Others;
using ECO.Application.DTOs.Products;
using ECO.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IProductService : IBaseService<ProductResponseDTO, ProductRequestDTO, int>
    {
        public Task<EntityFilterDTO<ProductResponseDTO>> GetAllProductFilter(ProductFilterDTO productFilterDTO);
    }
}
