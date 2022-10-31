using AutoMapper;
using DomainLayer.Entities;
using ShoppingCatalog.API.Models;

namespace ShoppingCatalog.API.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();
            CreateMap<Product, ProductForUpdateDto>();
        }
    }
}
