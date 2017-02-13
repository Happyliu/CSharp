using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public ProductRepository()
        {

        }

        public ProductRepository(EFDbContext context)
        {
           this.context = context;
        }

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public IEnumerable<Product> GetProductsWithComments()
        {
            IEnumerable<Product> products = context.Products;
            Products.ToList().ForEach(x =>
            {
                x.Comments = context.Comments.Where(c => c.ProductID == x.ProductID).ToList();
            });
            return products;
        }

        public Product GetProductById(int productId)
        {
            Product dbEntry = context.Products.Find(productId);
            return dbEntry;
        }

        public IEnumerable<Product> GetProductsByCatID(int categoryId)
        {
            return context.Products.Where(c => c.CategoryID == categoryId);
        }

        public IEnumerable<Product> GetProductByPriceRange(int min, int max)
        {
            return context.Products.Where(c => c.P_Price >= min && c.P_Price <= max);
        }

        public async Task<int> SaveProductAsync(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.P_Name = product.P_Name;
                    dbEntry.P_Price = product.P_Price;
                    dbEntry.CategoryID = product.CategoryID;
                    dbEntry.Category = product.Category;
                    dbEntry.Label = product.Label;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.Description = product.Description;
                }
            }

            return await context.SaveChangesAsync();
        }

        public int SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.P_Name = product.P_Name;
                    dbEntry.P_Price = product.P_Price;
                    dbEntry.CategoryID = product.CategoryID;
                    dbEntry.Category = product.Category;
                    dbEntry.Label = product.Label;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.Description = product.Description;
                }
            }

            return context.SaveChanges();
        }

        public async Task<Product> DeleteProductAsync(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        public async Task<int> AddCommentAsync(Comment comment)
        {
            if (comment != null)
            {
                context.Comments.Add(comment);
            }
            return await context.SaveChangesAsync();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
            }
            context.SaveChanges();
            return dbEntry;
        }

        public IEnumerable<Product> GetProductsByLabel(string label)
        {
            return context.Products.Where(m => m.Label.Equals(label));
        }

        public string GetCategoryName(int categoryId)
        {
            return context.Categories.Where(m => m.CategoryID == categoryId).SingleOrDefault().Cat_Name;
        }

    }
}
