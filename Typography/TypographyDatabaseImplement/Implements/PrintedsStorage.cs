using Microsoft.EntityFrameworkCore;
using TypographyDatabaseImplement.Models;
using TypographyContracts.BindingModels;
using TypographyContracts.StoragesContracts;
using TypographyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TypographyDatabaseImplement.Implements
{
    public class PrintedsStorage : IPrintedStorage
    {
        public List<PrintedViewModel> GetFullList()
        {
            using (var context = new TypographyDatabase())
            {
                return context.Printeds
                    .Include(rec => rec.PrintedComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public List<PrintedViewModel> GetFilteredList(PrintedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TypographyDatabase())
            {
                return context.Printeds
                    .Include(rec => rec.PrintedComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.PrintedName.Contains(model.PrintedName))
                    .ToList()
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public PrintedViewModel GetElement(PrintedBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TypographyDatabase())
            {
                Printed printed = context.Printeds
                    .Include(rec => rec.PrintedComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.PrintedName == model.PrintedName || rec.Id == model.Id);

                return printed != null ? CreateModel(printed) : null;
            }
        }

        public void Insert(PrintedBindingModel model)
        {
            using (var context = new TypographyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var printed = new Printed
                        {
                            PrintedName = model.PrintedName,
                            Price = model.Price
                        };
                        context.Printeds.Add(printed);
                        context.SaveChanges();

                        CreateModel(model, printed, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(PrintedBindingModel model)
        {
            using (var context = new TypographyDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Printed printed = context.Printeds.FirstOrDefault(rec => rec.Id == model.Id);
                        if (printed == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        printed.PrintedName = model.PrintedName;
                        printed.Price = model.Price;

                        CreateModel(model, printed, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(PrintedBindingModel model)
        {
            using (var context = new TypographyDatabase())
            {
                Printed printed = context.Printeds.FirstOrDefault(rec => rec.Id == model.Id);
                if (printed != null)
                {
                    context.Printeds.Remove(printed);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private static Printed CreateModel(PrintedBindingModel model, Printed printed, TypographyDatabase context)
        {
            if (model.Id.HasValue)
            {
                var printedComponents = context.PrintedComponents.Where(rec => rec.PrintedId == model.Id.Value).ToList();
                context.PrintedComponents.RemoveRange(printedComponents.Where(rec => !model.PrintedComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                foreach (var updateComponent in printedComponents)
                {
                    updateComponent.Count = model.PrintedComponents[updateComponent.ComponentId].Item2;
                    model.PrintedComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }

            foreach (var pc in model.PrintedComponents)
            {
                context.PrintedComponents.Add(new PrintedComponent
                {
                    PrintedId = printed.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });

                context.SaveChanges();
            }

            return printed;
        }

        private static PrintedViewModel CreateModel(Printed printed)
        {
            return new PrintedViewModel
            {
                Id = printed.Id,
                PrintedName = printed.PrintedName,
                Price = printed.Price,
                PrintedComponents = printed.PrintedComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}
