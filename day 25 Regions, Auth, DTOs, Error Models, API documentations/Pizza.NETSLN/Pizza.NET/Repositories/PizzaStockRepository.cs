using Microsoft.EntityFrameworkCore;
using Pizza.NET.Contexts;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;

namespace Pizza.NET.Repositories
{
    public class PizzaStockRepository(PizzaChainContext context) : IRepository<int, Models.PizzaStock>
    {
        public async Task<PizzaStock> Add(PizzaStock entity)
        {
            try
            {
                context.PizzaStocks.Add(entity);

                int rows = await context.SaveChangesAsync();

                if (rows == 0)
                {
                    throw new FailedToAddPizzaStockException();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<PizzaStock> Delete(int key)
        {
            try
            {
                var pizzaStock = await GetByKey(key);

                context.PizzaStocks.Remove(pizzaStock);

                int rows = await context.SaveChangesAsync();

                if (rows == 0)
                {
                    throw new FailedToDeletePizzaStockException();
                }

                return pizzaStock;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<PizzaStock>> GetAll()
        {
            try
            {
                var pizzaStocks = await context.PizzaStocks.ToListAsync();

                return pizzaStocks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PizzaStock> GetByKey(int key)
        {
            try
            {
                var pizzaStock = await context.PizzaStocks.FirstOrDefaultAsync(p => p.Id == key);

                return pizzaStock ?? throw new NoPizzaStockFoundException();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PizzaStock> Update(PizzaStock entity)
        {
            try
            {
                context.PizzaStocks.Update(entity);

                int rows = await context.SaveChangesAsync();

                if (rows == 0)
                {
                    throw new FailedToUpdatePizzaStockException();
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
