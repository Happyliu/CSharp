using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class CoffeeStoreDbInitializer : DropCreateDatabaseAlways<EFDbContext>
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
                new TranslationDefinition{TranslationDefinitionKey="SitemapHome",Value="Home",Name="Home",Description="Home page sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapAbout",Value="About",Name="About",Description="About page sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapContact",Value="Contact",Name="Contact",Description="Contact page sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapMenu",Value="Menu",Name="Menu",Description="Menu page sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapLogin",Value="Login",Name="Login",Description="Login in sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapLogout",Value="Logout",Name="Logout",Description="Logout in sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapViewCart",Value="View My Cart",Name="ViewCart",Description="view cart in the dropdown in sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapClearCart",Value="Clear Cart",Name="ClearCart",Description="Clear cart in sitemap dropdown"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapItems",Value="Items",Name="About",Description="About page sitemap"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapFooterAddress",Value="Our Address",Name="Our Address",Description="Address in the footer"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapFooterAddressLine1",Value="3700 Windmeadows Blvd",Name="AddressLine1",Description="AddressLine1 in the footer"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapFooterAddressLine2",Value="Gainesville,FL,32608",Name="AddressLine2",Description="AddressLine2 in the footer"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapFooterAddressCountry",Value="US",Name="AddressCountry",Description="AddressCountry in the footer"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapFooterCopyRight",Value="© Copyright 2016 Ristorante Con Fusion",Name="CopyRight",Description="CopyRight in the footer"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapFooterLinks",Value="Links",Name="Links",Description="Links in the footer"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapLoginModelUserName",Value="User Name: ",Name="User Name",Description="User Name in Login Model"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapLoginModelPassword",Value="Password: ",Name="Password",Description="Password in Login Model"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapLoginModelRemember",Value="Remember",Name="Remember",Description="Remember in the Login Model"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapLoginModelSignIn",Value="Sign In",Name="Sign In",Description="Sign In in the Login Model"},
                new TranslationDefinition{TranslationDefinitionKey="SitemapLoginModelCancel",Value="Cancel",Name="Cancel",Description="Cancel in the Login Model"},
                new TranslationDefinition{TranslationDefinitionKey="PageContentMenuNavTabMenu",Value="The Menu",Name="NavTabMenu",Description="Menu text in the menu page nav bar"},
                new TranslationDefinition{TranslationDefinitionKey="PageContentMenuNavTabFood",Value="Food",Name="NavTabFood",Description="Food text in the menu page nav bar"},
                new TranslationDefinition{TranslationDefinitionKey="PageContentMenuNavTabDrinks",Value="Drinks",Name="NavTabDrinks",Description="Drinks text in the menu page nav bar"},
                new TranslationDefinition{TranslationDefinitionKey="PageContentMenuNavTabDesserts",Value="Desserts",Name="NavTabDesserts",Description="Desserts text in the menu page nav bar"},
                new TranslationDefinition{TranslationDefinitionKey="PageContentMenuQtyText",Value="Qty:",Name="quantity",Description="qty text in the menu page"},
                new TranslationDefinition{TranslationDefinitionKey="PageContentMenuButtonAddCart",Value="Add To Cart",Name="Add to cart",Description="add to cart button text in the menu page"}
            }.ForEach(translationDefinition => context.TranslationDefinitions.Add(translationDefinition));
            context.SaveChanges();

            new List<Translation>{
                new Translation{TranslationDefinitionID=1,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="主页"},
                new Translation{TranslationDefinitionID=2,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="关于我们"},
                new Translation{TranslationDefinitionID=3,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="联系我们"},
                new Translation{TranslationDefinitionID=4,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="菜单"},
                new Translation{TranslationDefinitionID=5,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="登录"},
                new Translation{TranslationDefinitionID=6,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="登出"},
                new Translation{TranslationDefinitionID=7,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="浏览购物车"},
                new Translation{TranslationDefinitionID=8,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="清空购物车"},
                new Translation{TranslationDefinitionID=9,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="件商品"},
                new Translation{TranslationDefinitionID=10,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="地址"},
                new Translation{TranslationDefinitionID=11,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="草原微风大街3700号"},
                new Translation{TranslationDefinitionID=12,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="盖恩斯维尔,佛罗里达,邮编32608"},
                new Translation{TranslationDefinitionID=13,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="美国"},
                new Translation{TranslationDefinitionID=14,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="© 版权所有 2016 Ristorante Con Fusion"},
                new Translation{TranslationDefinitionID=15,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="链接"},
                new Translation{TranslationDefinitionID=16,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="用户名： "},
                new Translation{TranslationDefinitionID=17,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="密码： "},
                new Translation{TranslationDefinitionID=18,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="记住账户"},
                new Translation{TranslationDefinitionID=19,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="登录"},
                new Translation{TranslationDefinitionID=20,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="取消"},
                new Translation{TranslationDefinitionID=21,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="所有菜单"},
                new Translation{TranslationDefinitionID=22,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="食物"},
                new Translation{TranslationDefinitionID=23,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="饮料"},
                new Translation{TranslationDefinitionID=24,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="甜点"},
                new Translation{TranslationDefinitionID=25,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="数量："},
                new Translation{TranslationDefinitionID=26,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="加入购物车"}
            }.ForEach(translation => context.Translations.Add(translation));
            context.SaveChanges();

        }
    }
}
