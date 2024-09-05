using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces.Services;

namespace SalesDatePrediction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProductList")]
        public async Task<ActionResult> GetAllProductList()
        {
            var result = await _productService.GetAllProductListAsync();
            return Ok(result);
        }
    }
}
