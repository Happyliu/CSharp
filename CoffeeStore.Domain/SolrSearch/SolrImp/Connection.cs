using CoffeeStore.Domain.SolrSearch.Model;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.SolrSearch.SolrImp
{
    public class Connection
    {
        //Initialize the connection and provide it to the search library
        public Connection(string url)
        {
            InitializeConnection(url);
        }

        private void InitializeConnection(string url)
        {
            Startup.Init<SolrProduct>(url);
        }

        internal ISolrOperations<SolrProduct> GetSolrInstance()
        {
            return ServiceLocator.Current.GetInstance<ISolrOperations<SolrProduct>>();
        }

    }
}
