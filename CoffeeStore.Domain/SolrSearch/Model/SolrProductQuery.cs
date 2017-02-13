using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.SolrSearch.Model
{
    public class SolrProductQuery
    {
        public SolrProductQuery()
        {
            Rows = 10;
            Start = 0;
        }

        //Query object that holds parameters sent to the search library
        public string Query { get; set; }

        public int Start { get; set; }

        public int Rows { get; set; }
    }
}
