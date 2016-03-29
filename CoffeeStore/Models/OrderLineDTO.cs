using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class OrderLineDTO
    {
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
    }
}