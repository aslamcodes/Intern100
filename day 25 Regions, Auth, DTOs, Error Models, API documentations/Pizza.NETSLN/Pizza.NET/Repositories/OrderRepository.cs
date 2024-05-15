using Microsoft.EntityFrameworkCore;
using Pizza.NET.Contexts;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;

namespace Pizza.NET.Repositories
{
    public class OrderRepository(PizzaChainContext context) : IRepository<int, Models.Order>
    {
        public async Task<Order> Add(Order entity)
        {
            try
            {
                context.Orders.Add(entity);

                int rows = await context.SaveChangesAsync();

                if (rows == 0)
                {
                    throw new CannotCreateOrderException();
                }

                return entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> Delete(int key)
        {
            try
            {
                var order = await GetByKey(key);

                context.Orders.Remove(order);

                int rows = await context.SaveChangesAsync();

                if (rows == 0)
                {
                    throw new CannotDeleteOrderException();
                }

                return order;
            }

            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            try
            {
                return await context.Orders.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> GetByKey(int key)
        {
            try
            {
                var order = await context.Orders.FindAsync(key);

                if (order == null)
                {
                    throw new OrderNotFoundException();
                }

                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> Update(Order entity)
        {
            try
            {
                context.Orders.Update(entity);

                int rows = await context.SaveChangesAsync();

                if (rows == 0)
                {
                    throw new CannotUpdateOrderException();
                }
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
