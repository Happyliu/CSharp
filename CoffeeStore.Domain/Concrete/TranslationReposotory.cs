using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class TranslationRepository : ITranslationRepository
    {
        private EFDbContext context = new EFDbContext();

        public Dictionary<string, string> GetAllTranslationValues()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            context.TranslationDefinitions.ToList().ForEach(translationdefinition => {
                if (!dic.ContainsKey(translationdefinition.TranslationDefinitionKey))
                {
                    dic.Add(translationdefinition.TranslationDefinitionKey, translationdefinition.Value);
                }
            });
            return dic;
        }

        public Dictionary<string, string> GetAllCustomizeTranslationValues(string cultureKey)
        {
            bool hasKey = context.Cultures.ToList().Any(culture => culture.Code.Equals(cultureKey));
            if (hasKey)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                List<Translation> tlist = context.Translations.Where(trans => trans.CultureCode.Equals(cultureKey)).ToList();
                tlist.ForEach(x =>
                {
                    TranslationDefinition dbEntey = context.TranslationDefinitions.Where(y => y.TranslationDefinitionID == x.TranslationDefinitionID).SingleOrDefault();
                    if (dbEntey != null && !dic.ContainsKey(dbEntey.TranslationDefinitionKey))
                    {
                        dic.Add(dbEntey.TranslationDefinitionKey, x.Value);
                    }
                });
                return dic;
            }
            else
            {
                return null;
            }
        }

    }
}
