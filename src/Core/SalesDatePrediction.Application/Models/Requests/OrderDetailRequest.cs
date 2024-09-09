
using System.ComponentModel.DataAnnotations;

namespace SalesDatePrediction.Application.Models.Requests
{
    public class OrderDetailRequest
    {
        [Range(1, int.MaxValue)]
        public required int Productid { get; set; }
        [Range(1, int.MaxValue)]
        public required decimal Unitprice { get; set; }
        [Range(1, int.MaxValue)]
        public required short Qty { get; set; }
        [Range(0, 1)]
        public required decimal Discount { get; set; }
    }
}
