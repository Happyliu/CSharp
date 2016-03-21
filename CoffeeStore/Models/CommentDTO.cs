using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class CommentDTO
    {
        public int ProductID { get; set; }
        public int CommentID { get; set; }
        public int Rating { get; set; }
        public string CommentText { get; set; }
        public string Author { get; set; }
        public DateTime CommentTime { get; set; }
    }
}