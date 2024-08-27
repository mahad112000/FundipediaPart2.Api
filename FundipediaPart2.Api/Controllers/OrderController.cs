using FundipediaPart2.Domain;
using FundipediaPart2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FundipediaPart2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;        
        }
        // POST: api/Order
        [HttpPost]
        public async Task<ActionResult<OrderStatus>> PostOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Order can't be null");

            return await _orderService.ProcessOrder(order);
        }
    }
}
