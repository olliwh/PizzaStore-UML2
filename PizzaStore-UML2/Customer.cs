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
        private List<Order> _orders;


        public Customer(string name, string mail, int phoneNumber)
        {
            _name = name;
            _mail = mail;
            _phoneNumber = phoneNumber;
            _orders = new List<Order>();

            
        }
        public List<Order> Orders { get { return _orders; } set { _orders = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
        public int PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        public void PrintOrder()
        {
            if (_orders.Count == 0) Console.WriteLine("They have no orders");
            else
            {
                foreach(var order in _orders)
                {
                    order.PrintOrder();
                }
            }
        }
        public override string ToString()
        {
            return $"{_name}, mail: {_mail}, phone: {_phoneNumber}.";
        }
    }
}
