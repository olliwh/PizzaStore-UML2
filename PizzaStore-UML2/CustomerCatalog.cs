using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class CustomerCatalog
    {
        private List<Customer> _customerList;
        private Customer _customer;
        public CustomerCatalog()
        {
            _customerList = new List<Customer>();
        }

        public Customer Create(string name, string mail, int phone)
        {
            _customer = new Customer(name, mail, phone);
            _customerList.Add(_customer);
            return _customer;
        }
        public void Delete(Customer customer)
        {
            _customerList.Remove(customer);
        }
        public void Update(Customer customer, string name, string mail, int phone)
        {
            customer.Name = name;
            customer.Mail = mail;
            customer.PhoneNumber = phone;
        }
        public Customer Search(string name)
        {
            Customer customerToFind = _customerList.Find(x => x.Name == name);
            return customerToFind;
        }
    }
}
