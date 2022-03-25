using System;
using System.Collections.Generic;
using System.Text;


namespace PizzaStore_UML2
{
    public class Pizza
    {
        #region Instance Fields
        private int _pizzaNumber;
        private string _pizzaName;
        private int _pizzaPrice;
        private List<Topping> _toppings;
        #endregion

        #region Constructor
        public Pizza(int number,string name, int price)
        {
            _pizzaNumber = number;
            _pizzaName = name;
            _pizzaPrice = price;
            _toppings = new List<Topping>();
            Topping sauce = new Topping("Sause");
            Topping cheese = new Topping("Cheese");
            _toppings.Add(sauce);
            _toppings.Add(cheese);
        }
        #endregion

        #region Properties
        public int PizzaNumber { get { return _pizzaNumber; } set { _pizzaNumber = value; } }
        public string PizzaName { get { return _pizzaName; } set { _pizzaName = value; } }
        public int PizzaPrice { get { return _pizzaPrice; } set { _pizzaPrice = value; } }

        public List<Topping> Toppings {  get { return _toppings; } }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{_pizzaName}, {_pizzaPrice:C}";
            // {_pizzaNumber}. 
        }
        #region Topping methods
        public void SeeTopping()
        {
            Console.WriteLine("Containing: ");
            int number = 1;
            foreach (var topping in _toppings)
            {
                Console.WriteLine($"{number}. {topping}");
                number++;
            }
        }       
        //public void AddTopping(Topping topping)
        //{
        //    _toppings.Add(topping);
        //}
        public void DeleteTopping(Topping topping)
        {
            _toppings.Remove(topping);
        }

        #endregion
        #endregion

    }
}
