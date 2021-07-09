using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_SERVICES.Models
{
    public class CustomerOrderDetails
    {
        public string CustomerId { get; set; }

        public string OrderId { get; set; }

        public string DeliveryAddress { get; set; }


        public IEnumerable<OrderDetail> OrderDetail { get; set; }

        
    }
}
