using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Infrastructure.Contexts;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDBContext _context;

        public ProductService(StoreDBContext context)
        {
            _context = context;
        }

        public async Task<Result<List<ProductResponse>>> GetAllProductListAsync()
        {
            var productList = await _context.Products.Select(x => new ProductResponse
            {
                ProductId = x.Productid,
                ProductName = x.Productname,
            }).ToListAsync();
            return await Result<List<ProductResponse>>.SuccessAsync(productList);
        }
    }
}
