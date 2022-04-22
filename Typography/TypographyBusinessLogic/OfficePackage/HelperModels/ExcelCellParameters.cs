﻿using TypographyBusinessLogic.OfficePackage.HelperEnums;

namespace TypographyBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelCellParameters
    {
        public string ColumnName { get; set; }

        public uint RowIndex { get; set; }

        public string Text { get; set; }

        public string CellReference => $"{ColumnName}{RowIndex}";

        public ExcelStyleInfoType StyleInfo { get; set; }
    }
}