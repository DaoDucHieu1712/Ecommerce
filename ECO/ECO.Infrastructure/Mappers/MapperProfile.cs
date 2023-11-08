using AutoMapper;
using ECO.Application.DTOs.Category;
using ECO.Application.DTOs.Color;
using ECO.Application.DTOs.Discount;
using ECO.Application.DTOs.Inventory;
using ECO.Application.DTOs.Products;
using ECO.Application.DTOs.Rating;
using ECO.Application.DTOs.Size;
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

            CategoryMapper();
            ProductMapper();
            ColorMapper();
            SizeMapper();
            InventoryMapper();
            DiscountMapper();
            RatingMapper();
        }

        public void CategoryMapper()
        {
            CreateMap<Category, CategoryResponseDTO>().ReverseMap();
            CreateMap<Category, CategoryRequestDTO>().ReverseMap();
        }

        public void ProductMapper()
        {
            CreateMap<Product, ProductResponseDTO>()
                .ForMember(x => x.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(x => x.Quantity,
                opt => opt.MapFrom(src => src.Inventories.Sum(x => x.Quantity)))
                .ReverseMap();
            CreateMap<Product, ProductRequestDTO>().ReverseMap();
        }

        public void ColorMapper()
        {
            CreateMap<Color, ColorResponseDTO>().ReverseMap();
            CreateMap<Color, ColorRequestDTO>().ReverseMap();
        }

        public void SizeMapper()
        {
            CreateMap<Size, SizeResponseDTO>().ReverseMap();
            CreateMap<Size, SizeRequestDTO>().ReverseMap();
        }

        public void InventoryMapper()
        {
            CreateMap<Inventory, InventoryResponseDTO>()
                .ForMember(x => x.InventoryName,
                opt => opt.MapFrom(src => src.Size.SizeName + "-" + src.Color.ColorName))
                .ForMember(x => x.ProductName, 
                opt => opt.MapFrom(src => src.Product.Name))
                 .ForMember(x => x.SizeName,
                opt => opt.MapFrom(src => src.Size.SizeName))
                  .ForMember(x => x.ColorName,
                opt => opt.MapFrom(src => src.Color.ColorName))
                .ReverseMap();
            CreateMap<Inventory, InventoryRequestDTO>().ReverseMap();
        }

        public void DiscountMapper()
        {
            CreateMap<Discount, DiscountResponseDTO>().ReverseMap();
            CreateMap<Discount, DiscountRequestDTO>().ReverseMap();
        }

        public void RatingMapper()
        {
            CreateMap<Rating, RatingResponseDTO>().ReverseMap();
            CreateMap<Rating, RatingRequestDTO>().ReverseMap();
        }
    }
}
