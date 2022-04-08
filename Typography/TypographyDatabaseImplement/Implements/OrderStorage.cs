﻿using Microsoft.EntityFrameworkCore;
using TypographyDatabaseImplement.Models;
using TypographyContracts.BindingModels;
using TypographyContracts.StoragesContracts;
using TypographyContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TypographyDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new TypographyDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Printed)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        PrintedId = rec.PrintedId,
                        PrintedName = rec.Printed.PrintedName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                    .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TypographyDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Printed)
                    .Where(rec => rec.PrintedId == model.PrintedId)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        PrintedId = rec.PrintedId,
                        PrintedName = rec.Printed.PrintedName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                    .ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TypographyDatabase())
            {
                Order order = context.Orders.Include(rec => rec.Printed).FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    PrintedId = order.PrintedId,
                    PrintedName = order.Printed.PrintedName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new TypographyDatabase())
            {
                var order = new Order
                {
                    PrintedId = model.PrintedId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new TypographyDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Элемент не найден");
                }
                order.PrintedId = model.PrintedId;
                order.Count = model.Count;
                order.Sum = model.Sum;
                order.Status = model.Status;
                order.DateCreate = model.DateCreate;
                order.DateImplement = model.DateImplement;

                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new TypographyDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TypographyDatabase())
            {
                Printed printed = context.Printeds.FirstOrDefault(rec => rec.Id == model.PrintedId);
                if (printed != null)
                {
                    if (printed.Orders == null)
                    {
                        printed.Orders = new List<Order>();
                    }

                    printed.Orders.Add(order);
                    context.Printeds.Update(printed);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}