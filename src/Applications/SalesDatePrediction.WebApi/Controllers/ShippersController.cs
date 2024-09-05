using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces.Services;

namespace SalesDatePrediction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController(IShipperService shipperService) : ControllerBase
    {
        private readonly IShipperService _shipperService = shipperService;

        [HttpGet("GetAllShipperList")]
        public async Task<ActionResult> GetAllShipperList()
        {
            var result = await _shipperService.GetAllShipperListAsync();
            return Ok(result);
        }
    }
}
