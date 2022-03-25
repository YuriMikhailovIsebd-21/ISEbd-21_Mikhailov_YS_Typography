using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;

namespace TypographyContracts.BusinessLogicsContracts
{
    public interface IPrintedLogic
    {
        List<PrintedViewModel> Read(PrintedBindingModel model);
        void CreateOrUpdate(PrintedBindingModel model);
        void Delete(PrintedBindingModel model);
    }

}
