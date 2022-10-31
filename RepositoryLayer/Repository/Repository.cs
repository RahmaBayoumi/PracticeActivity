using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using ShoppingCatalog.API.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region property
        private readonly DbSet<T> entities;
        #endregion

        #region Constructor
        public Repository(ShoppingCatalogDbContext shoppingCatalogDbContext)
        {
            this.Context = shoppingCatalogDbContext;
            entities = Context.Set<T>();
        }
        #endregion

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            Context.SaveChanges();
        }

        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            Context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
           Context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            Context.SaveChanges();
        }

        protected ShoppingCatalogDbContext Context { get; set; }
    }
}
