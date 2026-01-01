using Microsoft.AspNetCore.Mvc;
using OrderAPI.Application.DTOs;
using OrderAPI.Application.Services;

namespace OrderAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;
        public OrderController(OrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult FindAllOrders()
        {
            try
            {
                var orders = _service.FindAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult FindOrderById(int id)
        {
            try
            {
                var order = _service.FindOrderById(id);
                if (order == null) return NotFound($"Order with ID {id} not found");
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDTO orderDto)
        {
            try
            {
                var order = _service.AddOrder(orderDto);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] UpdateOrderDTO orderDto)
        {
            try
            {
                var updatedOrder = _service.UpdateOrder(orderDto, id);
                if (updatedOrder == null) return NotFound($"Order with ID {id} not found");
                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var deleted = _service.DeleteOrder(id);
                if (deleted is null) return NotFound($"Order with ID {id} not found");
                return Ok("Order deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
