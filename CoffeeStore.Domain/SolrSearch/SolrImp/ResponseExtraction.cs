using CoffeeStore.Domain.SolrSearch.Model;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.SolrSearch.SolrImp
{
    internal class ResponseExtraction
    {
        //Extract parts of the SolrNet response and set them in QueryResponse class
        internal void SetHeader(SolrProductQueryResponse queryResponse, SolrQueryResults<SolrProduct> solrResults)
        {
            queryResponse.QueryTime = solrResults.Header.QTime;
            queryResponse.Status = solrResults.Header.Status;
            queryResponse.TotalHits = solrResults.NumFound;
        }

        internal void SetBody(SolrProductQueryResponse queryResponse, SolrQueryResults<SolrProduct> solrResults)
        {
            queryResponse.Results = (List<SolrProduct>)solrResults;
        }
    }
}
