
namespace Pizza.NET.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Models.Order> MakeOrder(int userId, int pizzaId);

        Task<IEnumerable<Models.Order>> GetAllOrders();

        Task<Models.Order> GetOrderById(int id);

        Task CencelOrder(int orderId);


    }
}
