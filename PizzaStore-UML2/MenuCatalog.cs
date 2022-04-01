using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public  class MenuCatalog
    {
        #region Instance fields
        private static List<Pizza> _pizzas;
        private static List<Topping> _toppings;
        #endregion
        #region Constructor
        public MenuCatalog()
        {
            _pizzas = new List<Pizza>();
            _toppings = new List<Topping>();
        }
        #endregion
        #region Properties
        public List<Pizza> Pizzas { get { return _pizzas; } set { _pizzas = value; } }
        public List<Topping> Toppings { get { return _toppings; } }

        #endregion
        #region Methods
        #region Topping
        public void PrintToppingMenu()
        {
            int number = 1;
            foreach (var topping in _toppings)
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

            _toppings.Add(ham);
            _toppings.Add(pineApple);
            _toppings.Add(pepperoni);
            _toppings.Add(onions);
            _toppings.Add(bellPepper);
            _toppings.Add(bacon);
        }
        public Topping GetTopping(string name)
        {
            Topping t = null;
            foreach (var topping in _toppings)
            {
                if (topping.Name == name) t = topping;
            }
            return t;
        }
        public void ChangeTopping(Pizza p)
        {
            List<string> toppingOptions = new List<string>()
            {
                "Add Topping",
                "Delete Topping"
            };
            int input = UserInput.StringListChoice(toppingOptions);
            if (input == 1) AddToppingsOnPizza(p);
            if (input == 2) DeleteToppingsFromPizza(p);
        }
        public void DeleteToppingsFromPizza(Pizza p)
        {
            while (true)
            {
                Console.WriteLine("What topping do you want to delete?");
                p.SeeTopping();
                int index = UserInput.GetNumberInputFromUser(p.Toppings.Count) - 1;
                p.DeleteTopping(p.Toppings[index]);
                Console.WriteLine(p);
                p.SeeTopping();
                Console.WriteLine("Do you wnat to delete more toppings from pizza? Y/N");
                if (!UserInput.GetYesOrNoIput()) break;
            }
        }
        public void AddToppingsOnPizza(Pizza p)
        {
            while (true)
            {
                PrintToppingMenu();
                int index = UserInput.GetNumberInputFromUser(Toppings.Count) - 1;
                p.Toppings.Add(Toppings[index]);
                Console.WriteLine(p);
                p.SeeTopping();
                Console.WriteLine("Do you want to add more toppings to pizza? Y/ENTER");
                if (!UserInput.GetYesOrNoIput()) break;
            }
        }
        #endregion
        public void PizzaStartMenu()
        {
            Console.WriteLine("PIZZA MENU");
            int choice = UserInput.MenuChoices("Pizza");
            if (choice == 1) CreatePizza();
            if (_pizzas.Count == 0)
            {
                Console.WriteLine("You have no Pizzas");
                Store.TopMenu();
            }
            else
            {

                if (choice == 2) UpdatePizza();
                if (choice == 3) DeletePizza();
                if (choice == 4) SearchForPizza();
                if (choice == 5) ReadPizza();
                if (choice == 6) SeePizzaMenu();
                if (choice == 7) Store.TopMenu();

            }
        }
        public void CreatePizza()
        {
            while (true)
            {
                Console.WriteLine("CREATE PIZZA");
                string name = UserInput.GetName("Pizza");
                Console.WriteLine("Type price of pizza and press enter");
                int price = UserInput.GetLongNumber();

                int number = _pizzas.Count + 1;
                Pizza p = new Pizza(number, name, price);
                _pizzas.Add(p);
                
                //Pizza p = CreatePizza(name, price);
                Console.WriteLine($"{p.Name} was created");
                Console.WriteLine("What toppings should it have");
                AddToppingsOnPizza(p);
                Console.WriteLine(p);
                if (!UserInput.EndLoop("Create", "Pizza")) break;
            }
            PizzaStartMenu();
        }
        public Pizza CreatePizza(string name, int price)
        {
            int number = _pizzas.Count + 1;
            Pizza p = new Pizza(number, name, price);
            _pizzas.Add(p);
            return p;
        }
        public void UpdatePizza()
        {
            while (true)
            {
                Pizza pizzaToUpdate = UserInput.GetPizza(Pizzas);
                Console.WriteLine("What do you want to update?");
                List<string> list = new List<string>()
                {
                    "Name",
                    "Price",
                    "Topping"
                };
                int whatToUpdate = UserInput.StringListChoice(list);
                switch (whatToUpdate)
                {
                    case 1:
                        {

                            pizzaToUpdate.Name = UserInput.GetName("Pizza");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Type price of pizza and press enter");
                            int price = UserInput.GetLongNumber();
                            pizzaToUpdate.Price = price;
                            break;
                        }
                    case 3:
                        {
                            ChangeTopping(pizzaToUpdate);
                            break;
                        }
                }
                if (!UserInput.EndLoop("Update", "Pizza")) break;
            }
            PizzaStartMenu();
        }
        public void DeletePizza()
        {
            while (true)
            {
                Pizza pizzaToDelete = UserInput.GetPizza(Pizzas);
                Console.WriteLine($"{pizzaToDelete.Name} was removed");
                _pizzas.Remove(pizzaToDelete);
                if (_pizzas.Count == 0) break;
                if (!UserInput.EndLoop("Delete", "Pizza")) break;
            }
            PizzaStartMenu();
        }
        public void SearchForPizza()
        {
            while (true)
            {
                Console.WriteLine("SEARCH FOR PIZZA");
                PrintMenu();
                Console.WriteLine("Search for pizza by name");
                string name = Console.ReadLine();
                Pizza pizzaToFind = SearchPizza(name);
                if (pizzaToFind == null) Console.WriteLine("Not Found");
                else
                {
                    Console.WriteLine(pizzaToFind);
                    pizzaToFind.SeeTopping();
                    if (!UserInput.EndLoop("Search for", "Pizza")) break;
                }
            }
            PizzaStartMenu();
        }
        public Pizza SearchPizza(string name)
        {
            Pizza pizzaToFind = _pizzas.Find(x => x.Name == name);
            return pizzaToFind;
        }
        public void ReadPizza()
        {
            while (true)
            {
                Console.WriteLine("READ PIZZA");
                Console.WriteLine("Search for pizza by number");
                PrintMenu();
                int numberToFind = UserInput.GetNumberInputFromUser(Pizzas.Count);
                Pizza pizzaToFind = _pizzas.Find(x => x.Number == numberToFind);
                Console.WriteLine(pizzaToFind);
                pizzaToFind.SeeTopping();
                Console.WriteLine("Du you want to Read another Pizza? Y/ENTER");
                if (!UserInput.GetYesOrNoIput()) break;
            }
            PizzaStartMenu();
        }
        public void SeePizzaMenu()
        {
            Console.WriteLine("PIZZA MENU");
            PrintMenu();
            PizzaStartMenu();
        }
        public void PrintMenu()
        {
            int Number = 1;
            Console.WriteLine("-----------------------------------MENU-----------------------------------");
            foreach (var pizza in _pizzas)
            {
                Console.WriteLine($"{Number}. {pizza}");
                Number++;
            }
            Console.WriteLine("--------------------------------------------------------------------------");
        }
        public void AddPizzasToOrder(Order order)
        {
            while (true)
            {
                Console.WriteLine("What pizza did they order?");
                PrintMenu();
                Pizza pizzaToAdd = Pizzas[UserInput.GetNumberInputFromUser(Pizzas.Count) - 1];
                order.Pizzas.Add(pizzaToAdd);

                Console.WriteLine("Add more to order? Y/ENTER");
                if (!UserInput.GetYesOrNoIput())
                {
                    order.PrintOrder();
                    break;
                }
            }
        }
        #endregion
    }
}
