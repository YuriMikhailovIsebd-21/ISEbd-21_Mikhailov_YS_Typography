﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypographyContracts.BindingModels;
using TypographyContracts.StoragesContracts;
using TypographyContracts.ViewModels;
using TypographyFileImplement.Models;

namespace TypographyFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;

        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(CreateModel).ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return source.Orders.Where(rec => rec.Id == model.Id).Select(CreateModel).ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            var order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            var order = new Order { Id = maxId + 1, DateCreate = DateTime.Now };
            source.Orders.Add(CreateModel(model, order));
        }
        public void Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            CreateModel(model, order);
        }
        public void Delete(OrderBindingModel model)
        {
            Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PrintedId = model.PrintedId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                PrintedId = order.PrintedId,
                PrintedName = source.Printeds.FirstOrDefault(printed => printed.Id == order.PrintedId)?.PrintedName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
}
