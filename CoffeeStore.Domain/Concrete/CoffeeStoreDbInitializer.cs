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
                new Customer{Cus_Name="Zhao Liu",Cus_Phone="3522784182",Cus_Email="liuzhao070@gmail.com",Cus_Password="123",CultureName="zh-CN"}
            }.ForEach(cus => context.Customers.Add(cus));
            context.SaveChanges();

            new List<Store>{
                new Store{S_Name="Library West Starbucks",S_Location="Library West"},
                new Store{S_Name="Reitz Union Starbucks",S_Location="Reitz Union Starbucks"}
            }.ForEach(store => context.Stores.Add(store));
            context.SaveChanges();

            new List<Culture>{
                new Culture{Code="en-US",LCID=1033,Name="English (United States)",IsEnabled=true,ParentCode="EN"},
                new Culture{Code="zh-CN",LCID=2052,Name="Chinese (Simplified, PRC)",IsEnabled=true,ParentCode="zh-CHS"}
            }.ForEach(culture => context.Cultures.Add(culture));
            context.SaveChanges();

            new List<TranslationDefinition>{
                new TranslationDefinition{TranslationDefinitionKey="testA",Value="test1_default",Name="test1",Description="value for test1"},
                new TranslationDefinition{TranslationDefinitionKey="testB",Value="test2_defalut",Name="test2",Description="Value for test2"}
            }.ForEach(translationDefinition => context.TranslationDefinitions.Add(translationDefinition));
            context.SaveChanges();

            new List<Translation>{
                new Translation{TranslationDefinitionID=1,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="test1_zh-CN"},
                new Translation{TranslationDefinitionID=2,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="test2_zh-CN"}
            }.ForEach(translation => context.Translations.Add(translation));
            context.SaveChanges();

        }
    }
}
