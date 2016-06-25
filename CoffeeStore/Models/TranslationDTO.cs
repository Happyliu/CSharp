using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Models
{
    public class TranslationDTO
    {
        public string CultureKey { get; set; }
        public IList<TranslationKeyValueDTO> Values { get; set; }

        public TranslationDTO()
        {
            CultureKey = "en-US";
            Values = new List<TranslationKeyValueDTO>();
        }
    }
}