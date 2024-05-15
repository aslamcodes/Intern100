using Microsoft.AspNetCore.Mvc;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Services.Interfaces;

namespace Pizza.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Models.Order>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IEnumerable<Models.Order>>> GetAllOrders()
        {
            try
            {
                var orders = await orderService.GetAllOrders();

                return Ok(orders);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.Order), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Models.Order>> GetOrderById(int id)
        {
            try
            {
                var order = await orderService.GetOrderById(id);

                return Ok(order);
            }
            catch (NoOrderFoundException e)
            {
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("{userId}/{pizzaId}")]
        [ProducesResponseType(typeof(Models.Order), StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Models.Order>> MakeOrder(int userId, int pizzaId)
        {
            try
            {
                var order = await orderService.MakeOrder(userId, pizzaId);

                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
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

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Models.Order), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Models.Order>> CancelOrder(int id)
        {
            try
            {
                await orderService.CencelOrder(id);

                return Ok();
            }
            catch (NoOrderFoundException e)
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

