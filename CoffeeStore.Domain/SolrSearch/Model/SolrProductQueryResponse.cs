using CoffeeStore.Domain.SolrSearch.Model;
using System.Collections.Generic;


namespace CoffeeStore.Domain.SolrSearch.Model
{
    public class SolrProductQueryResponse
    {
        public SolrProductQueryResponse()
        {
            //Initialize properties
        }

        //Expose properties that will be returned to from the search library
        public List<SolrProduct> Results { get; set; }

        public int TotalHits { get; set; }

        public int QueryTime { get; set; }

        public int Status { get; set; }

        public SolrProductQuery OriginalQuery { get; set; }

    }
}
