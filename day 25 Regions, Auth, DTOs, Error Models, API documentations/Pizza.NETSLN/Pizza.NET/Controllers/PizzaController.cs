using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Models.DTO;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController(IPizzaService pizzaService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Models.DTO.PizzaDto>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IEnumerable<Models.DTO.PizzaDto>>> GetAllPizzas()
        {
            try
            {
                var pizzas = (await pizzaService.GetAllPizzas()).Select(pizza => pizza.ToPizzaDTO());

                return Ok(pizzas);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.DTO.PizzaDto), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Models.DTO.PizzaDto>> GetPizzaById(int id)
        {
            try
            {
                var pizza = await pizzaService.GetPizzaById(id);

                return Ok(pizza.ToPizzaDTO());
            }
            catch (NoPizzaFoundException e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet("{id}/stock")]
        [ProducesResponseType(typeof(PizzaStockDto), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<PizzaStockDto>> GetPizzaStock(int id)
        {
            try
            {
                var stock = await pizzaService.GetPizzaStock(id);

                return Ok(stock.ToPizzaStockDTO());
            }
            catch (NoPizzaStockFoundException e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (NoPizzaFoundException e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
