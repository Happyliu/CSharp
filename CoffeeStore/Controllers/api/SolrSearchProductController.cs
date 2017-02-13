using CoffeeStore.Domain.Concrete;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Domain.SolrSearch.Model;
using CoffeeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeeStore.Controllers.api
{
    public class SolrSearchProductController : ApiController
    {
        private BuildSolrIndexRepository repository = new BuildSolrIndexRepository();

        [HttpPost]
        public IEnumerable<Product> GetProducts(SolrProductQuery model)
        {
            SolrProductQueryResponse response = SolrProductSearchRepository.DoSearch(model);
            SolrProductResponseModal result = DataHelper.FormatSolrProductResponse(response);
            return result.Results;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            SolrProductQuery model = new SolrProductQuery();
            model.Query = "*";
            SolrProductQueryResponse response = SolrProductSearchRepository.DoSearch(model);
            SolrProductResponseModal result = DataHelper.FormatSolrProductResponse(response);
            return result.Results;
        }
    }
}
