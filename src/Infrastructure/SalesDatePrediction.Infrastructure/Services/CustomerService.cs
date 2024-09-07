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
            var query = _context.Customers.Include(x => x.Orders).AsQueryable();

            if (!string.IsNullOrEmpty( filterRequest.SearchName))
            {
                query = query.Where(x => x.Companyname.Contains(filterRequest.SearchName));
            }

            var paginatedResult = await query
                .Select(x => x.Orders.Select(x => x.Orderid).Count() > 0 ? new CustomerResponse(x.Orders)
                {
                    CustomerName = x.Companyname,
                }: new CustomerResponse(new List<Order>())
                {
                    CustomerName = x.Companyname,
                }).AsNoTracking().ToPaginatedListAsync(filterRequest.PageNumber, filterRequest.PageSize);
            
            return paginatedResult;
        }
    }
}
