using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Abstract
{
    public interface ICustomerRepository
    {
        int GetCustomerId(string cusName);
        string GetCustomerCulture(string cusName);
    }
}
