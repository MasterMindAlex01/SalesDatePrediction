using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces.Services;

namespace SalesDatePrediction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpGet("GetAllEmployeeList")]
        public async Task<ActionResult> GetAllEmployeeList()
        {
            var result = await _employeeService.GetAllEmployeeListAsync();
            return Ok(result);
        }
    }
}
