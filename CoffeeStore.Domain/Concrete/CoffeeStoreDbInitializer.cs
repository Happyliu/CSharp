using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class CoffeeStoreDbInitializer : DropCreateDatabaseAlways<EFDbContext>//DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            new List<Category> {
               new Category{Cat_Name="food"},
               new Category{Cat_Name="drink"}
           }.ForEach(category => context.Categories.Add(category));

            context.SaveChanges();

            new List<Product>{
                new Product{CategoryID=1,P_Name="Cool Lime Starbucks Refreshers",P_Price=4,Label="",Description="Real fruit juice, mint and a lime slice shaken with Green Coffee Extract for a boost of natural energy, served over ice.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Strawberry Acai Starbucks Refreshers",P_Price=4,Label="",Description="Sweet strawberry flavors are accented by passion fruit & acai notes and lightly caffeinated with Green Coffee Extract.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Iced Coffee with Milk",P_Price=3.50M,Label="",Description="Freshly brewed Starbucks Iced Coffee Blend with milk – served chilled and lightly sweetened over ice.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Cold Brew Coffee with Milk",P_Price=4.50M,Label="",Description="Our small-batch, slow-steeped, super smooth Cold Brew coffee gets a splash of milk to add a creamy side to its chocolaty, citrusy flavor goodness.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Hot Chocolate",P_Price=5,Label="",Description="Steamed milk with vanilla- and mocha-flavored syrups. Topped with sweetened whipped cream and chocolate-flavored drizzle.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Mango Carrot Smoothie",P_Price=4,Label="",Description="Sweet and flavorful mango gets a blast of carrot and nonfat Greek yogurt to create a perfect this flavor combo.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Strawberry Banana Smoothie",P_Price=4,Label="",Description="We've added apple, banana and nonfat Greek yogurt to the classic strawberry smoothie. Delicious.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Sweet Greens Smoothie",P_Price=4,Label="",Description="Green vegetable juices are balanced with mango, banana and nonfat Greek yogurt to create the perfect veggie and fruit smoothie."},
                new Product{CategoryID=1,P_Name="Strawberry Smoothie",P_Price=4.50M,Label="",Description="A whole banana, natural strawberry puree, milk and our special powder mix of whey protein and fiber are blended with ice. Nourish your body and treat your tastebuds.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Caffè Vanilla Frappuccino Blended Coffee",P_Price=5.50M,Label="",Description="We take Frappuccino roast coffee and vanilla bean powder, combine them with milk and ice, then top it with whipped cream. Tastes like happiness.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Caffè Vanilla Light Frappuccino Blended Coffee",P_Price=5,Label="",Description="We blend Frappuccino roast coffee and vanilla bean powder with nonfat milk and ice to give you this lower calorie sippable pleasure.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Caramel Frappuccino Blended Coffee",P_Price=5,Label="",Description="Buttery caramel syrup meets coffee, milk and ice for a rendezvous in the blender. Then whipped cream and caramel sauce layer the love on top.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Green Tea Crème Frappuccino Blended Crème",P_Price=5.50M,Label="",Description="We blend sweetened premium matcha green tea, milk and ice and top it with sweetened whipped cream to give you a delicious boost of energy.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Strawberries & Crème Frappuccino Blended Crème",P_Price=5,Label="",Description="Strawberries and milk are blended with ice and topped with a swirl of whipped cream. Sip on the crème of the crop.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Vanilla Bean Crème Frappuccino Blended Crème",P_Price=5,Label="",Description="This rich and creamy blend of vanilla bean, milk and ice topped with whipped cream takes va-va-vanilla flavor to another level. To change things up, try it Affogato-style by adding an Affogato-style shot: a hot espresso shot poured right over the top.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Cheese & Fruit Bistro Box",P_Price=6,Label="",Description="A trio of cheeses: creamy Brie, bold Gouda, two year-aged Cheddar, 9-grain crackers, green apple wedges and a mix of roasted almonds and tart dried cranberries.",SearchKey=""},
                new Product{CategoryID=2,P_Name="PB&J on Wheat Bistro Box",P_Price=6,Label="",Description="Natural peanut butter and strawberry jam is spread on our soft, honey wheat bread and served with a side of veggies and Greek yogurt ranch dip for a yummy twist on this classic, peanut-y favorite.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Protein Bistro Box",P_Price=6,Label="",Description="A hard-boiled cage free egg, sliced tart apples, grapes, and white Cheddar cheese served with multigrain muesli bread and honeyed peanut butter.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Thai-Style Peanut Chicken Wrap",P_Price=4,Label="",Description="Grilled chicken breast tossed in a peanut coconut sauce, topped with a chile-lime veggie slaw, red bell peppers, lettuce and ginger cream cheese served on a chile tortilla. Paired with peanut-coconut sauce and a side of grapes.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Evolution Fres Greek Yogurt Parfait",P_Price=4,Label="",Description="Creamy non-fat Dannon® Greek yogurt is topped with crunchy seeded granola and strawberry compote.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Fresh Blueberries and Honey Greek Yogurt Parfait",P_Price=4.50M,Label="",Description="Creamy non-fat Dannon Greek yogurt is layered with fresh, seasonal blueberries, pure honey and crunchy granola. Refreshingly delicious.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Seasonal Harvest Fruit Blend",P_Price=2,Label="",Description="A delicious medley of seasonal fruit.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Strawberry Shortcake Trifle",P_Price=2,Label="",Description="Lightly sweet Petite Vanilla Bean Scones layered with a strawberry drizzle and whipped cream, hand-prepared by your barista.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Classic Whole-Grain Oatmeal",P_Price=4.50M,Label="",Description="A blend of rolled and steel-cut oats with dried fruit, a nut medley and brown sugar as optional toppings.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Egg & Cheddar Breakfast Sandwich",P_Price=5,Label="",Description="Warm, fluffy egg and mild cheddar cheese are layered on a toasted organic wheat English muffin to create the classic taste of breakfast perfection.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Hearty Blueberry Oatmeal",P_Price=5.50M,Label="",Description="A blend of rolled and steel-cut oats with blueberries and agave syrup.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Spinach, Feta & Cage Free Egg White Breakfast Wrap",P_Price=5,Label="",Description="We bring together cage-free egg whites, spinach, feta cheese and tomatoes inside a whole wheat wrap, then toast it to perfection.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Sausage, Cheddar & Egg Breakfast Sandwich",P_Price=5,Label="",Description="A Southern-style sausage patty, fluffy eggs and aged Cheddar cheese are served on a perfectly toasty English muffin. An iconic breakfast sandwich that reminds you why you love breakfast.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Iced Skinny Mocha",P_Price=4,Label="",Description="Bittersweet skinny mocha sauce, espresso and non-fat milk served over ice.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Iced Caffè Latte",P_Price=4,Label="",Description="Our dark, rich espresso is combined with milk and served over ice. A perfect milk forward warm up.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Ham & Swiss Panini",P_Price=5,Label="",Description="Ham and Swiss cheese with Dijon mustard on toasted focaccia",SearchKey=""},
                new Product{CategoryID=2,P_Name="Turkey Pesto Panini",P_Price=5,Label="",Description="Sliced turkey and melty provolone cheese are stacked on our toasted focaccia roll and topped with fire-roasted peppers and basil pesto. It's a party in a panini.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Egg Salad Sandwich",P_Price=4.50M,Label="",Description="Egg salad mixed with chives, dill relish and arugula on cider wheat bread.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Zesty Chicken & Black Bean Salad Bowl",P_Price=6,Label="",Description="Grilled chicken, black beans, roasted corn, jicama, tomatoes, feta, spring greens and quinoa. Side of mild chili vinaigrette.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Chocolate Marble Loaf Cake",P_Price=3,Label="",Description="Our buttery pound cake meets swirls of vanilla and chocolate before getting topped with a chocolate fudge icing. Hard to believe it tastes even better than it looks.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Cranberry Orange Scone",P_Price=3,Label="",Description="Each bite of this buttery scone showcases tangy cranberries and tart orange zest that are perfectly balanced with a ribbon of tangy-sweet cranberry spread. It's a festival of lush fruit.",SearchKey=""},
                new Product{CategoryID=2,P_Name="Ice Cream Cone Sugar Cookie",P_Price=2,Label="",Description="Kids of all ages will scream for this ice cream cone-shaped buttery shortbread sugar cookie. Comes with pink or white chocolaty icing.",SearchKey=""},
                new Product{CategoryID=2,P_Name="S'mores Bar Multipack",P_Price=4,Label="",Description=@"One for you, four to share. This summer treat starts with a slightly crunchy graham crust, then a layer of milk chocolate and finally it's piled high with lightly-toasted marshmallows. We're sure you'll say ""s'mmmore please.""",SearchKey=""},
                new Product{CategoryID=2,P_Name="Petite Vanilla Bean Scone",P_Price=4,Label="",Description="Real fruit juice, mint and a lime slice shaken with Green Coffee Extract for a boost of natural energy, served over ice.",SearchKey=""},
                new Product{CategoryID=2,P_Name="S'mores Bar",P_Price=4,Label="",Description=@"This summer treat starts with a slightly crunchy graham crust, then a layer of milk chocolate and finally it's piled high with lightly-toasted marshmallows. We're sure you'll say ""s'mmmore please.""",SearchKey=""},
                new Product{CategoryID=1,P_Name="Starbucks Bottled S'mores Frappuccino Coffee Drink",P_Price=3,Label="",Description="A layered taste experience, the sweet flavors of marshmallow, chocolate, and honey graham blended with cool creamy milk and Starbucks coffee.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Starbucks Bottled Vanilla Frappuccino Coffee Drink",P_Price=3,Label="",Description="Coffee, lowfat milk and vanilla – available to go.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Tazo Bottled Black with Lemon",P_Price=2.50M,Label="",Description="Sweetened black tea with a dash of lemon.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Tazo Bottled Brambleberry",P_Price=2.50M,Label="",Description="Herbal tea & marionberry-flavored juice blend beverage.",SearchKey=""},
                new Product{CategoryID=1,P_Name="Tazo Bottled Berry Blossom White",P_Price=2.50M,Label="",Description="White tea & blueberry flavored beverage.",SearchKey=""}
            }.ForEach(product => context.Products.Add(product));

            context.SaveChanges();

            new List<Customer>{
                new Customer{Cus_Name="Zhao Liu",Cus_Phone="3522784182",Cus_Email="liuzhao070@gmail.com",Cus_Password="123",CultureName="zh-CN"},
                new Customer{Cus_Name="guest1",Cus_Phone="3522784182",Cus_Email="guest1@gmail.com",Cus_Password="guest1",CultureName="en-US"},
                new Customer{Cus_Name="guest2",Cus_Phone="3522784182",Cus_Email="guest2@gmail.com",Cus_Password="guest2",CultureName="zh-CN"}
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
                new TranslationDefinition{TranslationDefinitionKey="PageContentMenuButtonAddCart",Value="Add To Cart",Name="Add to cart",Description="add to cart button text in the menu page"},
                new TranslationDefinition{TranslationDefinitionKey="LanguageEnglishUS",Value="English(United States)",Name="English(United States)",Description="United states english string"},
                new TranslationDefinition{TranslationDefinitionKey="LanguageChineseSimplified",Value="Chinese(Simplified)",Name="Chinese(Simplified)",Description="Simplied Chinese string"},
                new TranslationDefinition{TranslationDefinitionKey="LanguagePickerModalChooseLanguage",Value="Choose a language",Name="Choose a language",Description="Choose a language string in language picker modal"},
                new TranslationDefinition{TranslationDefinitionKey="LanguagePickerModalSupportedLanguageText1part",Value="CoffeeStore is offered in ",Name="CoffeeStore is offered in ",Description="supported language first part in language picker modal"},
                new TranslationDefinition{TranslationDefinitionKey="LanguagePickerModalSupportedLanguageText2part",Value=" languages",Name=" languages",Description="supported language second part in language picker modal"},
                new TranslationDefinition{TranslationDefinitionKey="LanguagePickerModalSearchInputBoxPlaceHolder",Value="Search languages... ",Name="Search languages... ",Description="place holder string for search language input text box in language picker modal"},
                new TranslationDefinition{TranslationDefinitionKey="LanguagePickerModalDontSeeLanguagetext",Value="Don't see your language?",Name="Don't see your language?",Description="don't see language string in language picker modal"},
                new TranslationDefinition{TranslationDefinitionKey="LanguagePickerModalHelpUsTranslate",Value="Help us translate!",Name="Help us translate!",Description="help us translate string in language picker modal"},
                new TranslationDefinition{TranslationDefinitionKey="LanguagePickerModalTitle",Value="Language Choose Modal",Name="Language Choose Modal",Description="modal title in language picker modal"}
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
                new Translation{TranslationDefinitionID=26,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="加入购物车"},
                new Translation{TranslationDefinitionID=27,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="英语(美国)"},
                new Translation{TranslationDefinitionID=28,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="中文(简体)"},
                new Translation{TranslationDefinitionID=29,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="选择一门语言"},
                new Translation{TranslationDefinitionID=30,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="咖啡屋提供"},
                new Translation{TranslationDefinitionID=31,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="语言"},
                new Translation{TranslationDefinitionID=32,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="搜索你想要的语言..."},
                new Translation{TranslationDefinitionID=33,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="没有看到想要的语言？"},
                new Translation{TranslationDefinitionID=34,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="帮助我们翻译！"},
                new Translation{TranslationDefinitionID=35,ObjectType="TranslationDefinition",PropertyName="Value",CultureCode="zh-CN",Value="语言选择页面"}
            }.ForEach(translation => context.Translations.Add(translation));
            context.SaveChanges();

        }
    }
}
