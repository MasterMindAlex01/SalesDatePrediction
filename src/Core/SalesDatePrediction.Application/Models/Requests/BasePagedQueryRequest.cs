
namespace SalesDatePrediction.Application.Models.Requests
{
    public class BasePagedQueryRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
