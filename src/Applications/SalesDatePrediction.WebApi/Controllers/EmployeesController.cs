using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces.Services;

namespace SalesDatePrediction.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetEmployeeList")]
        public async Task<ActionResult> GetEmployeeList()
        {
            var result = await _employeeService.GetEmployeeListAsync();
            return Ok(result);
        }
    }
}
