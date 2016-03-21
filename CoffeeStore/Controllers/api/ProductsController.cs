using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public IEnumerable<ProductDTO> GetProducts()
        {
            return DataHelper.ChangeProductEntityToDTO(repository.Products.ToList());
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
            return Request.CreateResponse(DataHelper.ChangeProductEntityToDTO(product));
        }

        [Route("category/{id}")]
        public IHttpActionResult GetProducts(int id)
        {
            if (id < 0 || id > 2)
                return BadRequest("No such category");
            return Ok(DataHelper.ChangeProductEntityToDTO(repository.GetProductsByCatID(id).ToList()));
        }

        public IEnumerable<ProductDTO> GetProductsByPriceRange(int min, int max)
        {
            return DataHelper.ChangeProductEntityToDTO(repository.GetProductByPriceRange(min, max).ToList());
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

        [Route("Image/{productId}")]
        public HttpResponseMessage GetImage(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            var response = Request.CreateResponse();
            using (var ms = new System.IO.MemoryStream(product.ImageData))
            {
                using (var img = Image.FromStream(ms))
                {
                    response.Content = new ByteArrayContent(ms.ToArray());
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(product.ImageMimeType);
                }
            }
            return response;
        }


        [HttpPost]
        [Route("addcomment")]
        public async Task<HttpResponseMessage> PostComment(CommentDTO comment)
        {
            if (comment != null)
            {
                Comment comment1 = DataHelper.ChangeCommentDTOToComment(comment);
                await repository.AddCommentAsync(comment1);
                return Request.CreateResponse("");
            }
            else
            {
                HttpError error = new HttpError(ModelState, false);
                error.Message = "Cannot Add Comment";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
        }

    }
}
