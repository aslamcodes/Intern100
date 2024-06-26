﻿using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Repositories;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Services
{
    public class PizzaService(IRepository<int, Models.Pizza> pizzaRepository, IRepository<int, Models.PizzaStock> pizzaStockRepository, ILogger<PizzaService> logger) : IPizzaService
    {
        public async Task<IEnumerable<Models.Pizza>> GetAllPizzas()
        {
            try
            {
                var pizzas = await pizzaRepository.GetAll();

                logger.LogInformation("All pizzas have been retrieved.");
                return pizzas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Models.Pizza> GetPizzaById(int id)
        {
            try
            {
                var pizza = await pizzaRepository.GetByKey(id);

                logger.LogInformation($"Pizza {id} has been retrieved.");
                return pizza;
            }

            catch (Exception)
            {

                throw;
            }
        }


        public async Task<PizzaStock> GetPizzaStock(int pizzaId)
        {
            try
            {
                var pizzaStock = (await pizzaStockRepository.GetAll()).Where(ps => ps.PizzaId == pizzaId);

                if (!pizzaStock.Any())
                {
                    throw new NoPizzaStockFoundException();
                }

                logger.LogInformation($"Stock for pizza {pizzaId} has been retrieved.");
                return pizzaStock.First();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
