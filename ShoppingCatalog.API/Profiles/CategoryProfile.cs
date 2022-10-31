using AutoMapper;
using DomainLayer.Entities;
using ShoppingCatalog.API.Models;

namespace ShoppingCatalog.API.Profiles
{
    public class CategoryProfile:Profile
    {
        
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryForCreationDto>();
            CreateMap<CategoryForCreationDto, Category>();
        }
    }
}
