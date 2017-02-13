using CoffeeStore.Domain.SolrSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Abstract
{
    public interface ISolrProductSearchRepository
    {
        SolrProductQueryResponse DoSearch(SolrProductQuery query);
    }
}
