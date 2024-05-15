using Pizza.NET.Models;
using Pizza.NET.Repositories;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Services
{
    public class OrderService(IRepository<int, Models.Order> orderRepository, IRepository<int, PizzaStock> pizzaStockRepository) : IOrderService
    {
        public async Task CencelOrder(int orderId)
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

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                var orders = await orderRepository.GetAll();

                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                var order = await orderRepository.GetByKey(id);

                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> MakeOrder(int userId, int pizzaId)
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

                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
