using CoffeeStore.Domain.Concrete;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStoreUnitTest.DomainProjectUnitTests
{
    [TestFixture]
    public class TranslationRepositoryUnitTest
    {
        TranslationRepository repository = new TranslationRepository(new EFDbContext());

        [TestCase("en-US")]
        public void CanGetAllTranslationValues(string culturekey)
        {
            Dictionary<string, string> dic = repository.GetAllCustomizeTranslationValues(culturekey);
            Assert.That(dic.All(c => c.Value != null));
        }
    }
}
