using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        private int _id;
        private static int counter=0;
        public Customer(string name, string mobile, string address, bool clubMember)
        {
            Id = counter++;
            Address = address;
            ClubMember = clubMember;
            Mobile = mobile;
            Name = name;
        }

        public string Address { get; set; }
        public bool ClubMember { get; set; }

        public int Id 
        { 
            get { return _id; } 
            set { _id = value; }
        }

        public string Mobile { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id {_id} Name {Name} Mobile {Mobile} Address {Address} is member {ClubMember}";
        }
    }
}
