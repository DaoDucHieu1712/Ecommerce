using AutoMapper;
using ECO.Application.DTOs.Category;
using ECO.Application.DTOs.Product;
using ECO.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {

            #region category
            CreateMap<Category, CategoryResponseDTO>().ReverseMap();
            CreateMap<Category, CategoryRequestDTO>().ReverseMap();
            #endregion

            #region product
            CreateMap<Product, ProductResponseDTO>()
                .ForMember(x => x.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
            CreateMap<Product, ProductRequestDTO>().ReverseMap();
            #endregion
        }
    }
}
