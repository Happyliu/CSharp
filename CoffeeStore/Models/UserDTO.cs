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
        public int productId;
        public string name;
        public int price;
        public int qty;
        public byte[] image;

        public ItemDTO(int id, string name, int price, int qty, byte[] image)
        {
            this.productId = id;
            this.name = name;
            this.price = price;
            this.qty = qty;
            this.image = image;
        }
    }

}