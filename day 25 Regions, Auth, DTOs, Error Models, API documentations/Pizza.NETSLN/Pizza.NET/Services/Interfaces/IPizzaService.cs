

using Pizza.NET.Models;

namespace Pizza.NET.Services.Interfaces
{
    public interface IPizzaService
    {
        Task<Models.Pizza> GetPizzaById(int id);

        Task<IEnumerable<Models.Pizza>> GetAllPizzas();

        Task<PizzaStock> GetPizzaStock(int pizzaId);

    }
}
