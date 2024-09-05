using SalesDatePrediction.Application.Models.Requests;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<PaginatedResult<CustomerResponse>> GetSaleDatePredictionPagedListAsync(CustomerQueryFilterRequest filterRequest);
    }
}
