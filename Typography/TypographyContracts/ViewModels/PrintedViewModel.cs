using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using TypographyContracts.Attributes;

namespace TypographyContracts.ViewModels
{
    [DataContract]
    public class PrintedViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("Название изделия")]
        public string PrintedName { get; set; }

        [Column(title: "Цена", width: 50)]
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }
}
