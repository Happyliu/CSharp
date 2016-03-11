using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
