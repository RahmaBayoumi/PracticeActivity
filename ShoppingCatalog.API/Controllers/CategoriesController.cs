using AutoMapper;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;
using ShoppingCatalog.API.Models;
using System;
using System.Collections.Generic;

namespace ShoppingCatalog.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService ??
                throw new ArgumentNullException(nameof(categoryService));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesLst = _categoryService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoriesLst));
        }


        [HttpGet("{categoryId}",Name = "GetCategory")]
        public ActionResult<CategoryDto> GetCategory(int categoryId)
        {
            var category = _categoryService.Get(categoryId);
            if (category == null)
                return NotFound();
            return Ok(_mapper.Map<CategoryDto>(category));

        }

        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _categoryService.Insert(categoryEntity);

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return CreatedAtRoute("GetCategory",
                new { categoryId = categoryToReturn.Id }, categoryToReturn
                );
        }

    }
}
