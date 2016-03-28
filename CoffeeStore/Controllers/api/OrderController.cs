using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public Order GetOrder(int orderId)
        {
            return repository.GetOrderDetailById(orderId);
        }

    }
}
