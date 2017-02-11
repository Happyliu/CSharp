using CoffeeStore.Controllers;
using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CoffeeStoreUnitTest.APIUnitTest
{
    [TestFixture]
    [Category("ProductApiTesting")]
    public class ProductApiUnitTest
    {

        [Test]
        public void can_get_product()
        {
            Mock<IProductRepository> repo = new Mock<IProductRepository>();
            repo.Setup(m => m.Products).Returns(new List<Product>()
            {
                new Product()
                    {
                        ProductID=0,
                        P_Name = "Test",
                        P_Price = 3,
                        Description = "this is a test",
                        CategoryID=1
                    }
            });
            ProductsController p = new ProductsController(repo.Object);
            IList<ProductDTO> res=p.GetProducts().ToList();

            Assert.That(res.Count, Is.EqualTo(1));
            Assert.That(res.Any(pd => pd.P_Name.Equals("Test") && pd.P_Price == 3));
            
        }

        [TestCase(1)]
        public void can_get_product_by_id(int id)
        {
            Mock<IProductRepository> repo = new Mock<IProductRepository>();
            repo
                .Setup(m => m.GetProductById(id))
                .Returns(
                               new Product()
                               {
                                   ProductID = 1,
                                   P_Name = "Test",
                                   P_Price = 3,
                                   Description = "this is a test",
                                   CategoryID = 1,
                                   Label="Test",
                                   ImageData=null,
                                   ImageMimeType = null
                               }
                );
            ProductsController pc = new ProductsController(repo.Object);
            pc.Request = new HttpRequestMessage();
            pc.Configuration = new HttpConfiguration();
            HttpResponseMessage hrm = pc.GetProduct(id);
            ProductDTO pdto;

            repo.Verify(y => y.GetProductById(It.IsAny<int>()));
            Assert.IsTrue(hrm.TryGetContentValue<ProductDTO>(out pdto));
            Assert.That(pdto.NoOfComments == 3);
            Assert.That(pdto.Rating == 2.6666666666666665);

        }

        [TestCase(1000)]
        public void get_no_product_should_throw_error(int id)
        {
            var repo = new Mock<IProductRepository>();
            repo.Setup(m => m.GetProductById(id)).Returns((Product)null);
            ProductsController pc = new ProductsController(repo.Object);
            pc.Request = new HttpRequestMessage();
            pc.Configuration = new HttpConfiguration();
            HttpResponseMessage hrm = pc.GetProduct(id);
            ProductDTO pdto;
            HttpError error;

            repo.Verify(y => y.GetProductById(It.IsAny<int>()));
            Assert.That(hrm.TryGetContentValue<ProductDTO>(out pdto),Is.False);
            Assert.That(hrm.TryGetContentValue<HttpError>(out error), Is.True);
            repo.Verify(y => y.GetProductById(It.IsAny<int>()));
            Assert.That(hrm.IsSuccessStatusCode, Is.False);
            Assert.That(error.Count, Is.EqualTo(3));
            Assert.That(error["message"].Equals("No such date item"),Is.True);
            //Assert.That(hrm.Content)
        }

        [Test]
        public void get_products_by_category_id()
        {
            //arrange
            var repo = new Mock<IProductRepository>();
            repo.Setup(m => m.GetProductsByCatID(1)).Returns(new List<Product>()
            {
                               new Product()
                               {
                                   ProductID = 1,
                                   P_Name = "Pear juice",
                                   P_Price = 3,
                                   Description = "this is a Pear Juice",
                                   CategoryID = 1,
                                   Label="Summer",
                                   ImageData=null,
                                   ImageMimeType = null
                               },
                               new Product()
                               {
                                   ProductID = 2,
                                   P_Name = "Apple Juice",
                                   P_Price = 3,
                                   Description = "this is a Apple Juice",
                                   CategoryID = 1,
                                   Label="Hot",
                                   ImageData=null,
                                   ImageMimeType = null
                               }
            });
            ProductsController pc = new ProductsController(repo.Object);


            //act
            pc.Request = new HttpRequestMessage();
            pc.Configuration = new HttpConfiguration();
            HttpResponseMessage hrm = pc.GetProducts(1);
            IList<ProductDTO> pdtos;

            //assert
            repo.Verify(y => y.GetProductsByCatID(It.IsAny<int>()));
            Assert.That(hrm.TryGetContentValue<IList<ProductDTO>>(out pdtos), Is.True);
            Assert.That(pdtos.Count, Is.EqualTo(2));
        }

    
        [Test]
        public void can_post_comment_to_product()
        {
            //arrange
            var repo = new Mock<IProductRepository>();
            repo.Setup(m => m.AddCommentAsync(new Comment())).ReturnsAsync(1);

            //act
            ProductsController pc = new ProductsController(repo.Object);
            pc.Request = new HttpRequestMessage();
            pc.Configuration = new HttpConfiguration();
            HttpResponseMessage hrm = pc.PostComment(new CommentDTO()
            {
                CommentID=3,
                ProductID=1,
                Rating=2,
                CommentText="this is new comment",
                CommentTime=DateTime.Now,
                Author="Zhao"
            });

            //assert
            string message;
            repo.Verify(y => y.AddCommentAsync(It.IsAny<Comment>()));
            Assert.That(hrm.TryGetContentValue<string>(out message), Is.True);
            Assert.That(message, Is.EqualTo("Save successful for comment"));

        }

    }
}
