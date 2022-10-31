using DomainLayer.Entities;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.CustomServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productsRepository)
        {
            _productRepository = productsRepository;
        }

        public void AddProduct(int categoryId, Product product)
        {
            _productRepository.AddProduct(categoryId,product);
        }

        public void Delete(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Delete(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product Get(int Id)
        {
            try
            {
                var obj = _productRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetAllWithCategory()
        {
            try
            {
                var obj = _productRepository.GetAllWithCategory();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public IEnumerable<Product> GetAll()
        {
            try
            {
                var obj = _productRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetAllByCategoryId(int categoryId)
        {
            try
            {
                var obj = _productRepository.GetAllByCategoryId(categoryId);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProduct(int categoryId, int productId)
        {
            try
            {
                var obj = _productRepository.GetByCategoryIdAndProductId(categoryId,productId);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Insert(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Remove(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(Product entity)
        {
            try
            {
                if (entity != null)
                {
                    _productRepository.Update(entity);
                    _productRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProductWithCategory(int Id)
        {
            try
            {
                var obj = _productRepository.GetProductWithCategory(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
