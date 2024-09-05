using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Extensions;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Requests;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Infrastructure.Contexts;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly StoreDBContext _context;

        public CustomerService(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<CustomerResponse>> GetSaleDatePredictionPagedListAsync(
            CustomerQueryFilterRequest filterRequest)
        {
            var paginatedResult = await _context.Customers.Include(x => x.Orders)
                .Select(x => new CustomerResponse(x.Orders.Select(y => new OrderCustomerResponse{ Orderdate = y.Orderdate}))
                {
                    CustomerName = x.Contactname,
                }).ToPaginatedListAsync(filterRequest.PageNumber, filterRequest.PageSize);
            
            return paginatedResult;
        }
    }
}
