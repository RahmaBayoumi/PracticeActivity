using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
   public interface  IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetAllByCategoryId(int categoryId);
        void AddProduct(int categoryId, Product product);
        Product GetByCategoryIdAndProductId(int categoryId,int productId);
        IEnumerable<Product> GetAllWithCategory();

        Product GetProductWithCategory(int productId);
    }
}
