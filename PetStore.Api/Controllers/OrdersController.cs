using Microsoft.AspNetCore.Mvc;
using PetStore.Business.Services;
using PetStore.Data.Dtos.Order;

namespace PetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound(new { message = "Cannot find order" });

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] int? page, [FromQuery] int? take)
        {
            if (page.HasValue && take.HasValue)
            {
                var pagedOrders = await orderService.GetOrdersAsync(page.Value, take.Value);
                return Ok(pagedOrders);
            }

            var orders = await orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(CreateOrderDto createOrderDto)
        {
            var order = await orderService.CreateOrderAsync(createOrderDto);
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var order = await orderService.UpdateOrderAsync(id, updateOrderDto);
            return Ok(new { Message = "Order updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await orderService.DeleteOrderAsync(id);
            return Ok(new { Message = "Order deleted successfully" });
        }
    }
}
