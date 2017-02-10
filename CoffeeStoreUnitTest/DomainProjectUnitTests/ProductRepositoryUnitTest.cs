using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeStore.Domain.Concrete;
using CoffeeStore.Domain.Entities;

namespace CoffeeStoreUnitTest.DomainProjectUnitTests
{
    [TestFixture]
    public class ProductRepositoryUnitTest
    {
        ProductRepository repository = new ProductRepository(new EFDbContext());

        [Test]
        public void CheckHaveProducts()
        {
            Assert.That(repository.Products, Is.Not.Null);
        }

        [Test]
        public void CanGetProductById()
        {
            Product p = repository.GetProductById(1);
            Assert.That(p.CategoryID, Is.EqualTo(1));
            Assert.That(p.P_Name, Is.EqualTo("Cool Lime Starbucks Refreshers"));
        }

        [Test]
        public void CanGetProductsByCatId()
        {
            IEnumerable<Product> products = repository.GetProductsByCatID(1);
            Assert.That(products,Is.All.Not.Null);
            Assert.That(products.All(p => p.CategoryID == 1));
        }


        [Test]
        public void CanGetProductByRange()
        {
            IEnumerable<Product> products = repository.GetProductByPriceRange(-2, 5);
            Assert.That(products, Is.All.Not.Null);
            Assert.That(products.All(p => p.P_Price>-2&&p.P_Price<=5));
        }

        [Test]
        public void AddNewProduct()
        {
            Product p = new Product()
            {
                ProductID=0,
                P_Name = "Test",
                P_Price = 3,
                Description = "this is a test",
                CategoryID=1
            };
            repository.SaveProduct(p);
            IEnumerable<Product> products = repository.Products.ToList();
            Assert.That(products.Any(pd => pd.P_Name.Equals("Test")&&pd.P_Price==3&&pd.Description.Equals("this is a test")));

        }

        [Test]
        public void CanRemoveProduct()
        {
            Assert.That(repository.Products.Any(pd => pd.P_Name.Equals("Test") && pd.P_Price == 3 && pd.Description.Equals("this is a test")));
            repository.DeleteProduct(47);
            Assert.That(repository.Products.Any(pd => pd.P_Name!="Test"));
        }
    }
}
