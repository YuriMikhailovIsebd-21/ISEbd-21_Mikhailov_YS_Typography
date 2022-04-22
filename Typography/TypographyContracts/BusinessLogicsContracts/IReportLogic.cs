using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;
using System.Collections.Generic;


namespace TypographyContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        List<ReportPrintedComponentViewModel> GetPrintedComponent();

        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        void SavePrintedsToWordFile(ReportBindingModel model);

        void SavePrintedComponentToExcelFile(ReportBindingModel model);

        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
