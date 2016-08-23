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

        public bool IsValidUserName(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                return context.Customers.Any(x => x.Cus_Name.Equals(username));
            }
            return false;
        }

        public bool IsValidForLogin(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return context.Customers.Any(x => x.Cus_Name.Equals(username) && x.Cus_Password.Equals(password));
            }
            return false;
        }
    }
}
