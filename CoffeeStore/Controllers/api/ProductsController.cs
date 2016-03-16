using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoffeeStore.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private IProductRepository repository;

        public ProductsController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return repository.Products;
        }

        public HttpResponseMessage GetProduct(int id)
        {
            Product product = repository.GetProductById(id);
            if (product == null)
            {
                HttpError error = new HttpError();
                error.Message = "No such date item";
                error.Add("RequestID", id);
                error.Add("AvailbelIDs", repository.Products.Select(x => x.ProductID));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
            return Request.CreateResponse(product);
        }

        [Route("category/{id}")]
        public IHttpActionResult GetProducts(int id)
        {
            if (id < 0 || id > 2)
                return BadRequest("No such category");
            return Ok(repository.GetProductsByCatID(id));
        }

        public IEnumerable<Product> GetProductsByPriceRange(int min, int max)
        {
            return repository.GetProductByPriceRange(min, max);
        }

        public async Task<HttpResponseMessage> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await repository.SaveProductAsync(product);
                return Request.CreateResponse();
            }
            else
            {
                HttpError error = new HttpError(ModelState, false);
                error.Message = "Cannot Add Product";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
        }

    }
}
