using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Models.DTO;
using Pizza.NET.Repositories;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Services
{
    public class OrderService(IRepository<int, Models.Order> orderRepository, IRepository<int, PizzaStock> pizzaStockRepository) : IOrderService
    {
        public async Task CancelOrder(int orderId)
        {

            try
            {
                var order = await orderRepository.GetByKey(orderId);

                order.Status = OrderStatusEnum.Cancelled;

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

                return order.ToOrderDTO();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
