using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Models.DTO;
using Pizza.NET.Repositories;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Services
{
    public class OrderService(IRepository<int, Models.Order> orderRepository, IRepository<int, PizzaStock> pizzaStockRepository, ILogger<OrderService> logger) : IOrderService
    {
        public async Task CancelOrder(int orderId)
        {

            try
            {
                var order = await orderRepository.GetByKey(orderId);

                order.Status = OrderStatusEnum.Cancelled;

                logger.LogInformation($"Order {orderId} has been cancelled.");

                await orderRepository.Update(order);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            try
            {
                var orders = (await orderRepository.GetAll()).Select(order => order.ToOrderDTO());


                logger.LogInformation("All orders have been retrieved.");
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            try
            {
                var order = await orderRepository.GetByKey(id);

                logger.LogInformation($"Order {id} has been retrieved.");
                return order.ToOrderDTO();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<OrderDTO> MakeOrder(int userId, int pizzaId)
        {
            try
            {
                var pizzaStock = await pizzaStockRepository.GetByKey(pizzaId);

                if (pizzaStock.Stock == 0)
                {
                    throw new NoPizzaStockException();
                }

                var newOrder = new Order() { UserId = userId, PizzaId = pizzaId };


                var order = await orderRepository.Add(newOrder);

                pizzaStock.Stock--;

                await pizzaStockRepository.Update(pizzaStock);

                logger.LogInformation($"Order {order.Id} has been created.");
                return order.ToOrderDTO();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
