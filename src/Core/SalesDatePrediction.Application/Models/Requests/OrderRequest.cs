
namespace SalesDatePrediction.Application.Models.Requests
{
    public class OrderRequest
    {

        public int Empid { get; set; }

        public DateTime Orderdate { get; set; }

        public DateTime Requireddate { get; set; }

        public DateTime? Shippeddate { get; set; }

        public int Shipperid { get; set; }

        public decimal Freight { get; set; }

        public string Shipname { get; set; } = null!;

        public string Shipaddress { get; set; } = null!;

        public string Shipcity { get; set; } = null!;

        public string Shipcountry { get; set; } = null!;
        
        public IEnumerable<OrderDetailRequest> OrderDetails { get; set; } = new List<OrderDetailRequest>();
    }
}
