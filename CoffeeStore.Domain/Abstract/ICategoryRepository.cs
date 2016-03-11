using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeStore.Domain.Entities;

namespace CoffeeStore.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
