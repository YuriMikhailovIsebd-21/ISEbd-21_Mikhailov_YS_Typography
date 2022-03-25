using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypographyContracts.BindingModels;
using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.StoragesContracts;
using TypographyContracts.ViewModels;

namespace TypographyBusinessLogic.BusinessLogics
{
    public class ComponentLogic : IComponentLogic
    {
        private readonly IComponentStorage componentStorage;

        public ComponentLogic(IComponentStorage componentStorage)
        {
            this.componentStorage = componentStorage;
        }

        public List<ComponentViewModel> Read(ComponentBindingModel model)
        {
            if (model == null)
            {
                return componentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ComponentViewModel> { componentStorage.GetElement(model) };
            }
            return componentStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ComponentBindingModel model)
        {
            var element = componentStorage.GetElement(new ComponentBindingModel
            { ComponentName = model.ComponentName });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                componentStorage.Update(model);
            }
            else
            {
                componentStorage.Insert(model);
            }
        }

        public void Delete(ComponentBindingModel model)
        {
            var element = componentStorage.GetElement(new ComponentBindingModel
            { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            componentStorage.Delete(model);
        }
    }
}
