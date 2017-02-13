using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class SolrProductResponseModal
    {

        public List<Product> Results { get; set; }

        public int TotalHits { get; set; }

    }
}