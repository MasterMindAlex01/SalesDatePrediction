
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<Result<List<EmployeeResponse>>> GetEmployeeListAsync();
    }
}
