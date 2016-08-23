using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Abstract
{
    public interface ILoginRepository
    {
        string GetPassword(string username);
        bool IsValidUserName(string username);
        bool IsValidForLogin(string username, string password);
    }
}
