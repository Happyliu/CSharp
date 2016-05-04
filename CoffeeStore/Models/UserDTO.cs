using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class UserDTO
    {
        public string userName;
        public string token;
        public IList<ItemDTO> cart;
        public UserDTO(string username, string token, IList<ItemDTO> cart)
        {
            this.userName = username;
            this.token = token;
            this.cart = cart;
        }
    }

    public class ItemDTO
    {
        public int id;
        public string name;
        public int qty;

        public ItemDTO(int id, string name, int qty)
        {
            this.id = id;
            this.name = name;
            this.qty = qty;
        }
    }

}