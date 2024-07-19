using AzureApi.Models;

namespace AzureApi.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}