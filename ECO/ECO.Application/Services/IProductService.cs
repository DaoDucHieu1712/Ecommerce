using ECO.Application.DTOs.Product;
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
    }
}
