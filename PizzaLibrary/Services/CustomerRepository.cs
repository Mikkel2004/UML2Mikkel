using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, ICustomer> _customers;

        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }
        public int Count { get; set; }

        public void AddCustomer(ICustomer customer)
        {
            if (GetCustomerByMobile( customer.Mobile) == null)
            {
                _customers.Add(customer.Mobile, customer);
            }
        }

        public List<ICustomer> GetAll()
        {
            List<ICustomer> getList = new List<ICustomer>();
            foreach(ICustomer x in _customers.Values)
            {
                getList.Add(x);
            }
            return getList;
        }

        public ICustomer GetCustomerByMobile(string mobile)
        {
            if (_customers.ContainsKey(mobile))
            {
                return _customers[mobile];
            }
            return null;
        }

        public void PrintAllCustomers()
        {
            foreach(ICustomer c in _customers.Values)
            {
                Console.WriteLine($"ID {c.Id} Name {c.Name} Mobile {c.Mobile} Address {c.Address} is a Clubmember {c.ClubMember}");
                Console.WriteLine();
            }
            
        }

        public void RemoveCustomer(string mobile)
        {
            if (_customers.ContainsKey(mobile))
            {
                _customers.Remove(mobile);
            }
        }

        public void FindAllClubmembers()
        {
            foreach (ICustomer c in _customers.Values)
            {
                if (c.ClubMember == true)
                {
                    Console.WriteLine($"ID {c.Id} Name {c.Name} is a clubmember");
                }
                
            }
        }

        public void FindAllFromRoskilde()
        {
            foreach (ICustomer c in _customers.Values)
            {
                if (c.Address.Contains("Roskilde"))
                {
                    Console.WriteLine($"ID {c.Id} Name {c.Name} Lives in Roskilde");
                }

            }
        }

    }
}
