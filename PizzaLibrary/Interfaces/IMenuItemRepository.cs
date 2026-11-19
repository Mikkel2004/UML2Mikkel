using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Interfaces
{
    public interface IMenuItemRepository
    {
        int Count { get; }
        List<IMenuItem> GetAll();
        void AddMenuItem(IMenuItem menuItem);
        IMenuItem GetMenuItemByNo(int no);
        void RemoveMenuItem(int no);

        void PrintAllMenuItems();
        List<IMenuItem> ReturnChosenMenuTypeList(MenuType menuType);
        IMenuItem FindHighestChosenMenuTypePrice(MenuType menuType);

        IMenuItem FindHighestPrice();
        void MenuCard();
        void PrintMenuItemByType(string type, MenuType menuType);
    }
}
