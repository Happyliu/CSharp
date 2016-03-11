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

        public IEnumerable<Product> GetProducts(int id)
        {
            return repository.GetProductsByCatID(id);
        }

        public IEnumerable<Product> GetProductsByPriceRange(int min, int max)
        {
            return repository.GetProductByPriceRange(min, max);
        }

        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await repository.SaveProductAsync(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
