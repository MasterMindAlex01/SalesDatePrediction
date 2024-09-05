
namespace SalesDatePrediction.Application.Models.Requests
{
    public class OrderQueryFilterRequest : BasePagedQueryRequest
    {
        public int CustId { get; set; }
    }
}
