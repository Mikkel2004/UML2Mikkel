using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        private int _no;
        private static int counter = 0;
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
            No = counter++;
        }

        public string Description { get; set ; }
        public string Name { get; set; }

        public int No
        {
            get { return _no; }
            set { _no = value; }
        }

        public double Price { get; set; }
        public MenuType TheMenuType { get; set; }

        public override string ToString()
        {
            return $"Number {_no} Name {Name} Description {Description} Price {Price} is member {TheMenuType}";
        }
    }
}
