using CSharpSqlDataBaseAssignment.Entities;
using CSharpSqlDataBaseAssignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSqlDataBaseAssignment.Services
{
    internal class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryService _categoryService;

        public ProductService(ProductRepository productRepository, CategoryService categoryService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
        }


        public ProductEntity? CreateProduct(string title, decimal price, string categoryName)
        {

            var categoryEntity = _categoryService.CreateCategory(categoryName);

            try
            {
                var productEntity = new ProductEntity
                {
                    Title = title,
                    Price = price,
                    CategoryId = categoryEntity.Id
                };

                productEntity = _productRepository.Create(productEntity);
                return productEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in CreateProduct: {ex.Message}");
                return null;
            }
        }

        public ProductEntity? GetProductById(int id)
        {
            try
            {
                var productEntity = _productRepository.Get(x => x.Id == id);
                return productEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetProductById: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<ProductEntity>? GetProducts()
        {
            try
            {
                var products = _productRepository.GetAll();
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in GetProducts: {ex.Message}");
                return null;
            }
        }

        public ProductEntity? UpdateProduct(ProductEntity productEntity)
        {
            try
            {
                var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
                return updatedProductEntity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in UpdateProduct: {ex.Message}");
                return null;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _productRepository.Delete(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured in DeleteProduct: {ex.Message}");
            }
        }


    }
}
