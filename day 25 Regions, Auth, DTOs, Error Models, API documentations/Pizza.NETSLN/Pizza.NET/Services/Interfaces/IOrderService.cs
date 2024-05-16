
namespace Pizza.NET.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Models.DTO.OrderDTO> MakeOrder(int userId, int pizzaId);

        Task<IEnumerable<Models.DTO.OrderDTO>> GetAllOrders();

        Task<Models.DTO.OrderDTO> GetOrderById(int id);

        Task CancelOrder(int orderId);
    }
}
