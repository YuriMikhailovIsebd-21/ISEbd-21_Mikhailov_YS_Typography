using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypographyContracts.BindingModels;
using TypographyContracts.StoragesContracts;
using TypographyContracts.ViewModels;
using TypographyListImplement.Models;

namespace TypographyListImplement.Implements
{
    public class PrintedStorage : IPrintedStorage
    {
        private readonly DataListSingleton source;

        public PrintedStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PrintedViewModel> GetFullList()
        {
            var result = new List<PrintedViewModel>();
            foreach (var component in source.Printeds)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<PrintedViewModel> GetFilteredList(PrintedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<PrintedViewModel>();
            foreach (var printed in source.Printeds)
            {
                if (printed.PrintedName.Contains(model.PrintedName))
                {
                    result.Add(CreateModel(printed));
                }
            }
            return result;
        }
        public PrintedViewModel GetElement(PrintedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var Printed in source.Printeds)
            {
                if (Printed.Id == model.Id || Printed.PrintedName == model.PrintedName)
                {
                    return CreateModel(Printed);
                }
            }
            return null;
        }
        public void Insert(PrintedBindingModel model)
        {
            var tempPrinted = new Printed
            {
                Id = 1,
                PrintedComponents = new Dictionary<int, int>()
            };
            foreach (var printed in source.Printeds)
            {
                if (printed.Id >= tempPrinted.Id)
                {
                    tempPrinted.Id = printed.Id + 1;
                }
            }
            source.Printeds.Add(CreateModel(model, tempPrinted));
        }
        public void Update(PrintedBindingModel model)
        {
            Printed tempPrinted = null;
            foreach (var printed in source.Printeds)
            {
                if (printed.Id == model.Id)
                {
                    tempPrinted = printed;
                }
            }
            if (tempPrinted == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempPrinted);
        }
        public void Delete(PrintedBindingModel model)
        {
            for (int i = 0; i < source.Printeds.Count; ++i)
            {
                if (source.Printeds[i].Id == model.Id)
                {
                    source.Printeds.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Printed CreateModel(PrintedBindingModel model, Printed printed)
        {
            printed.PrintedName = model.PrintedName;
            printed.Price = model.Price;
            foreach (var key in printed.PrintedComponents.Keys.ToList())
            {
                if (!model.PrintedComponents.ContainsKey(key))
                {
                    printed.PrintedComponents.Remove(key);
                }
            }
            foreach (var component in model.PrintedComponents)
            {
                if (printed.PrintedComponents.ContainsKey(component.Key))
                {
                    printed.PrintedComponents[component.Key] = model.PrintedComponents[component.Key].Item2;
                }
                else
                {
                    printed.PrintedComponents.Add(component.Key, model.PrintedComponents[component.Key].Item2);
                }
            }
            return printed;
        }
        private PrintedViewModel CreateModel(Printed printed)
        {            
            var printedComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in printed.PrintedComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                printedComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new PrintedViewModel
            {
                Id = printed.Id,
                PrintedName = printed.PrintedName,
                Price = printed.Price,
                PrintedComponents = printedComponents
            };
        }
    }
}