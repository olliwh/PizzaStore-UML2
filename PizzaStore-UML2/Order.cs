using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class Order
    {
        private int _id;
        private List<Pizza> _pizzas;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _pizzas = new List<Pizza>();

        }
        public List<Pizza> Pizzas { get { return _pizzas; } }
        public Customer OrderCustomer { get { return _customer; } set { _customer = value; } }
        public int ID { get { return _id; } set { _id = value; } }
        public void GetOrder()
        {
            Console.WriteLine($"Order ID: {_id}. Customer {_customer.Name}: ");
            foreach(var pizza in _pizzas)
            {
                pizza.GetPizza();
            }
            Console.WriteLine();
        }
    }
}
