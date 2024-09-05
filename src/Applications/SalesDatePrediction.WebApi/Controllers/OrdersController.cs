using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Requests;

namespace SalesDatePrediction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet("GetOrderListByCustId")]
        public async Task<ActionResult> GetOrderListByCustId([FromQuery] OrderQueryFilterRequest filterRquest)
        {
            var result = await _orderService.GetOrderPagedListByCustIdAsync(filterRquest);
            return Ok(result);
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
        {
            var result = await _orderService.CreateOrderAsync(orderRequest);
            return Ok(result);
        }
    }
}
