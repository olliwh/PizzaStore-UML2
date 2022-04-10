using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class Store
    {
        private string _name;
        private static MenuCatalog _mc;
        private static CustomerCatalog _cc;
        private static OrderCatalog _oc;

        public Store(string name)
        {
            _name = name;
            _mc = new MenuCatalog();
            _cc = new CustomerCatalog();
            _oc = new OrderCatalog();
        }

        #region Metoder

        public void CreateAllItems()
        {
            //create pizzas
            Pizza p1 = _mc.Create("Magarita", 40);
            Pizza p2 = _mc.Create("Hawai", 50);
            Pizza p3 = _mc.Create("Mario", 55);
            Pizza p4 = _mc.Create("Veggie", 55);
            Pizza p5 = _mc.Create("Special", 60);

            //Add topping to pizzas in menu
            _mc.CreateToppings();
            p2.Toppings.Add(_mc.GetTopping("Ham"));
            p2.Toppings.Add(_mc.GetTopping("Pineapple"));
            p3.Toppings.Add(_mc.GetTopping("Pepperoni"));
            p4.Toppings.Add(_mc.GetTopping("Onions"));
            p4.Toppings.Add(_mc.GetTopping("Bell Pepper"));
            p5.Toppings.Add(_mc.GetTopping("Ham"));
            p5.Toppings.Add(_mc.GetTopping("Pepperoni"));
            p5.Toppings.Add(_mc.GetTopping("Bacon"));

            //create customers
            Customer c1 = _cc.Create("bob jensen", "c1@edu.dk", 12345678);
            Customer c2 = _cc.Create("jens Hansen", "c2@edu.dk", 23456789);
            Customer c3 = _cc.Create("ea olsen", "c3@edu.dk", 87654321);
            Customer c4 = _cc.Create("tim nielsen", "c4@edu.dk", 98765432);
            Customer c5 = _cc.Create("liv", "c5@edu.dk", 11223344); 
            //create orders
            Order o1 = _oc.Create(c1);
            o1.Pizzas.Add(p4);
            o1.Pizzas.Add(p2);

            Order o2 = _oc.Create(c2);
            o2.Pizzas.Add(p1);

            Order o3 = _oc.Create(c2);
            o3.Pizzas.Add(p1);
            o3.Pizzas.Add(p3);

            Order o4 = _oc.Create(c5);
            o4.Pizzas.Add(p1);
            o4.Pizzas.Add(p2);
            o4.Pizzas.Add(p2);
            o4.Pizzas.Add(p3);
            o4.Pizzas.Add(p3);
            o4.Pizzas.Add(p3);
        }
        public void Start()
        {
            CreateAllItems();
            Console.WriteLine(_name);
            TopMenu();
        }
        public static void TopMenu()
        {
            List<string> topMenuList = new List<string>()
            { "CUSTOMER", "PIZZA", "ORDER", "EXIT"};
            Console.WriteLine("TOP MENU");
            int chosenItem = Store.StringListChoice(topMenuList);
            if (chosenItem == 1) _cc.CustomerStartMenu();
            if (chosenItem == 2) _mc.PizzaStartMenu();
            if (chosenItem == 3) _oc.OrderStartMenu();
            if (chosenItem == 4) Environment.Exit(0);
        }
        
        public static bool EndLoop(string action, string type)
        {
            Console.WriteLine();
            Console.WriteLine($"Du you want to {action} another {type}? Y/ENTER");
            return GetYesOrNoIput();
        }
        public static bool GetYesOrNoIput()
        {
            string input = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.WriteLine();
            if (input == "Y")
            {
                return true;
            }
            return false;
        }
        public static int GetLongNumber()
        {
            bool valid = false;
            int inputNumber = 0;
            int MaxNumber = 100000000;
            while (!valid)
            {
                string input = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    inputNumber = Int32.Parse(input);
                    valid = inputNumber <= MaxNumber;
                    if (inputNumber > MaxNumber) Console.WriteLine("Number was out of range");
                }
                catch (Exception)
                {

                    Console.WriteLine("Not a valid number");
                }

                if (valid) break;
            }
            return inputNumber;
        }
        public static int GetNumberInputFromUser(int listCount)
        {
            bool valid = false;
            int inputNumber = 0;
            while (!valid)
            {
                string getInput = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                try
                {
                    inputNumber = Int32.Parse(getInput);
                    valid = inputNumber <= listCount && inputNumber > 0;
                    if (inputNumber > listCount || inputNumber < 1) Console.WriteLine("Number was out of range");
                }
                catch (FormatException)
                {

                    Console.WriteLine("Not a number");
                }

                if (valid) break;
            }
            return inputNumber;
        }
        public static string GetName(string type)
        {
            string name = string.Empty;
            while (name == string.Empty)
            {
                Console.WriteLine($"Type name of {type}");
                name = Console.ReadLine();
            }
            return name;
        }
        public static string GetMail()
        {
            string mail = string.Empty;
            while (mail == string.Empty)
            {
                Console.WriteLine($"Type mail of customer");
                mail = Console.ReadLine();
            }
            return mail;
        }
        public static Pizza GetPizza(List<Pizza> pizzas)
        {
            Console.WriteLine("Sellect number of pizza and press enter");
            int number = 1;
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"{number}. {pizza}");
                number++;
            }
            Pizza pizzaToReturn = pizzas[GetNumberInputFromUser(pizzas.Count) - 1];
            return pizzaToReturn;
        }
        public static Customer GetCustomer(List<Customer> customers)
        {
            Console.WriteLine("Sellect number of customer and press enter");
            int number = 1;
            foreach (var customer in customers)
            {
                Console.WriteLine($"{number}. {customer}");
                number++;
            }
            Customer customerToReturn = customers[GetNumberInputFromUser(customers.Count) - 1];
            return customerToReturn;
        }
        public static Order GetOrder(List<Order> orders)
        {
            Console.WriteLine("Sellect number of order and press enter");
            int number = 1;
            foreach(var order in orders)
            {
                order.GetOrder();
                Console.WriteLine();
                number++;
            }
            Order orderToReturn = orders[GetNumberInputFromUser(orders.Count) - 1];
            return orderToReturn;
        }
        public static int MenuChoices(string str)
        {
            List<string> listMenu = new List<string>()
            {
                $"Add new {str}",
                $"Update {str}",
                $"Delete {str}",
                $"Search for {str}",
                $"Read {str}",
                $"See list of all {str}s",
                $"Back to top menu"
            };
            int number = 1;
            foreach (var item in listMenu)
            {
                Console.WriteLine($"{number}. {item}");
                number++;
            }
            int input = GetNumberInputFromUser(listMenu.Count);
            return input;
        }
        public static int StringListChoice(List<string> list)
        {
            int number = 1;
            foreach (var str in list)
            {
                Console.WriteLine($"{number}. {str}");
                number++;
            }
            int numberToReturn = GetNumberInputFromUser(list.Count);
            return numberToReturn;
        }
        
        #endregion
    }
}
