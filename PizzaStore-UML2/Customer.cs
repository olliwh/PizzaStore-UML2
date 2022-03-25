using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
   public  class Customer
    {
        private string _name;
        private string _mail;
        private int _phoneNumber;

        public Customer(string name, string mail, int phoneNumber)
        {
            _name = name;
            _mail = mail;
            _phoneNumber = phoneNumber;
        }
        public string Name { get { return _name; } set { _name = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public int PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        //proberly make new class callad customer catalog
        public override string ToString()
        {
            return $"{_name}, mail: {_mail}, phone: {_phoneNumber}.";
        }
    }
}
