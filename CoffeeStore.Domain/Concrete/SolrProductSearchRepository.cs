using CoffeeStore.Domain.SolrSearch.Model;
using CoffeeStore.Domain.SolrSearch.SolrImp;
using SolrNet;
using SolrNet.Commands.Parameters;


namespace CoffeeStore.Domain.Concrete
{
    public static class SolrProductSearchRepository //: ISolrProductSearchRepository
    {
        private static Connection connection;
        //the startup need to put in the method still not understand

        static SolrProductSearchRepository()
        {
            //Initialize connection
            //Connection can be initialized once and then retrieved via ServiceLocator.GetInstance
            //But we are creating it for every search library instantiation for demo purposes            
            connection = new Connection("http://localhost:8983/solr/coffeestoreproducts");
        }


        public static SolrProductQueryResponse DoSearch(SolrProductQuery query)
        {
            //Startup.Init<SolrProduct>();
            //Create an object to hold results
            SolrQueryResults<SolrProduct> solrResults;
            SolrProductQueryResponse queryResponse = new SolrProductQueryResponse();

            //Echo back the original query 
            queryResponse.OriginalQuery = query;

            //Get a connection
            ISolrOperations<SolrProduct> solr = connection.GetSolrInstance();
            QueryOptions queryOptions = new QueryOptions
            {
                Rows = query.Rows,
                //StartOrCursor = new StartOrCursor.Start(query.Start)
            };

            //Execute the query
            ISolrQuery solrQuery = new SolrQuery(query.Query);

            solrResults = solr.Query(solrQuery, queryOptions);

            //Set response
            ResponseExtraction extractResponse = new ResponseExtraction();

            extractResponse.SetHeader(queryResponse, solrResults);
            extractResponse.SetBody(queryResponse, solrResults);

            //Return response;
            return queryResponse;
        }


    }
}
