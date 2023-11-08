using AutoMapper;
using ECO.Application.DTOs.Products;
using ECO.Application.Repositories;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductRequestDTO entity)
        {
           await _productRepository.Add(_mapper.Map<Product>(entity));
        }

        public async Task<ProductResponseDTO> FindById(int id)
        {
            return _mapper.Map<ProductResponseDTO>(await _productRepository.FindSingle(x => x.Id == id, x => x.Category, x => x.Inventories));
        }

        public async Task<List<ProductResponseDTO>> GetAll()
        {
            return _mapper.Map<List<ProductResponseDTO>>(await _productRepository.FindAll(x => x.Category, x => x.Inventories).ToListAsync());
        }

        public DataResult<ProductResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            await _productRepository.RemoveSoft(id);
        }

        public async Task Update(ProductRequestDTO entity)
        {
            await _productRepository.Update(_mapper.Map<Product>(entity));
        }
    }
}
