using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string P_Name { get; set; }
        [Display(Name = "Price")]
        [Required]
        public decimal P_Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Category Category { get; set; }
    }
}
