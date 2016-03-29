using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderTime { get; set; }
        public bool PickUp { get; set; }
        public DateTime PickUpTime { get; set; }
        public string Status { get; set; }
        public ICollection<OrderLineDTO> Lines { get; set; }
    }
}