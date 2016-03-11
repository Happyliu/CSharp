using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class CoffeeStoreDbInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            new List<Category> {
               new Category{Cat_Name="food"},
               new Category{Cat_Name="drink"}
           }.ForEach(category => context.Categories.Add(category));

            context.SaveChanges();

            new List<Product>{
                new Product{CategoryID=1,P_Name="Caramel Flan Latte",P_Price=6},
                new Product{CategoryID=1,P_Name="Iced Coffee",P_Price=3},
                new Product{CategoryID=1,P_Name="Hot Chocolate",P_Price=5},
                new Product{CategoryID=1,P_Name="Cold Apple Juice",P_Price=4},
                new Product{CategoryID=2,P_Name="Blueberry Scone",P_Price=3},
                new Product{CategoryID=2,P_Name="Cheese Danish",P_Price=3},
                new Product{CategoryID=2,P_Name="Chocolate Chunk Cookie",P_Price=1},
                new Product{CategoryID=2,P_Name="Morning Bun",P_Price=2}
            }.ForEach(product => context.Products.Add(product));

            context.SaveChanges();

            new List<Customer>{
                new Customer{Cus_Name="Zhao Liu",Cus_Phone="3522784182",Cus_Email="liuzhao070@gmail.com",Cus_Password="123"}
            }.ForEach(cus => context.Customers.Add(cus));
            context.SaveChanges();

            new List<Store>{
                new Store{S_Name="Library West Starbucks",S_Location="Library West"},
                new Store{S_Name="Reitz Union Starbucks",S_Location="Reitz Union Starbucks"}
            }.ForEach(store => context.Stores.Add(store));
            context.SaveChanges();

        }
    }
}
