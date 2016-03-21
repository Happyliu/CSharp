using CoffeeStore.Domain.Abstract;
using CoffeeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoffeeStore.Controllers.api
{
    [RoutePrefix("api/comment")]
    public class CommentController : ApiController
    {

        private ICommentRepository repository;

        public CommentController(ICommentRepository commentRepository)
        {
            repository = commentRepository;
        }

        public IEnumerable<CommentDTO> GetAllComments()
        {
            return DataHelper.ChangeCommentListToDTO(repository.Comments().ToList());
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostComment(CommentDTO commentDTO)
        {
            if (ModelState.IsValid)
            {
                await repository.SaveCommentAsync(DataHelper.ChangeCommentDTOToComment(commentDTO));
                return Request.CreateResponse();
            }
            else
            {
                HttpError error = new HttpError(ModelState, false);
                error.Message = "Cannot Add Product";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
        }

        [Route("product/{id}")]
        public HttpResponseMessage GetComment(int id)
        {

            return Request.CreateResponse(DataHelper.ChangeCommentListToDTO(repository.GetCommentsByProductID(id).ToList()));

        }
    }
}
