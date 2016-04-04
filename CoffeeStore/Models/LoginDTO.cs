using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class LoginDTO
    {
        public string Username;
        public string Password;
        public string Ip;
        public string UserAgent;
        public int Time;
    }
}