using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TypographyContracts.ViewModels
{
    public class PrintedViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string PrintedName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }

}
