using CoffeeStore.Domain.Abstract;
using CoffeeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeeStore.Controllers.api
{
    [RoutePrefix("api/translation")]
    public class TranslationController : ApiController
    {

        private ITranslationRepository repository;

        public TranslationController(ITranslationRepository translationRepository)
        {
            repository = translationRepository;
        }

        [HttpPost]
        public TranslationDTO GetTranslation(TranslationDTO translationRequest)
        {
            Dictionary<string, string> dicCusValue = null;
            if (translationRequest != null && !String.IsNullOrEmpty(translationRequest.CultureKey))
            {
                dicCusValue = repository.GetAllCustomizeTranslationValues(translationRequest.CultureKey);
            }
            Dictionary<string, string> dic = repository.GetAllTranslationValues();
            translationRequest.Values.ToList().ForEach(value =>
            {
                if (dic.ContainsKey(value.Key))
                {
                    value.Value = dic[value.Key];
                    if (dicCusValue != null)
                        value.CustomValue = dicCusValue[value.Key];
                }
            });
            return translationRequest;
        }

        [HttpGet]
        public TranslationDTO GetTranslationByDefault()
        {
            Dictionary<string, string> dic = repository.GetAllTranslationValues();
            TranslationDTO translationDTO = new TranslationDTO();
            foreach (KeyValuePair<string, string> kvp in dic)
            {
                translationDTO.Values.Add(new TranslationKeyValueDTO { Key = kvp.Key, Value = kvp.Value });
            }
            return translationDTO;
        }

    }
}
