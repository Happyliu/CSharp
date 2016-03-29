using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {

        private IOrderRepository repository;

        public OrderController(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Order> GetOrder()
        {
            return repository.GetOrders();
        }

        [HttpGet]
        public OrderDTO GetOrder(int orderId)
        {
            return DataHelper.ChangeOrderToDTO(repository.GetOrderDetailById(orderId));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostOrder(OrderDTO order)
        {
            if (ModelState.IsValid)
            {
                await repository.PlaceOrder(DataHelper.ChangeOrderDTOToOrder(order));
                return Request.CreateResponse();
            }
            else
            {
                HttpError error = new HttpError(ModelState, false);
                error.Message = "Cannot Add Product";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOrder(int id)
        {
            if (ModelState.IsValid)
            {
                await repository.DeleteOrder(id);
                return Request.CreateResponse();
            }
            else
            {
                HttpError error = new HttpError(ModelState, false);
                error.Message = "Cannot Add Product";
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
            }
        }

        [HttpGet]
        [Route("customer/{customerId}")]
        public IList<OrderDTO> GetOrderDetailsByCustomerID(int customerId)
        {
            return DataHelper.ChangeOrderListToDTO(repository.GetOrderDetailsByCustomerID(customerId).ToList());
        }

    }
}
