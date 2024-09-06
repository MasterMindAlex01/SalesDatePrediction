
namespace SalesDatePrediction.Application.Models.Requests
{
    public class CustomerQueryFilterRequest : BasePagedQueryRequest
    {
        public string? SearchName { get; set; }
    }
}
