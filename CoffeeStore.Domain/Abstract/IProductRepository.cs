using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        Product GetProductById(int productID);
        IEnumerable<Product> GetProductsByCatID(int categoryID);
        IEnumerable<Product> GetProductByPriceRange(int min, int max);
        Task<int> SaveProductAsync(Product product);
        int SaveProduct(Product product);
        Task<Product> DeleteProductAsync(int productId);
        Product DeleteProduct(int productId);
    }
}
