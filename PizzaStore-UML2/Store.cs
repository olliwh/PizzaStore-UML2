using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class Store
    {
        private string _name;
        private MenuCatalog _mc;
        //press numbers and enter og y for yes adn enter for no

        
        public Store(string name)
        {
            _name = name;
            _mc = new MenuCatalog();
        }
        public void CreateMenu()
        {
            //create pizzas
            Pizza p1 = _mc.CreatePizza("Magarita", 40);
            Pizza p2 = _mc.CreatePizza("Hawai", 50);
            Pizza p3 = _mc.CreatePizza("Mario", 55);
            Pizza p4 = _mc.CreatePizza("Veggie", 55);

            //Add topping to pizzas in menu
            _mc.CreateToppings();
            p2.Toppings.Add(_mc.GetTopping("Ham"));
            p2.Toppings.Add(_mc.GetTopping("Pineapple"));
            p3.Toppings.Add(_mc.GetTopping("Pepperoni"));
            p4.Toppings.Add(_mc.GetTopping("Onions"));
            p4.Toppings.Add(_mc.GetTopping("Bell Pepper"));
            p3.SeeTopping();

            _mc.PrintMenu();
        }
        public void CreateCustomers()
        {
            Customer c1 = new Customer("bob jensen", "c1@edu.dk", 12345678);
            Customer c2 = new Customer("jens Hansen", "c2@edu.dk", 672737383);
            Customer c3 = new Customer("ea olsen", "c3@edu.dk", 7378383);
            Customer c4 = new Customer("liv nielsen", "c4@edu.dk", 37384949);
        }
        public void Start()
        {
            Console.WriteLine(_mc.ReadPizza(3));
            CreateMenu();
            PizzaStartMenu();
        }
        public void PizzaStartMenu()
        {
            Console.WriteLine("PIZZA MENU");
            _mc.GetPizzaStartMenuList();
            int choice = GetNumberInputFromUser(_mc.PizzaMenuItems.Count);
            if (choice == 1) CreatePizza();
            if (choice == 2) UpdatePizza();
            if (choice == 3) DeletePizza();
            if (choice == 4) SearchForPizza();
            if (choice == 5) _mc.PrintMenu();
            else Console.WriteLine("The END");
        }
        public void CreatePizza()
        {
            while (true)
            {
                Console.WriteLine("CREATE PIZZA");
                Console.WriteLine("Type name of pizza and press enter");
                string name = Console.ReadLine();
                Console.WriteLine("Type price of pizza and press enter");
                int price = GetNumberInputFromUser(MenuCatalog.MaxNumber);
                Pizza p = _mc.CreatePizza(name, price);
                Console.WriteLine($"{p.PizzaName} was created");
                //
                Console.WriteLine("What toppings should it have");
                AddToppingsOnPizza(p);
                //
                Console.WriteLine(p);
                Console.WriteLine("Are you done Creating?");
                string done = Console.ReadLine().ToUpper();
                if (done == "Y") break;
            }
            PizzaStartMenu();
        }

        public void SearchForPizza()
        {
            while(true)
            { 
                Console.WriteLine("SEARCH FOR PIZZA");
                Console.WriteLine("Search for pizza by name");
                string name = Console.ReadLine();
                Pizza pizzaToFind = _mc.SearchPizza(name);
                if (pizzaToFind == null) Console.WriteLine("Not Found");
                else
                {
                    Console.WriteLine(pizzaToFind);
                    pizzaToFind.SeeTopping();
                    Console.WriteLine("Are you done Searching? Y/N");
                    string done = Console.ReadLine().ToUpper();
                    if (done == "Y") break;
                }
            }
            PizzaStartMenu();
        }
        public void DeletePizza()
        {
            while(true)
            { 
                Console.WriteLine("DELETE PIZZA");
                _mc.PrintMenu();
                Console.WriteLine("Select the pizza you want to delete");
                Pizza pizzaToDelete = _mc.Pizzas[GetNumberInputFromUser(_mc.Pizzas.Count) - 1];
                _mc.DeletePizza(pizzaToDelete);
                Console.WriteLine("Are you done Deleting? Y/N");
                string done = Console.ReadLine().ToUpper();
                if (done == "Y") break;
            }
            PizzaStartMenu();
        }
        public void UpdatePizza()
        {
            while (true)
            {
                Console.WriteLine("UPDATE PIZZA");
                _mc.PrintMenu();
                Console.WriteLine("sellect number of pizza and press enter");
                Pizza pizzaToUpdate = _mc.Pizzas[GetNumberInputFromUser(_mc.Pizzas.Count) - 1];
                Console.WriteLine("Type name of pizza and press enter");
                string name = Console.ReadLine();
                Console.WriteLine("Type price of pizza and press enter");
                int price = GetNumberInputFromUser(MenuCatalog.MaxNumber);
                _mc.UpdatePizza(pizzaToUpdate, name, price);
                Console.WriteLine("Do you want to change the toppings?");
                if (GetYesOrNoIput()) ChangeTopping(pizzaToUpdate);
                Console.WriteLine("Are you done Updating?Y/N");
                string done = Console.ReadLine().ToUpper();
                if (done == "Y") break;
            }
            PizzaStartMenu();
        }
        #region topping
        public void ChangeTopping(Pizza p)
        {
            _mc.GetToppingOtions();
            int input = GetNumberInputFromUser(_mc.ToppingOptions.Count);
            if (input == 1) AddToppingsOnPizza(p);
            if (input == 2) DeleteToppingsFromPizza(p);
        }
        public void DeleteToppingsFromPizza(Pizza p)
        {
            while (true)
            {
                Console.WriteLine("What topping do you want to delete?");
                p.SeeTopping();
                int index = GetNumberInputFromUser(p.Toppings.Count) - 1;
                p.DeleteTopping(p.Toppings[index]);
                p.SeeTopping();
                Console.WriteLine("Do you wnat to delete more toppings from pizza?");
                string done = Console.ReadLine().ToUpper();
                if (done != "Y") break;
            }
        }
        public void AddToppingsOnPizza(Pizza p)
        {
            while (true)
            {
                _mc.PrintToppingMenu();
                int index = GetNumberInputFromUser(_mc.ToppingList.Count) - 1;
                p.Toppings.Add(_mc.ToppingList[index]);
                p.SeeTopping();
                Console.WriteLine(p);
                Console.WriteLine("Do you wnat to add more toppings to pizza?");
                string done = Console.ReadLine().ToUpper();
                if (done != "Y") break;
            }
        }
#endregion
        #region inputs
        public bool GetYesOrNoIput()
        {
            string input = Console.ReadLine().ToUpper();
            if (input == "Y")
            {
                return true;
            }
            return false;
        }
        public int GetNumberInputFromUser(int listCount)
        {
            bool valid = false;
            int inputNumber = 0;
            while (!valid)
            {
                string input = Console.ReadLine();
                try
                {
                    inputNumber = Int32.Parse(input);
                    valid = inputNumber <= listCount;
                    if (inputNumber > listCount) Console.WriteLine("Number was out of range");
                }
                catch (FormatException)
                {

                    Console.WriteLine("Not a number");
                }
  
                if (valid) break;
            }
            return inputNumber;
        }
        #endregion
    }
}
