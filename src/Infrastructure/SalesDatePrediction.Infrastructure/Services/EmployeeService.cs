using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Infrastructure.Contexts;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly StoreDBContext _context;

        public EmployeeService(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<Result<List<EmployeeResponse>>> GetEmployeeListAsync()
        {
            var employeeList = await _context.Employees.Select(x => new EmployeeResponse
            {
                Empid = x.Empid,
                FullName = $"{x.Firstname} {x.Lastname}"
            }).ToListAsync();
            return await Result<List<EmployeeResponse>>.SuccessAsync(employeeList);
        }
    }
}
