using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Order
    {
        public int Orderid { get; set; }

        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetails> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetails>();
        }
    }
}
