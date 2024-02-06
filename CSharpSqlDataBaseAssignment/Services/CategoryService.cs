using CSharpSqlDataBaseAssignment.Entities;
using CSharpSqlDataBaseAssignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSqlDataBaseAssignment.Services
{
    internal class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryEntity? CreateCategory(string categoryName)
        {
            try
            {
                var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
                categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });
                return categoryEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in CreateCategory: {ex.Message}");
                return null;
            }
        }

        public CategoryEntity? GetCategoryByCategoryName(string categoryName)
        {
            try
            {
                var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
                return categoryEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetCategoryByCategoryName: {ex.Message}");
                return null;
            }
        }

        public CategoryEntity? GetCategoryById(int id)
        {
            try
            {
                var categoryEntity = _categoryRepository.Get(x => x.Id == id);
                return categoryEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetCategoryById: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<CategoryEntity>? GetCategories()
        {
            try
            {
                var categories = _categoryRepository.GetAll();
                return categories;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetCategories: {ex.Message}");
                return null;
            }
        }

        public CategoryEntity? UpdateCategory(CategoryEntity categoryEntity)
        {
            try
            {
                var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
                return updatedCategoryEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in UpdateCategory: {ex.Message}");
                return null;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                _categoryRepository.Delete(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in DeleteCategory: {ex.Message}");
            }
        }
    }
}
