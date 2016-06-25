using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class TranslationDefinition
    {
        public int TranslationDefinitionID { get; set; }
        public string TranslationDefinitionKey { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ConfigurationCategoryID { get; set; }
    }
}
