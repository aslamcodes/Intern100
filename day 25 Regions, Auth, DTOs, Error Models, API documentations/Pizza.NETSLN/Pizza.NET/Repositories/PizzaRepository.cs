
using Microsoft.EntityFrameworkCore;
using Pizza.NET.Contexts;
using Pizza.NET.Exceptions;

namespace Pizza.NET.Repositories
{
    public class PizzaRepository(PizzaChainContext pizzaContext) : IRepository<int, Models.Pizza>
    {
        /// <summary>
        /// Adds the pizza to the database
        /// </summary>
        /// <param name="entity">The Pizza to be added</param>
        /// <returns>The added pizza</returns>
        /// <exception cref="FailedToAddPizzaException"></exception>
        public async Task<Models.Pizza> Add(Models.Pizza entity)
        {
            try
            {
                pizzaContext.Pizzas.Add(entity);

                int result = await pizzaContext.SaveChangesAsync();

                if (result == 0)
                {
                    throw new FailedToAddPizzaException();
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// Deletes a Pizza from the database by Id
        /// </summary>
        /// <param name="key">Id of Pizza</param>
        /// <exception cref="FailedToDeletePizzaException">Thrown when the Pizza could not be deleted</exception>
        /// <exception cref="NoPizzaFoundException">Thrown when no pizza found for the key</exception>
        /// <returns>The Pizza that is deleted</returns>
        public async Task<Models.Pizza> Delete(int key)
        {
            try
            {
                var pizza = await GetByKey(key);

                pizzaContext.Pizzas.Remove(pizza);

                var result = await pizzaContext.SaveChangesAsync();

                if (result == 0)
                {
                    throw new FailedToDeletePizzaException();
                }

                return pizza;
            }
            catch (FailedToDeletePizzaException)
            {
                throw;
            }
            catch (NoPizzaFoundException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Models.Pizza>> GetAll()
        {
            try
            {
                var pizzas = await pizzaContext.Pizzas.ToListAsync();

                return pizzas;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Gets the pizza by Id
        /// </summary>
        /// <param name="key">Id of Pizza</param>
        /// <exception cref="NoPizzaFoundException">Thrown when no pizza found for the given Id</exception>
        /// <returns>The pizza for given ID</returns>
        public async Task<Models.Pizza> GetByKey(int key)
        {
            try
            {
                var pizza = await pizzaContext.Pizzas.FindAsync(key);

                return pizza ?? throw new NoPizzaFoundException(key);
            }
            catch (NoPizzaFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the pizza in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>The updated pizza</returns>
        /// <exception cref="FailedToUpdatePizzaException""></exception>
        public async Task<Models.Pizza> Update(Models.Pizza entity)
        {
            try
            {
                pizzaContext.Pizzas.Remove(entity);

                var result = await pizzaContext.SaveChangesAsync();

                if (result == 0)
                {
                    throw new FailedToUpdatePizzaException();
                }

                return entity;
            }
            catch (FailedToUpdatePizzaException)
            {

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
