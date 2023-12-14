using AutoMapper;
using ECO.Application.DTOs.Others;
using ECO.Application.DTOs.Products;
using ECO.Application.DTOs.Response;
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
            //var p = await _productRepository.FindSingle(x => x.Id == id, x => x.Category, x => x.Inventories);
            var p = await _productRepository.FindAll(x => x.Id == id, x=> x.Category)
                .Include(x => x.Inventories).ThenInclude(x => x.Color)
                .Include(x => x.Inventories).ThenInclude(x => x.Size).FirstOrDefaultAsync();
            if (p == null) throw new Exception("Không tìm thấy sản phẩm nào !");
            return _mapper.Map<ProductResponseDTO>(p);
        }

        public async Task<List<ProductResponseDTO>> GetAll()
        {
            return _mapper.Map<List<ProductResponseDTO>>(await _productRepository.FindAll(x => x.Category, x => x.Inventories).ToListAsync());
        }

        public async Task<EntityFilterDTO<ProductResponseDTO>> GetAllProductFilter(ProductFilterDTO productFilterDTO)
        {
            try
            {
                var productQuery = _productRepository.FindAll(x => x.Category, x => x.Inventories);

                if (productFilterDTO.SortType != null)
                {
                    switch (productFilterDTO.SortType)
                    {
                        case "name-asc":
                            productQuery = productQuery.OrderBy(x => x.Name);
                            break;
                        case "name-desc":
                            productQuery = productQuery.OrderByDescending(x => x.Name);
                            break;
                        case "price-asc":
                            productQuery = productQuery.OrderBy(x => x.Price);
                            break;
                        case "price-desc":
                            productQuery = productQuery.OrderByDescending(x => x.Price);
                            break;
                        default:
                            productQuery = productQuery.OrderByDescending(x => x.CreatedAt);
                            break;
                    }
                }

                if(productFilterDTO.Name != null)
                {
                    productQuery = productQuery.Where(x => x.Name.ToLower().Contains(productFilterDTO.Name.ToLower()));
                }

                if(productFilterDTO.ToPrice != null)
                {
                    productQuery = productQuery.Where(x => x.Price >= productFilterDTO.ToPrice);
                }

                if(productFilterDTO.FromPrice != null)
                {
                    productQuery = productQuery.Where(x => x.Price <= productFilterDTO.FromPrice);
                }

                if(productFilterDTO.CategoryId != null)
                {
                    productQuery = productQuery.Where(x => x.CategoryId == productFilterDTO.CategoryId);
                }

                int pageSize = 5;

                PagedList<Product> _productPaged = await PagedList<Product>.ToPagedList(productQuery, productFilterDTO.PageIndex ?? 1, pageSize);

                return new EntityFilterDTO<ProductResponseDTO>() {
                    List = _mapper.Map<List<ProductResponseDTO>>(_productPaged),
                    PageIndex = _productPaged.CurrentPage,
                    TotalPages = _productPaged.TotalPages,
                    TotalCount = _productPaged.TotalCount,
                    HasNext = _productPaged.HasNext,
                    HasPrevious= _productPaged.HasPrevious,
                    PageSize = _productPaged.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataResult<ProductResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> Products()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            await _productRepository.RemoveSoft(id);
        }

        public async Task Update(ProductRequestDTO entity)
        {
            await _productRepository.Update(_mapper.Map<Product>(entity), "CreatedAt");
        }

        public async Task<List<ProductResponseDTO>> GetShop(ProductShopDTO productShopDTO)
        {
            var productQuery = _productRepository.FindAll(x => x.Category, x => x.Inventories);

            if (productShopDTO.SortType != null)
            {
                switch (productShopDTO.SortType)
                {
                    case "name-asc":
                        productQuery = productQuery.OrderBy(x => x.Name);
                        break;
                    case "name-desc":
                        productQuery = productQuery.OrderByDescending(x => x.Name);
                        break;
                    case "price-asc":
                        productQuery = productQuery.OrderBy(x => x.Price);
                        break;
                    case "price-desc":
                        productQuery = productQuery.OrderByDescending(x => x.Price);
                        break;
                    default:
                        productQuery = productQuery.OrderByDescending(x => x.CreatedAt);
                        break;
                }
            }

            if (productShopDTO.Name != null)
            {
                productQuery = productQuery.Where(x => x.Name.ToLower().Contains(productShopDTO.Name.ToLower()));
            }

            if (productShopDTO.ToPrice != null)
            {
                productQuery = productQuery.Where(x => x.Price >= productShopDTO.ToPrice);
            }

            if (productShopDTO.FromPrice != null)
            {
                productQuery = productQuery.Where(x => x.Price <= productShopDTO.FromPrice);
            }

            if (productShopDTO.CategoryId != null)
            {
                productQuery = productQuery.Where(x => x.CategoryId == productShopDTO.CategoryId);
            }

            return _mapper.Map<List<ProductResponseDTO>>(await productQuery.ToListAsync());
        }

        public async Task<List<ProductResponseDTO>> GetProductRecommend(int id)
        {
            var p = await _productRepository.FindSingle(x => x.Id == id);
            if (p == null) throw new Exception("Không tìm thấy sản phẩm !!");
            var list = await _productRepository.FindAll(x => x.CategoryId == p.CategoryId && x.Id != id).OrderBy(x => Guid.NewGuid()).Take(5).ToListAsync();
            return _mapper.Map<List<ProductResponseDTO>>(list);
        }
    }
}
