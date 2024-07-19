using AzureApi.Contexts;
using AzureApi.Interfaces;
using AzureApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureApi.Repositories
{
    public class ProductRepository(ProductsContext _productDBContext) : IRepository<int, Product>
    {


        public async Task<Product> Add(Product obj)
        {
            try
            {
                _productDBContext.Products.Add(obj);
                await _productDBContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new InvalidOperationException("Could not add the product.", ex);
            }
        }

        public async Task<Product> DeleteAsync(int key)
        {
            try
            {
                var product = await _productDBContext.Products.FindAsync(key);
                if (product == null)
                {
                    throw new ProductNotFoundException(key);
                }
                _productDBContext.Products.Remove(product);
                await _productDBContext.SaveChangesAsync();
                return product;
            }
            catch (ProductNotFoundException)
            {
                throw; // Propagate custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new InvalidOperationException("Could not delete the product.", ex);
            }
        }

        public async Task<Product> GetAsync(int key)
        {
            try
            {
                var product = await _productDBContext.Products.FindAsync(key);
                if (product == null)
                {
                    throw new ProductNotFoundException(key);
                }
                return product;
            }
            catch (ProductNotFoundException)
            {
                throw; // Propagate custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new InvalidOperationException("Could not retrieve the product.", ex);
            }
        }

        public async Task<List<Product>> GetAsync()
        {
            try
            {
                var products = await _productDBContext.Products.ToListAsync();

                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> Update(Product obj)
        {
            try
            {
                var existingProduct = await _productDBContext.Products.FindAsync(obj.Id);
                if (existingProduct == null)
                {
                    throw new ProductNotFoundException(obj.Id);
                }
                _productDBContext.Entry(existingProduct).CurrentValues.SetValues(obj);
                await _productDBContext.SaveChangesAsync();
                return existingProduct;
            }
            catch (ProductNotFoundException)
            {
                throw; // Propagate custom exception
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new InvalidOperationException("Could not update the product.", ex);
            }
        }
    }
}
