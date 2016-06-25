using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Entities
{
    public class Culture
    {
        public int CultureID { get; set; }
        public string Code { get; set; }
        public int LCID { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string ParentCode { get; set; }
    }
}
