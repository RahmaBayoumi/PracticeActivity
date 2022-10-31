using DomainLayer.Entities;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;

namespace ServiceLayer.CustomServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Delete(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    _categoryRepository.Delete(entity);
                    _categoryRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Category Get(int Id)
        {
            try
            {
                var obj = _categoryRepository.Get(Id);
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

        public IEnumerable<Category> GetAll()
        {
            try
            {
                var obj = _categoryRepository.GetAll();
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

        public void Insert(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    _categoryRepository.Insert(entity);
                    _categoryRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    _categoryRepository.Remove(entity);
                    _categoryRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(Category entity)
        {
            try
            {
                if (entity != null)
                {
                    _categoryRepository.Update(entity);
                    _categoryRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
