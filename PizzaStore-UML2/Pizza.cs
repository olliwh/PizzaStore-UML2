using System;
using System.Collections.Generic;
using System.Text;


namespace PizzaStore_UML2
{
    public class Pizza
    {
        #region Instance Fields
        private int _number;
        private string _name;
        private int _price;
        private List<Topping> _toppings;
        #endregion

        #region Constructor
        public Pizza(int number,string name, int price)
        {
            _number = number;
            _name = name;
            _price = price;
            _toppings = new List<Topping>();
            Topping sauce = new Topping("Sause");
            Topping cheese = new Topping("Cheese");
            _toppings.Add(sauce);
            _toppings.Add(cheese);
        }
        #endregion

        #region Properties
        public int Number { get { return _number; } set { _number = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Price { get { return _price; } set { _price = value; } }

        public List<Topping> Toppings {  get { return _toppings; } }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{_name}, {_price:C}";
        }

        public void SeeTopping()
        {
            Console.WriteLine("Containing: ");
            int number = 1;
            foreach (var topping in _toppings)
            {
                Console.WriteLine($"{number}. {topping.GetTopping()}");
                number++;
            }
        }       
        public void DeleteTopping(Topping topping)
        {
            _toppings.Remove(topping);
        }
        public void GetPizza()
        {
            Console.WriteLine($"Number: {_number}, Name: {_name}, Price: {_price:C}");
            SeeTopping();
        }
        #endregion


    }
}
