using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypographyContracts.BindingModels
{
    public class PrintedBindingModel
    {
        public int? Id { get; set; }
        public string PrintedName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }

}
