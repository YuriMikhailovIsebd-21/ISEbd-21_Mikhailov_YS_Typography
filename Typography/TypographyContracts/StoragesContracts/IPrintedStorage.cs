using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypographyContracts.BindingModels;
using TypographyContracts.ViewModels;

namespace TypographyContracts.StoragesContracts
{
    public interface IPrintedStorage
    {
        List<PrintedViewModel> GetFullList();
        List<PrintedViewModel> GetFilteredList(PrintedBindingModel model);
        PrintedViewModel GetElement(PrintedBindingModel model);
        void Insert(PrintedBindingModel model);
        void Update(PrintedBindingModel model);
        void Delete(PrintedBindingModel model);
    }

}
