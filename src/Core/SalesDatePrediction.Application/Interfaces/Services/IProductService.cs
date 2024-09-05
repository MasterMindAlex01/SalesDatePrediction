using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<Result<List<ProductResponse>>> GetAllProductListAsync();

    }
}
