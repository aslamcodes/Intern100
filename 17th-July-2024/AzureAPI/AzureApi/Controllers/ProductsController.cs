using AzureApi.Interfaces;
using AzureApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                var products = await productService.GetProducts();

                return products;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
