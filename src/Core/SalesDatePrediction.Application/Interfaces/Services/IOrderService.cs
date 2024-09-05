
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Result<List<OrderResponse>>> GetOrderListByCustIdAsync(int custId);
    }
}
