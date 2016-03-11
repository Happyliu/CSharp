using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Cus_Name { get; set; }
        public string Cus_Phone { get; set; }
        public string Cus_Email { get; set; }
        public string Cus_Password { get; set; }
    }
}
