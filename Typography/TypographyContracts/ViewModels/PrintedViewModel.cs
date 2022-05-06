﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TypographyContracts.ViewModels
{
    [DataContract]
    public class PrintedViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название изделия")]
        public string PrintedName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> PrintedComponents { get; set; }
    }
}
