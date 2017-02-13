using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.SolrSearch.Model
{
    public class SolrProduct
    {
        [SolrField("productid")]
        public int ProductID { get; set; }

        [SolrField("categoryname")]
        public string CategoryName { get; set; }

        [SolrField("productname")]
        public string ProductName { get; set; }

        [SolrField("price")]
        public float Price { get; set; }

        [SolrField("label")]
        public string Label { get; set; }

        [SolrField("description")]
        public string Description { get; set; }

        [SolrField("searchkey")]
        public List<string> SearchKey { get; set; }

        [SolrField("comments")]
        public List<string> Comments { get; set; }

        [SolrField("rating")]
        public float Rating { get; set; }

    }
}
