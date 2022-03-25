﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using TypographyContracts.Enums;
using TypographyFileImplement.Models;

namespace TypographyFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;

        private readonly string ComponentFileName = "Component.xml";

        private readonly string OrderFileName = "Order.xml";

        private readonly string PrintedFileName = "Printed.xml";

        public List<Component> Components { get; set; }

        public List<Order> Orders { get; set; }

        public List<Printed> Printeds { get; set; }

        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Printeds = LoadPrinteds();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SavePrinteds();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                var xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();

            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);

                var xElements = xDocument.Root.Elements("Order").ToList();

                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedId = Convert.ToInt32(elem.Element("PrintedId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Convert.ToInt32(elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = !string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? Convert.ToDateTime(elem.Element("DateImplement").Value) : DateTime.MinValue
                    });
                }
            }
            return list;
        }
        private List<Printed> LoadPrinteds()
        {
            var list = new List<Printed>();
            if (File.Exists(PrintedFileName))
            {
                var xDocument = XDocument.Load(PrintedFileName);

                var xElements = xDocument.Root.Elements("Printed").ToList();

                foreach (var elem in xElements)
                {
                    var printedComponents = new Dictionary<int, int>();
                    foreach (var component in elem.Element("PrintedComponents").Elements("PrintedComponent").ToList())
                    {
                        printedComponents.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Printed
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PrintedName = elem.Element("PrintedName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PrintedComponents = printedComponents
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");

                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("PrintedId", order.PrintedId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", (int)order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SavePrinteds()
        {
            if (Printeds != null)
            {
                var xElement = new XElement("Printeds");
                foreach (var printed in Printeds)
                {
                    var compElement = new XElement("PrintedComponents");
                    foreach (var component in printed.PrintedComponents)
                    {
                        compElement.Add(new XElement("PrintedComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Printed",
                     new XAttribute("Id", printed.Id),
                     new XElement("PrintedName", printed.PrintedName),
                     new XElement("Price", printed.Price),
                     compElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(PrintedFileName);
            }
        }
        public static void Save()
        {
            instance.SaveOrders();
            instance.SavePrinteds();
            instance.SaveComponents();
        }
    }
}
