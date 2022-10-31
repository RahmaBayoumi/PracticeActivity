using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ShoppingCatalog.API.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingCatalogDbContext dbContext) : base(dbContext)
        { }


        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            var result = from p in Context.Product.Where(x => x.CategoryId == categoryId)
                         select p;
            return result;

        }


        public void AddProduct(int categoryId, Product product)
        {
            if (categoryId == 0)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            product.CategoryId = categoryId;
            Context.Product.Add(product);
            Context.SaveChanges();
        }

        public Product GetByCategoryIdAndProductId(int categoryId, int productId)
        {
            var result = from p in Context.Product.Where(x => x.CategoryId == categoryId && x.Id == productId)
                         select p;
            return result.FirstOrDefault();
        }

        public IEnumerable<Product> GetAllWithCategory()
        {
            return Context.Product.Include(p => p.Category);
        }

        public Product GetProductWithCategory(int productId)
        {
            return Context.Product.Where(x=>x.Id== productId).Include(p => p.Category).FirstOrDefault();
        }
    }
}
