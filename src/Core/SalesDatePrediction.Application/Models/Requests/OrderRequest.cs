
using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.Application.Models.Requests
{
    public class OrderRequest
    {
        [Range(1, int.MaxValue)]
        public required int Custid { get; set; }
        [Range(1, int.MaxValue)]
        public required int Empid { get; set; }

        public required DateTime Orderdate { get; set; }

        public required DateTime Requireddate { get; set; }

        public DateTime? Shippeddate { get; set; }
        [Range(1, int.MaxValue)]
        public required int Shipperid { get; set; }
        [Range(1, int.MaxValue)]
        public required decimal Freight { get; set; }

        public required string Shipname { get; set; } = null!;

        public required string Shipaddress { get; set; } = null!;

        public required string Shipcity { get; set; } = null!;

        public required string Shipcountry { get; set; } = null!;
        
        public required IEnumerable<OrderDetailRequest> OrderDetails { get; set; } = new List<OrderDetailRequest>();
    }
}
