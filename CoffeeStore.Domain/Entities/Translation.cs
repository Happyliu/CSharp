using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class Translation
    {
        public int TranslationID { get; set; }
        public int TranslationDefinitionID { get; set; }
        public string ObjectType { get; set; }
        public string PropertyName { get; set; }
        public string CultureCode { get; set; }
        public string Value { get; set; }
        public TranslationDefinition TranslationDefinition { get; set; }
    }
}
