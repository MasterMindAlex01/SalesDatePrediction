using SalesDatePrediction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Application.Models.Responses
{
    public class CustomerResponse
    {
        private readonly IEnumerable<OrderCustomerResponse> _orders;
        public CustomerResponse(IEnumerable<Order>? orders)
        {
            _orders = orders != null && orders.Count() > 0 
                ?  orders.Select(x => new OrderCustomerResponse { Orderdate = x.Orderdate}).OrderBy(x => x.Orderdate)
                : new List<OrderCustomerResponse>();
        }
        public string CustomerName { get; set; } = null!;
        public DateTime LastOrderDate => _orders.Count() > 0 ? _orders.LastOrDefault()!.Orderdate : DateTime.UtcNow;
        public DateTime NextPredictedOrderDate
        {
            get
            {
                if (_orders.Count() == 0) return DateTime.UtcNow;

                DateTime lastOrderDate = _orders.LastOrDefault()!.Orderdate;
                
                double average = _orders.Where(x => x.Orderdate != lastOrderDate)
                    .Select(x => (x.Orderdate - _orders.First().Orderdate).TotalDays).Average();

                double result = average + lastOrderDate.Day;

                return lastOrderDate.AddDays(result);   
                    
            }
        }
    }
}
