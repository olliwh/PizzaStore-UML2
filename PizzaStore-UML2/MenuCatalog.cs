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
        public void PizzaStartMenu()
        {
            Console.WriteLine("PIZZA MENU");
            int choice = Store.MenuChoices("Pizza");
            if (choice == 1) CreateDialog();
            if (_pizzas.Count == 0)
            {
                Console.WriteLine("You have no Pizzas");
                Store.TopMenu();
            }
            else
            {
                if (choice == 2) UpdateDialog();
                if (choice == 3) DeleteDialog();
                if (choice == 4) SearchDialog();
                if (choice == 5) ReadDialog();
                if (choice == 6)
                {
                    Console.WriteLine("LIST OF PIZZAS");
                    PrintPizzaList();
                    Console.WriteLine();
                    PizzaStartMenu();
                }
                if (choice == 7) Store.TopMenu();
            }
        }
        private void CreateDialog()
        {
            while (true)
            {
                Console.WriteLine("CREATE PIZZA");
                string name = Store.GetName("Pizza");
                Console.WriteLine("Type price of pizza and press enter");
                int price = Store.GetLongNumber();
                Pizza p = Create(name, price);
                Console.WriteLine($"{p.Name} was created");
                Console.WriteLine("What toppings should it have");
                AddToppingsOnPizza(p);
                p.GetPizza();
                if (!Store.EndLoop("Create", "Pizza")) break;
            }
            PizzaStartMenu();
        }
        private void UpdateDialog()
        {
            while (true)
            {
                Pizza pizzaToUpdate = Store.GetPizza(Pizzas);
                Console.WriteLine("What do you want to update?");
                List<string> list = new List<string>()
                {
                    "Name",
                    "Price",
                    "Topping"
                };
                int whatToUpdate = Store.StringListChoice(list);
                switch (whatToUpdate)
                {
                    case 1:
                        {

                            pizzaToUpdate.Name = Store.GetName("Pizza");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Type price of pizza and press enter");
                            int price = Store.GetLongNumber();
                            pizzaToUpdate.Price = price;
                            break;
                        }
                    case 3:
                        {
                            ChangeTopping(pizzaToUpdate);
                            break;
                        }
                }
                pizzaToUpdate.GetPizza();
                if (!Store.EndLoop("Update", "Pizza")) break;
            }
            PizzaStartMenu();
        }
        private void DeleteDialog()
        {
            while (true)
            {
                Pizza pizzaToDelete = Store.GetPizza(Pizzas);
                Console.WriteLine($"{pizzaToDelete.Name} was removed");
                _pizzas.Remove(pizzaToDelete);
                if (_pizzas.Count == 0) break;
                if (!Store.EndLoop("Delete", "Pizza")) break;
            }
            PizzaStartMenu();
        }
        private void SearchDialog()
        {
            while (true)
            {
                Console.WriteLine("SEARCH FOR PIZZA");
                PrintPizzaList();
                Console.WriteLine("Search for pizza by name");
                string name = Console.ReadLine();
                Pizza pizzaToFind = Search(name);
                if (pizzaToFind == null) Console.WriteLine("Not Found");
                else
                {
                    pizzaToFind.GetPizza();
                    if (!Store.EndLoop("Search for", "Pizza")) break;
                }
            }
            PizzaStartMenu();
        }
        private void ReadDialog()
        {
            while (true)
            {
                Console.WriteLine("READ PIZZA");
                Console.WriteLine("Search for pizza by number");
                PrintPizzaList();
                int numberToFind = Store.GetLongNumber();
                Pizza pizzaToFind = _pizzas.Find(x => x.Number == numberToFind);
                if (pizzaToFind == null) Console.WriteLine("Not found");
                else
                {
                    pizzaToFind.GetPizza();
                    Console.WriteLine("Du you want to Read another Pizza? Y/ENTER");
                    if (!Store.GetYesOrNoIput()) break;
                }
            }
            PizzaStartMenu();
        }
        public void PrintPizzaList()
        {
            int Number = 1;
            foreach (var pizza in _pizzas)
            {
                Console.WriteLine($"{Number}. {pizza}");
                Number++;
            }
        }
        public Pizza Search(string name)
        {
            Pizza pizzaToFind = _pizzas.Find(x => x.Name == name);
            return pizzaToFind;
        }
        public Pizza Create(string name, int price)
        {
            int number = _pizzas.Count + 1;
            Pizza p = new Pizza(number, name, price);
            _pizzas.Add(p);
            return p;
        }
        public void AddPizzasToOrder(Order order)
        {
            while (true)
            {
                Console.WriteLine("What pizza did they order?");
                PrintPizzaList();
                Pizza pizzaToAdd = Pizzas[Store.GetNumberInputFromUser(Pizzas.Count) - 1];
                order.Pizzas.Add(pizzaToAdd);
                Console.WriteLine("Add more to order? Y/ENTER");
                if (!Store.GetYesOrNoIput())
                {
                    break;
                }
            }
        }
        #endregion
        #region Topping
        public void CreateToppings()
        {
            Topping ham = new Topping("Ham");
            Topping pineApple = new Topping("Pineapple");
            Topping pepperoni = new Topping("Pepperoni");
            Topping onions = new Topping("Onions");
            Topping bellPepper = new Topping("Bell Pepper");
            Topping bacon = new Topping("Bacon");

            _toppings.Add(ham);
            _toppings.Add(pineApple);
            _toppings.Add(pepperoni);
            _toppings.Add(onions);
            _toppings.Add(bellPepper);
            _toppings.Add(bacon);
        }
        public void PrintToppingMenu()
        {
            int number = 1;
            foreach (var topping in _toppings)
            {
                Console.WriteLine($"{number}. {topping}");
                number++;
            }
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
            int input = Store.StringListChoice(toppingOptions);
            if (input == 1) AddToppingsOnPizza(p);
            if (input == 2) DeleteToppingsFromPizza(p);
        }
        public void DeleteToppingsFromPizza(Pizza p)
        {
            while (true)
            {
                Console.WriteLine("What topping do you want to delete?");
                p.SeeTopping();
                int index = Store.GetNumberInputFromUser(p.Toppings.Count) - 1;
                p.DeleteTopping(p.Toppings[index]);
                p.GetPizza();
                Console.WriteLine("Do you wnat to delete more toppings from pizza? Y/N");
                if (!Store.GetYesOrNoIput()) break;
            }
        }
        public void AddToppingsOnPizza(Pizza p)
        {
            while (true)
            {
                PrintToppingMenu();
                int index = Store.GetNumberInputFromUser(Toppings.Count) - 1;
                p.Toppings.Add(Toppings[index]);
                p.GetPizza();
                Console.WriteLine("Do you want to add more toppings to pizza? Y/ENTER");
                if (!Store.GetYesOrNoIput()) break;
            }
        }
        #endregion
    }
}
