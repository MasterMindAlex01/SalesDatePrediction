
namespace SalesDatePrediction.Application.Models.Responses
{
    public class OrderResponse
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipName { get; set; } = null!;

        public string ShipAddress { get; set; } = null!;

        public string ShipCity { get; set; } = null!;
    }
}
