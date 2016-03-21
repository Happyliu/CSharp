using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string P_Name { get; set; }
        public decimal P_Price { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public double Rating { get; set; }
        public int NoOfComments { get; set; }
    }
}