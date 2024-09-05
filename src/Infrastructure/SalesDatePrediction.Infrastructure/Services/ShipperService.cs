using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Infrastructure.Contexts;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Infrastructure.Services
{
    public class ShipperService : IShipperService
    {
        private readonly StoreDBContext _context;

        public ShipperService(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<Result<List<ShipperResponse>>> GetAllShipperListAsync()
        {
            var shipperList = await _context.Shippers.Select(x => new ShipperResponse
            {
                ShipperId = x.Shipperid,
                CompanyName = x.Companyname,
            }).ToListAsync();
            return await Result<List<ShipperResponse>>.SuccessAsync(shipperList);
        }
    }
}
