using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Extensions;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Requests;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Domain.Entities;
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

        public async Task<Result<int>> CreateOrderAsync(OrderRequest orderRequest)
        {
            await _context.Database.BeginTransactionAsync();
            try
            {
                Order newOrder = MapOrderByOrderRequest(orderRequest);

                _context.Orders.Add(newOrder);

                await _context.SaveChangesAsync();

                List<OrderDetail> orderDetailList = MapOrderDetailListByOrderDetailRequestList(
                    newOrder.Orderid, orderRequest.OrderDetails);
                foreach (var orderDetail in orderDetailList)
                {
                    newOrder.OrderDetails.Add(orderDetail);
                }

                await _context.SaveChangesAsync();

                await _context.Database.CommitTransactionAsync();
                return await Result<int>.SuccessAsync(newOrder.Orderid);
            }
            catch (Exception)
            {
                await _context.Database.RollbackTransactionAsync();
                return await Result<int>.FailAsync();
            }
        }

        public async Task<PaginatedResult<OrderResponse>> GetOrderPagedListByCustIdAsync(OrderQueryFilterRequest filterRquest)
        {
            PaginatedResult<OrderResponse> paginatedResult = await _context.Orders
                .Where(x => x.Custid == filterRquest.CustId)
                .Select(x => new OrderResponse
                {
                    OrderId = x.Orderid,
                    OrderDate = x.Orderdate,
                    RequiredDate = x.Requireddate,
                    ShipAddress = x.Shipaddress,
                    ShipCity = x.Shipcity,
                    ShipName = x.Shipname,
                    ShippedDate = x.Shippeddate
                }).ToPaginatedListAsync(filterRquest.PageNumber, filterRquest.PageSize);
            return paginatedResult;
        }

        private static Order MapOrderByOrderRequest(OrderRequest orderRequest)
        {
            return new Order()
            {
                Orderid = 0,
                Empid = orderRequest.Empid,
                Freight = orderRequest.Freight,
                Orderdate = orderRequest.Orderdate,
                Requireddate = orderRequest.Requireddate,
                Shipaddress = orderRequest.Shipaddress,
                Shipcity = orderRequest.Shipcity,
                Shipcountry = orderRequest.Shipcountry,
                Shipname = orderRequest.Shipname,
                Shippeddate = orderRequest.Shippeddate,
                Shipperid = orderRequest.Shipperid,
            };
        }
        private static List<OrderDetail> MapOrderDetailListByOrderDetailRequestList(
            int orderId,IEnumerable<OrderDetailRequest> orderDetails)
        {
            return orderDetails.Select(x => new OrderDetail
            {
                Orderid = orderId,
                Discount = x.Discount,
                Productid = x.Productid,
                Qty = x.Qty,
                Unitprice = x.Unitprice
            }).ToList();
        }

    }
}
