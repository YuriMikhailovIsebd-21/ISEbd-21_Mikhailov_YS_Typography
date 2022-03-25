using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypographyContracts.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int PrintedId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
