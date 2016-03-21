﻿using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Abstract
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> Comments();
        Task<int> SaveCommentAsync(Comment comment);
        IEnumerable<Comment> GetCommentsByProductID(int productId);
    }
}
