using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Infrastructure.Contexts;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly StoreDBContext _context;

        public OrderService(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<Result<List<OrderResponse>>> GetOrderListByCustIdAsync(int custId)
        {
            var orderList = await _context.Orders
                .Where(x => x.Custid == custId)
                .Select(x => new OrderResponse
                {
                    OrderId = x.Orderid,
                    OrderDate = x.Orderdate,
                    RequiredDate = x.Requireddate,
                    ShipAddress = x.Shipaddress,
                    ShipCity = x.Shipcity,
                    ShipName = x.Shipname,
                    ShippedDate = x.Shippeddate
                }).ToListAsync();
            return await Result<List<OrderResponse>>.SuccessAsync(orderList);
        }
    }
}
