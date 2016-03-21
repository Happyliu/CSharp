using CoffeeStore.Domain.Entities;
using System.Data.Entity;

namespace CoffeeStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("CoffeeStoreDb")
        {
            Database.SetInitializer<EFDbContext>(new CoffeeStoreDbInitializer());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
