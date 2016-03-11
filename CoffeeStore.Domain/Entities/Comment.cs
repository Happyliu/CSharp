using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int Rating { get; set; }
        public string CommentText { get; set; }
        public string Author { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
