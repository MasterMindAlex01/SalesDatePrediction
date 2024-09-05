
namespace SalesDatePrediction.Application.Models.Requests
{
    public class OrderDetailRequest
    {
        public int Productid { get; set; }

        public decimal Unitprice { get; set; }

        public short Qty { get; set; }

        public decimal Discount { get; set; }
    }
}
