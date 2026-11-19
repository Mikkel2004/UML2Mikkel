using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {

        private List<IMenuItem> _menuItemList;

        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;
        }
        public int Count { get; set; }

        public void AddMenuItem(IMenuItem menuItem)
        {
            if(GetMenuItemByNo(menuItem.No) == null)
            {
                _menuItemList.Add(menuItem);
            }
        }

        public List<IMenuItem> GetAll()
        {
            List<IMenuItem> getList = new List<IMenuItem>();
            foreach (IMenuItem x in _menuItemList)
            {
                getList.Add(x);
            }
            return getList;
        }

        public IMenuItem GetMenuItemByNo(int no)
        {
            foreach(IMenuItem m in _menuItemList)
            {
                if(m.No == no)
                {
                    return m;
                }
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (IMenuItem c in _menuItemList)
            {
                Console.WriteLine($"Number {c.No} Name {c.Name} Description {c.Description} Price {c.Price} the menu {c.TheMenuType}");
                Console.WriteLine();
            }
        }

        public void RemoveMenuItem(int no)
        {
            IMenuItem? orderToBeRemoved = GetMenuItemByNo(no);
            if(orderToBeRemoved != null)
            {
                _menuItemList.Remove(orderToBeRemoved);
            }
        }

        public List<IMenuItem> ReturnChosenMenuTypeList(MenuType menuType)
        {
            List<IMenuItem> returnList = new List<IMenuItem>();
            foreach(IMenuItem i in _menuItemList)
            {
                if(i.TheMenuType == menuType)
                {
                    returnList.Add(i);
                }
            }
            return returnList;
        }

        public IMenuItem FindHighestChosenMenuTypePrice(MenuType menuType)
        {
            List<IMenuItem> typeList = ReturnChosenMenuTypeList(menuType);
            IMenuItem highestPrice = _menuItemList[0];

            double Max1 = 0;

            foreach (IMenuItem m in typeList)
            {
                for (int i = 0; i < _menuItemList.Count; i++)
                {
                    if (m.Price > Max1)
                    {
                        Max1 = m.Price;
                    }
                    if(Max1 == m.Price)
                    {
                        highestPrice.Price = Max1;

                        highestPrice.Name = m.Name;
                    }
                }
            }
            return highestPrice;

        }

        public IMenuItem FindHighestPrice()
        {
            IMenuItem HPrice = _menuItemList[0];
            double Max1 = 0;
            foreach(IMenuItem m in _menuItemList)
            {
                if (m.Price > Max1)
                {
                    Max1 = m.Price;
                }
                if (Max1 == m.Price)
                {
                    HPrice.Price = Max1;
                    HPrice.Name = m.Name;
                }
            }
            return HPrice;

        }

        public void MenuCard()
        {
            Console.WriteLine("--------------- Big Mamma's Pizzaria ---------------");
            PrintMenuItemByType("Pizza", MenuType.PIZZECLASSSICHE);
            PrintMenuItemByType("Special Pizza", MenuType.PIZZASPECIALI);
            PrintMenuItemByType("Pasta", MenuType.PASTAALFORNO);
            PrintMenuItemByType("Bruchetta", MenuType.BRUCHETTA_CROSTINO);
            PrintMenuItemByType("Salater", MenuType.SALATER);
            PrintMenuItemByType("Sandwiches", MenuType.SANDWICHES);
            PrintMenuItemByType("Tilbehør", MenuType.TILBEHØR);
            Console.WriteLine("-----------------------------------------------------");
        }

        public void PrintMenuItemByType(string type, MenuType menuType)
        {
            List<IMenuItem> list = ReturnChosenMenuTypeList(menuType);
            Console.WriteLine();
            Console.WriteLine($"{type}:");
            Console.WriteLine();
            foreach(IMenuItem p in list)
            {
                Console.WriteLine($"{p.No} * {p.Name} - {p.Description} ....... {p.Price}kr");
            }
        }
    }

}
