using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class LoginRepository : ILoginRepository
    {
        private EFDbContext context = new EFDbContext();

        public string GetPassword(string username)
        {
            Customer dbEntry = context.Customers.Where(x => x.Cus_Name.Equals(username)).FirstOrDefault();
            if (dbEntry != null)
                return dbEntry.Cus_Password;
            else
                return null;
        }
    }
}
