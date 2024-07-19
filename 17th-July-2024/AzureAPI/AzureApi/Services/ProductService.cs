using AzureApi.Interfaces;
using AzureApi.Models;

namespace AzureApi.Services
{
    public class ProductService(IRepository<int, Product> productRepository) : IProductService
    {
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                return await productRepository.GetAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
