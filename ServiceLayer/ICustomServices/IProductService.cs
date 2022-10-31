using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ICustomServices
{
    public interface IProductService: ICustomServices<Product>
    {
        public IEnumerable<Product> GetAllByCategoryId(int categoryId);
        public void AddProduct(int categoryId, Product product);
        public Product GetProduct(int categoryId, int productId);
        public IEnumerable<Product> GetAllWithCategory();
        public Product GetProductWithCategory(int productId);
    }

}
