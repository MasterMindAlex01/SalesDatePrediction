
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Application.Interfaces.Services
{
    public interface IShipperService
    {
        Task<Result<List<ShipperResponse>>> GetAllShipperListAsync();
    }
}
