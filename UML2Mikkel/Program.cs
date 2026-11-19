using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

Console.WriteLine("Hello, World!");
MenuItem i1 = new MenuItem("Pizza1", 200, "Tomato and chesse", MenuType.BRUCHETTA_CROSTINO);
MenuItem i2 = new MenuItem("Pizza2", 30, "Tomato and chesse", MenuType.PASTAALFORNO);
MenuItem i3 = new MenuItem("Pizza3", 40, "Tomato and chesse", MenuType.SALATER);
MenuItem i4 = new MenuItem("Pizza4", 400, "Tomato and chesse", MenuType.SANDWICHES);
MenuItem i5 = new MenuItem("Pizza5", 400, "Tomato and chesse", MenuType.PIZZASPECIALI);
MenuItem i6 = new MenuItem("Pizza6", 200, "Tomato and chesse", MenuType.TILBEHØR);


IMenuItemRepository itemRepo = new MenuItemRepository();
itemRepo.AddMenuItem(i1);
itemRepo.AddMenuItem(i2);
itemRepo.AddMenuItem(i3);
itemRepo.AddMenuItem(i4);
itemRepo.AddMenuItem(i5);
itemRepo.AddMenuItem(i6);



Customer c1 = new Customer("Poul", "232323", "Gade 1232", true);
Customer c2 = new Customer("Mikkel", "252525", "Gade 2133", false);
Customer c3 = new Customer("Per", "242424", "Roskilde", true);
Customer c4 = new Customer("Kasper", "256625", "Gade 2133", false);

ICustomerRepository cusRepo = new CustomerRepository();
cusRepo.AddCustomer(c1);
cusRepo.AddCustomer(c2);
cusRepo.AddCustomer(c3);
cusRepo.AddCustomer(c4);

Console.WriteLine(cusRepo.GetCustomerByMobile("100000000"));

Console.WriteLine();

Console.WriteLine("Her tester jeg PrintAllCustomers");
cusRepo.PrintAllCustomers();
Console.WriteLine("Her tester jeg remove");
cusRepo.RemoveCustomer(c1.Mobile);

Console.WriteLine();
Console.WriteLine("---");

cusRepo.PrintAllCustomers();

Console.WriteLine("her tester jeg GetAll");
foreach (ICustomer c in cusRepo.GetAll())
{
    Console.WriteLine(c.ToString());
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("testing menuitem");
Console.WriteLine();

itemRepo.PrintAllMenuItems();

Console.WriteLine();
Console.WriteLine("testing remover");
itemRepo.RemoveMenuItem(i1.No);

itemRepo.PrintAllMenuItems();

Console.WriteLine("Testing to find all clubmembers");
cusRepo.FindAllClubmembers();

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Testing to find people in Roskilde");
cusRepo.FindAllFromRoskilde();

Console.WriteLine();
Console.WriteLine("Testing searching for menuItemType");
Console.WriteLine("-------");
List<IMenuItem> allSalad = itemRepo.ReturnChosenMenuTypeList(MenuType.SALATER);
foreach (IMenuItem c in allSalad)
{
    Console.WriteLine($"{c.Name} is a salad");
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("testing to find highest price in specifik type");
Console.WriteLine("-------");
IMenuItem hPrice = itemRepo.FindHighestChosenMenuTypePrice(MenuType.PIZZECLASSSICHE);
Console.WriteLine($"{hPrice.Name} has the highest price of that type");

Console.WriteLine();
Console.WriteLine("testing to find highest item price");
IMenuItem highestPrice = itemRepo.FindHighestPrice();
Console.WriteLine($"{highestPrice.Name} has the highest price");

Console.WriteLine();
Console.WriteLine("Testing the MenuCard");
Console.WriteLine("------");
itemRepo.MenuCard();