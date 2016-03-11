using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public bool PickUp { get; set; }
        public DateTime PickUpTime { get; set; }
        public string Status { get; set; }
        public Store Store { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderLine> Lines { get; set; }
    }
}
