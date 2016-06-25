using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Abstract
{
    public interface ITranslationRepository
    {
        Dictionary<string, string> GetAllTranslationValues();
        Dictionary<string, string> GetAllCustomizeTranslationValues(string cultureKey);
    }
}
