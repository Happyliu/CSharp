using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using CoffeeStore.Domain.SolrSearch.Model;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class BuildSolrIndexRepository : IBuildSolrIndexRepository
    {
        private IProductRepository productrepository;

        public BuildSolrIndexRepository()
        {
            productrepository = new ProductRepository();
        }

        public void BuildAllProductSolrIndex()
        {
            //Change alpharetta to either localhost or your machine name
            Startup.Init<SolrProduct>("http://localhost:8983/solr/coffeestoreproducts");

            ISolrOperations<SolrProduct> solr = ServiceLocator.Current.GetInstance<ISolrOperations<SolrProduct>>();

            //Show Solr Admin UI and then delete all
            solr.Delete(SolrQuery.All); //Equivalent to "*:*"
            List<Product> productlist = productrepository.GetProductsWithComments().ToList<Product>();
            List<SolrProduct> solrproducts = GetSolrProducts(productlist);
            solr.AddRange(solrproducts);
            solr.Commit();
        }

        public void BuildProductSolrIndex(List<SolrProduct> solrProducts)
        {

        }

        public List<SolrProduct> GetSolrProducts(List<Product> products)
        {
            List<SolrProduct> solrProducts = new List<SolrProduct>();
            solrProducts = Helper(products);
            return solrProducts;
        }

        public List<SolrProduct> Helper(List<Product> products)
        {
            List<SolrProduct> solrProducts = new List<SolrProduct>();
            foreach (Product product in products)
            {
                SolrProduct solrproduct = new SolrProduct();
                solrproduct.ProductID = product.ProductID;
                solrproduct.CategoryName = product.ProductID == 1 ? "food" : "drink";
                solrproduct.ProductName = product.P_Name;
                solrproduct.Price = (float)product.P_Price;
                solrproduct.Label = product.Label;
                solrproduct.Description = product.Description;
                List<Comment> comlists = product.Comments.ToList<Comment>();
                solrproduct.Comments = comlists.Select(x => x.CommentText).ToList();
                string searchkey = product.SearchKey;
                if (!string.IsNullOrEmpty(searchkey))
                {
                    string[] splitsearchkeys = searchkey.Split('#');
                    solrproduct.SearchKey = splitsearchkeys.Cast<string>().ToList();
                }
                else
                {
                    solrproduct.SearchKey = new string[] { "empty" }.ToList();
                }
                solrproduct.Rating = 0;//(float)comlists.Average(x => x.Rating);
                solrProducts.Add(solrproduct);
            }
            return solrProducts;
        }

    }
}
