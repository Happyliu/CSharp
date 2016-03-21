using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoffeeStore.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository repository;
        public HomeController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            return View(repository.GetProductById(productId));
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.P_Name);
                return RedirectToAction("List");
            }
            else
            {
                return View("List");
            }

        }

        public ActionResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} has been deleted", deletedProduct.P_Name);
            }
            return RedirectToAction("List");
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


    }
}