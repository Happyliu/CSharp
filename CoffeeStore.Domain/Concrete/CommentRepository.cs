using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Comment> Comments()
        {
            return context.Comments;
        }

        public async Task<int> SaveCommentAsync(Comment comment)
        {
            if (comment.CommentID == 0)
            {
                context.Comments.Add(comment);
            }
            else
            {
                Comment dbEntry = context.Comments.FirstOrDefault(m => m.CommentID == comment.CommentID);
                if (dbEntry != null)
                {
                    dbEntry.Rating = comment.Rating;
                    dbEntry.CommentText = comment.CommentText;
                    dbEntry.Author = comment.Author;
                }
            }
            return await context.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetCommentsByProductID(int productId)
        {
            if (productId < 0)
            {
                return null;
            }
            else
            {
                return context.Comments.Where(c => c.ProductID == productId);
            }
        }

        public double GetRatingByProductID(int productId)
        {
            IList<Comment> result = context.Comments.Where(m => m.ProductID == productId).ToList();
            if (result.Count > 0)
                return result.Average(m => m.Rating);
            else
                return 0;
        }

    }
}
