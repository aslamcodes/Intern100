using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.NET.Exceptions;
using Pizza.NET.Models;
using Pizza.NET.Services.Interfaces;


namespace Pizza.NET.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService, ILogger<OrderController> logger) : ControllerBase
    {
        [Authorize(Policy = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Models.DTO.OrderDTO>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IEnumerable<Models.DTO.OrderDTO>>> GetAllOrders()
        {
            try
            {
                var orders = await orderService.GetAllOrders();

                return Ok(orders);
            }
            catch (Exception e)
            {
                logger.LogError("Error while trying to get all orders: " + e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.DTO.OrderDTO), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Models.DTO.OrderDTO>> GetOrderById(int id)
        {
            try
            {
                var order = await orderService.GetOrderById(id);

                return Ok(order);
            }
            catch (OrderNotFoundException e)
            {
                logger.LogError("Error while trying to get order by id: " + e.Message);
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (Exception e)
            {
                logger.LogError("Error while trying to get order by id: " + e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("{userId}/{pizzaId}")]
        [ProducesResponseType(typeof(Models.DTO.OrderDTO), StatusCodes.Status201Created)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Models.DTO.OrderDTO>> MakeOrder(int userId, int pizzaId)
        {
            try
            {
                var order = await orderService.MakeOrder(userId, pizzaId);

                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
            }
            catch (NoPizzaStockFoundException e)
            {
                logger.LogError("Error while trying to make an order: " + e.Message);
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (NoPizzaStockException e)
            {
                logger.LogError("Error while trying to make an order: " + e.Message);
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (CannotCreateOrderException e)
            {
                logger.LogError("Error while trying to make an order: " + e.Message);
                return Conflict(new ErrorModel(e.Message, StatusCodes.Status409Conflict));
            }
            catch (Exception e)
            {
                logger.LogError("Error while trying to make an order." + e.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Models.DTO.OrderDTO), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Models.DTO.OrderDTO>> CancelOrder(int id)
        {
            try
            {
                await orderService.CancelOrder(id);

                return Ok();
            }
            catch (OrderNotFoundException e)
            {
                logger.LogError("Error while trying to cancel an order: " + e.Message);
                return NotFound(new ErrorModel(e.Message, StatusCodes.Status404NotFound));
            }
            catch (CannotUpdateOrderException cuoe)
            {
                logger.LogError("Error while trying to cancel an order: " + cuoe.Message);
                return Conflict(new ErrorModel(cuoe.Message, StatusCodes.Status409Conflict));
            }
            catch (Exception e)
            {
                logger.LogError("Error while trying to cancel an order." + e.Message);
                return StatusCode(500);
            }
        }
    }
}

