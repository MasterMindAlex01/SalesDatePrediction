using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Application.Models.Responses
{
    public class CustomerResponse
    {
        private IEnumerable<OrderCustomerResponse> _orders = new List<OrderCustomerResponse>();
        public CustomerResponse(IEnumerable<OrderCustomerResponse> orders)
        {
            _orders = orders.OrderBy(x => x.Orderdate);
        }
        public string CustomerName { get; set; } = null!;
        public DateTime LastOrderDate => _orders.LastOrDefault()!.Orderdate;
        public DateTime NextPredictedOrderDate
        {
            get
            {
                var lastOrderDate = _orders.LastOrDefault()!.Orderdate;
                
                double average = _orders.Where(x => x.Orderdate != lastOrderDate)
                    .Select(x => (x.Orderdate - _orders.First().Orderdate).TotalDays).Average();

                var result = average + lastOrderDate.Day;

                return lastOrderDate.AddDays(result);   
                    
            }
        }
    }
}
