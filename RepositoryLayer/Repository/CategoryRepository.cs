using DomainLayer.Entities;
using RepositoryLayer.IRepository;
using ShoppingCatalog.API.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Repository
{
   public class CategoryRepository: Repository<Category>,ICategoryRepository
    {
        public CategoryRepository (ShoppingCatalogDbContext dbContext): base(dbContext)
        { }
    }
}
