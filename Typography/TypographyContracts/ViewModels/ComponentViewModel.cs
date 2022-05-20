using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TypographyContracts.Attributes;

namespace TypographyContracts.ViewModels
{
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Компонент", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
