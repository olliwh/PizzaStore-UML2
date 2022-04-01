using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class Topping
    {
        private string _name;
        public Topping(string name)
        {
            _name = name;
        }
        public string Name { get { return _name; } }
        public override string ToString()
        {
            return $"{_name}";
        }
    }
}
