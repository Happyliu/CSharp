using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();

        public int GetCustomerId(string cusName)
        {
            Customer dbEntry = context.Customers.Where(x => x.Cus_Name.Equals(cusName)).SingleOrDefault();
            if (dbEntry != null)
                return dbEntry.CustomerID;
            return 0;
        }

    }
}
