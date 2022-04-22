using System;
using System.Collections.Generic;

namespace TypographyContracts.ViewModels
{
    public class ReportPrintedComponentViewModel
    {
        public string PrintedName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; }
    }
}
