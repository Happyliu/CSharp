using CoffeeStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeeStore.Controllers.api
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private ICustomerRepository repository;

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public int getCustomerByName([FromUri] string cusName)
        {
            return repository.GetCustomerId(cusName);
        }

        [HttpGet]
        [Route("culture")]
        public string getCustomerCulture([FromUri] string cusName)
        {
            return repository.GetCustomerCulture(cusName);
        }

    }
}
