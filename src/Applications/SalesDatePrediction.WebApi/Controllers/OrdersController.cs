using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces.Services;

namespace SalesDatePrediction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrderListByCustId")]
        public async Task<ActionResult> GetOrderListByCustId(int custId)
        {
            var result = await _orderService.GetOrderListByCustIdAsync(custId);
            return Ok(result);
        }
    }
}
