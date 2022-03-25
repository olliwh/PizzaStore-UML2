using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public  class MenuCatalog
    {
        #region Instance fields
        private List<Pizza> _pizzas;
        private Pizza p;
        private List<string> _pizzaPizzaMenuItems;
        //prices and numbers can not be larger than this 
        public const int MaxNumber = 10000;
        private List<Topping> _toppingsList;
        private List<string> _toppingOptions;
        #endregion
        #region Constructor
        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
            _toppingsList = new List<Topping>();
            _pizzaPizzaMenuItems = new List<string>()
            {
                "Add new to pizza to the menu",
                "Update Pizza",
                "Delete Pizza",
                "Search Pizza",
                "Display Pizza Menu",
                "Back To Top Menu"
            };
            _toppingOptions = new List<string>()
            {
                "Add Topping",
                "Delete Topping"
            };
        }
        #endregion
        #region Properties
        public List<Pizza> Pizzas { get { return _pizzas; } set { _pizzas = value; } }
        public List<Topping> ToppingList { get { return _toppingsList; } }
        public List<string> PizzaMenuItems { get { return _pizzaPizzaMenuItems; } set { _pizzaPizzaMenuItems = value; } }
        public List<string> ToppingOptions {  get { return _toppingOptions; } }
        #endregion
        #region Methods
        #region Topping
        public void GetToppingOtions()
        {
            int number = 1;
            foreach(var topping in _toppingOptions)
            {
                Console.WriteLine($"{number}. {topping}");
                number++;
            }
        }
        public void PrintToppingMenu()
        {
            int number = 1;
            foreach (var topping in _toppingsList)
            {
                Console.WriteLine($"{number}. {topping}");
                number++;
            }
        }
        public void CreateToppings()
        {
            Topping ham = new Topping("Ham");
            Topping pineApple = new Topping("Pineapple");
            Topping pepperoni = new Topping("Pepperoni");
            Topping onions = new Topping("Onions");
            Topping bellPepper = new Topping("Bell Pepper");
            Topping bacon = new Topping("bacon");

            _toppingsList.Add(ham);
            _toppingsList.Add(pineApple);
            _toppingsList.Add(pepperoni);
            _toppingsList.Add(onions);
            _toppingsList.Add(bellPepper);
            _toppingsList.Add(bacon);
        }
        public Topping GetTopping(string name)
        {
            Topping t = null;
            foreach (var topping in _toppingsList)
            {
                if (topping.Name == name) t = topping;
            }
            return t;
        }
        #endregion
        public void GetPizzaStartMenuList()
        {
            int number = 1;
            foreach (var item in _pizzaPizzaMenuItems)
            {
                Console.WriteLine($"{number}. {item}");
                number++;
            }
        }//skal den være i store?
        public Pizza CreatePizza(string name, int price)
        {
            int number = _pizzas.Count + 1;
            p = new Pizza(number, name, price);
            _pizzas.Add(p);
            return p;
        }
        public void UpdatePizza(Pizza pizza, string name, int price)
        {
            pizza.PizzaName = name;
            pizza.PizzaPrice = price;
            Console.WriteLine($"Updated pizza: {pizza}");
        }
        public void DeletePizza(Pizza pizza)
        {
            Console.WriteLine($"{pizza.PizzaName} was removed");
            _pizzas.Remove(pizza);
        }
        public Pizza SearchPizza(string name)
        {
            Pizza pizzaToFind = _pizzas.Find(x => x.PizzaName == name);
            return pizzaToFind;
        }
        public Pizza ReadPizza(int number)
        {
            Pizza pizzaToFind = _pizzas.Find(x => x.PizzaNumber == number);
            return pizzaToFind;
        }
        public void PrintMenu()
        {
            int pizzaNumber = 1;
            Console.WriteLine("-----------------------------------MENU-----------------------------------");
            foreach (var pizza in _pizzas)
            {
                Console.WriteLine($"{pizzaNumber}. {pizza}");
                pizzaNumber++;
            }
            Console.WriteLine("--------------------------------------------------------------------------");
        }
        #endregion
    }
}
