using AutoMapper;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;
using ShoppingCatalog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCatalog.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService ??
                throw new ArgumentNullException(nameof(productService));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts([FromQuery] int categoryId)
        {

            if (categoryId == 0)
                return Ok(_mapper.Map<IEnumerable<ProductDto>>(_productService.GetAllWithCategory()));
            else
                return Ok(_mapper.Map<IEnumerable<ProductDto>>(_productService.GetAllByCategoryId(categoryId)));
        }



        [HttpGet("{productId}",Name = "GetProduct")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            var product = _productService.GetProductWithCategory(productId);
            if (product == null)
                return NotFound();
            return Ok(_mapper.Map<ProductDto>(product));

        }


        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductForCreationDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            _productService.Insert(productEntity);
           
            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return CreatedAtRoute("GetProduct",
                new { productId = productToReturn.Id },
                productToReturn);
        }

        [HttpPut("{productId}")]
        public ActionResult UpdateProduct(int productId,  ProductForUpdateDto product)
        {
          

            var productFromRepo = _productService.Get(productId);

            if (productFromRepo == null)
            {
                var prodcutToAdd = _mapper.Map<Product>(product);
                prodcutToAdd.Id = productId;

                _productService.AddProduct(product.CategoryId, prodcutToAdd);


                var productToReturn = _mapper.Map<ProductDto>(prodcutToAdd);

                return CreatedAtRoute("GetProductForCategory",
                    new { productId= productToReturn.Id,categoryId= productToReturn.Category.Id },
                    productToReturn);
            }

     
            _mapper.Map(product ,productFromRepo);

            _productService.Update(productFromRepo);
            return NoContent();
        }
    }
}
