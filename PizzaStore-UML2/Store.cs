using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class Store
    {
        private const string _name = "Big Mammas Pizzaria";
        private static MenuCatalog _menuCat;
        private static CustomerCatalog _customerCat;
        private static OrderCatalog _oc;

        public Store()
        {
            _menuCat = new MenuCatalog();
            _customerCat = new CustomerCatalog();
            _oc = new OrderCatalog();
        }

        #region Metoder
        #region Beginner Methods
        public void CreateAllItems()
        {
            //create pizzas
            Pizza p1 = _menuCat.CreatePizza("Magarita", 40);
            Pizza p2 = _menuCat.CreatePizza("Hawai", 50);
            Pizza p3 = _menuCat.CreatePizza("Mario", 55);
            Pizza p4 = _menuCat.CreatePizza("Veggie", 55);

            //Add topping to pizzas in menu
            _menuCat.CreateToppings();
            p2.Toppings.Add(_menuCat.GetTopping("Ham"));
            p2.Toppings.Add(_menuCat.GetTopping("Pineapple"));
            p3.Toppings.Add(_menuCat.GetTopping("Pepperoni"));
            p4.Toppings.Add(_menuCat.GetTopping("Onions"));
            p4.Toppings.Add(_menuCat.GetTopping("Bell Pepper"));
            
            //create customers
            Customer c1 = _customerCat.Create("bob jensen", "c1@edu.dk", 12345678);
            Customer c2 = _customerCat.Create("jens Hansen", "c2@edu.dk", 672737383);
            Customer c3 = _customerCat.Create("ea olsen", "c3@edu.dk", 7378383);
            Customer c4 = _customerCat.Create("liv nielsen", "c4@edu.dk", 37384949);

            //create orders
            Order o1 = _oc.CreateOrder(c1);
            o1.Pizzas.Add(p4);
            o1.Pizzas.Add(p2);

            Order o2 = _oc.CreateOrder(c2);
            o2.Pizzas.Add(p1);

            Order o3 = _oc.CreateOrder(c2);
            o3.Pizzas.Add(p1);
            o3.Pizzas.Add(p3);
        }
        public void Start()
        {
            CreateAllItems();
            TopMenu();
        }
        public static void TopMenu()
        {
            Console.WriteLine(_name);
            List<string> topMenuList = new List<string>()
            { "CUSTOMER", "PIZZA", "ORDER", "EXIT"};
            Console.WriteLine("TOP MENU");
            int chosenItem = UserInput.StringListChoice(topMenuList);
            if (chosenItem == 1) _customerCat.CustomerStartMenu();
            if (chosenItem == 2) _menuCat.PizzaStartMenu();
            if (chosenItem == 3) _oc.OrderMenu();
            if (chosenItem == 4) Environment.Exit(0);
        }
        #endregion

        //        #region Order
        //        public void OrderMenu()
        //        {
        //            Console.WriteLine("ORDER MENU");
        //            //int input = MenuChoices("Order");
        //            //if (input == 1) CreateOrder();
        //            //if (input == 2) UpdateOrder();
        //            //if (input == 3) DeleteOrder();
        //            //if (input == 4) SearchOrder();
        //            //if (input == 5) _oc.ReadOrder();
        //            //if (input == 6) PrintOrders();
        //            //if (input == 7) TopMenu();
        //        }
        //        public void CreateOrder()
        //        {
        //            Console.WriteLine("MAKE ORDER");
        //            while (true)
        //            {
        //                _customerCat.PrintCustomerList();
        //                Console.WriteLine("Write number of customer");
        //                int index = GetNumberInputFromUser(_customerCat.CustomerList.Count) - 1;
        //                Customer customerOfOrder = _customerCat.CustomerList[index];

        //                if (customerOfOrder == null) Console.WriteLine("Not Found");
        //                else
        //                {
        //                    Order newOrder = _oc.CreateOrder(customerOfOrder);
        //                    AddPizzasToOrder(newOrder);

        //                }
        //                Console.WriteLine("Do you want to Make another order?Y/N");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //        }
        //        public void UpdateOrder()
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("UPDATE ORDER");
        //                Console.WriteLine("What order would you like to update?");
        //                _oc.PrintAllOrders();
        //                int index = GetNumberInputFromUser(_oc.OrderList.Count) - 1;
        //                Order orderToUpdate = _oc.OrderList[index];
        //                Console.WriteLine("What do you want to update?");
        //                List<string> l = new List<string>()
        //                {
        //                    "ID",
        //                    "Customer",
        //                    "Pizzas"
        //                };
        //                int whatToUpdate = StringListChoice(l);
        //                switch (whatToUpdate)
        //                {
        //                    case 1:
        //                    {
        //                        Console.WriteLine("Type new ID");
        //                        int newID = GetNumberInputFromUser(1000);
        //                        orderToUpdate.ID = newID;
        //                        Console.WriteLine(orderToUpdate);
        //                        break;
        //                    }
        //                    case 2:
        //                    {
        //                        Console.WriteLine("Do you want to make a new customer");
        //                        if (GetYesOrNoIput()) CreateCustomer();
        //                        else
        //                        {
        //                            Console.WriteLine("Type name of customer");
        //                            string nameOfCustomer = Console.ReadLine();
        //                            Customer newCustomer = _customerCat.Search(nameOfCustomer);
        //                            orderToUpdate.OrderCustomer = newCustomer;
        //                            Console.WriteLine(orderToUpdate);
        //                        }
        //                        break;
        //                    }
        //                    case 3:
        //                    {
        //                        List<string> list = new List<string>()
        //                    {
        //                        "Add Pizza",
        //                        "Delete Pizza",
        //                        "Change topping"
        //                    };
        //                            int input = StringListChoice(list);
        //                        switch (input)
        //                        {
        //                            case 1:
        //                            {
        //                                AddPizzasToOrder(orderToUpdate);
        //                                break;
        //                            }
        //                            case 2:
        //                            {
        //                                RemovePizzaFromOrder(orderToUpdate);
        //                                break;
        //                            }
        //                            case 3:
        //                            {
        //                                ChangeTopping(GetPizza(orderToUpdate.Pizzas));
        //                                break;
        //                            }
        //                        }
        //                        break;
        //                    }
        //                }
        //                Console.WriteLine("Du you want to Update another order? Y/ENTER");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //            OrderMenu();
        //        }
        //        //public void DeleteOrder()
        //        //{
        //        //    while (true)
        //        //    {
        //        //        Console.WriteLine("DELETE ORDER");
        //        //        Console.WriteLine("What order do you want to Delete?");
        //        //        _oc.PrintAllOrders();
        //        //        int input = GetNumberInputFromUser(_oc.OrderList.Count);
        //        //        Order orderToDelete = _oc.OrderList[input - 1];
        //        //        _oc.DeleteOrder(orderToDelete);
        //        //        Console.WriteLine($"Order {orderToDelete.ID} has been deleted");
        //        //        Console.WriteLine("Du you want to Delete another order? Y/ENTER");
        //        //        if (!GetYesOrNoIput()) break;
        //        //    }
        //        //    OrderMenu();
        //        //}

        //        public void SearchOrder()
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("Write name of cusomer");

        //                _customerCat.PrintCustomerList();
        //                string name = Console.ReadLine();
        //                _oc.SearchOrder(name);
        //                Console.WriteLine("Du you want to Search for another order? Y/ENTER");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //            OrderMenu();
        //        }
        //        //public void ReadOrder()
        //        //{
        //        //    while (true)
        //        //    {
        //        //        Console.WriteLine("READ ORDER");
        //        //        Console.WriteLine("Search for order by ID");
        //        //        _oc.PrintAllOrders();
        //        //        int idToFind = GetNumberInputFromUser(_oc.OrderList.Count);
        //        //        //Order orderToRead = _oc.ReadOrder(idToFind);
        //        //        Console.WriteLine(orderToRead);
        //        //        orderToRead.PrintOrder();
        //        //        Console.WriteLine("Du you want to Read another order? Y/ENTER");
        //        //        if (!GetYesOrNoIput()) break;
        //        //    }
        //        //}
        //        public void PrintOrders()
        //        {
        //            _oc.PrintAllOrders();
        //            OrderMenu();
        //        }
        //        public void RemovePizzaFromOrder(Order order)
        //        {
        //            int number = 1;
        //            foreach(var pizza in order.Pizzas)
        //            {
        //                Console.WriteLine($"{number}. {pizza}");
        //                number++;
        //            }
        //            Console.WriteLine("What pizza do you want to delete?");
        //            int index = GetNumberInputFromUser(order.Pizzas.Count) - 1;
        //            Pizza pizzaToDelete = order.Pizzas[index];
        //            order.Pizzas.Remove(pizzaToDelete);
        //        }
        //        public void AddPizzasToOrder(Order order)
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("What pizza did they order?");
        //                _menuCat.PrintMenu();
        //                Pizza pizzaToAdd = _menuCat.Pizzas[GetNumberInputFromUser(_menuCat.Pizzas.Count) - 1];
        //                order.Pizzas.Add(pizzaToAdd);

        //                Console.WriteLine("Add more to order? Y/ENTER");
        //                if (!GetYesOrNoIput())
        //                {
        //                    order.PrintOrder();
        //                    break;
        //                }
        //            }
        //            OrderMenu();
        //        }
        //        #endregion
        //        #region Customers
        //        public void CustomerStartMenu()
        //        {
        //            Console.WriteLine("CUSTOMER MENU");
        //            //int choice = MenuChoices("Customer");
        //            //if (choice == 1) CreateCustomer();
        //            //if (choice == 2) UpdateCustomer();
        //            //if (choice == 3) DeleteCustomer();
        //            //if (choice == 4) SearchForCustomer();
        //            //if (choice == 5) ReadCustomer();
        //            //if (choice == 6) SeeCustomerList();
        //            //if (choice == 7) TopMenu();
        //            //else Console.WriteLine("The END");
        //        }
        //        public void CreateCustomer()
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("CREATE CUSTOMER");
        //                Console.WriteLine("Type name of customer and press enter");
        //                string name = Console.ReadLine();
        //                Console.WriteLine("Type mail and press enter");
        //                string mail = Console.ReadLine();
        //                Console.WriteLine("Type phone numberand press enter");
        //                int phone = GetLongNumber();
        //                Customer c = _customerCat.Create(name, mail, phone);
        //                Console.WriteLine($"{c.Name} was created");
        //                Console.WriteLine("Du you want to Create another Customer? Y/ENTER");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //            CustomerStartMenu();
        //        }
        //        //public void UpdateCustomer()
        //        //{
        //        //    while (true)
        //        //    {
        //        //        Console.WriteLine("UPDATE CUSTOMER");
        //        //        _customerCat.PrintCustomerList();
        //        //        Console.WriteLine("Sellect number of customer you want to update and press enter");
        //        //        Customer customerToUpdate = _customerCat.CustomerList[GetNumberInputFromUser(_customerCat.CustomerList.Count) - 1];
        //        //        Console.WriteLine(customerToUpdate);
        //        //        Console.WriteLine("What do you want to update?");
        //        //        List<string> list = new List<string>()
        //        //        {
        //        //            "Name",
        //        //            "Mail",
        //        //            "Phone"
        //        //        };
        //        //        int whatToUpdate = StringListChoice(list);
        //        //        switch (whatToUpdate)
        //        //        {
        //        //            case 1:
        //        //                {
        //        //                    Console.WriteLine("Type name of customer and press enter");
        //        //                    string name = Console.ReadLine();
        //        //                    customerToUpdate.Name = name;
        //        //                    _customerCat.Update(customerToUpdate, name, customerToUpdate.Mail, customerToUpdate.PhoneNumber);
        //        //                    break;
        //        //                }
        //        //            case 2:
        //        //                {
        //        //                    Console.WriteLine("Type mail of customer and press enter");
        //        //                    string mail = Console.ReadLine();
        //        //                    customerToUpdate.Mail = mail;
        //        //                    _customerCat.Update(customerToUpdate, customerToUpdate.Name, mail, customerToUpdate.PhoneNumber);
        //        //                    break;
        //        //                }
        //        //            case 3:
        //        //                {
        //        //                    Console.WriteLine("Type phone number of customer and press enter");
        //        //                    int phone = GetLongNumber();
        //        //                    customerToUpdate.PhoneNumber = phone;
        //        //                    _customerCat.Update(customerToUpdate, customerToUpdate.Name, customerToUpdate.Mail, phone);
        //        //                    break;
        //        //                }
        //        //        }
        //        //        Console.WriteLine("Du you want to Update another Customer? Y/ENTER");
        //        //        if (!GetYesOrNoIput()) break;
        //        //    }
        //        //    CustomerStartMenu();
        //        //}
        //        //public void DeleteCustomer()
        //        //{
        //        //    while (true)
        //        //    {
        //        //        Console.WriteLine("DELETE CUSTOMER");
        //        //        _customerCat.PrintCustomerList();
        //        //        Console.WriteLine("Sellect number of customer you want to Delete and press enter");
        //        //        Customer customerToDelete = _customerCat.CustomerList[GetNumberInputFromUser(_customerCat.CustomerList.Count - 1)];
        //        //        _customerCat.Delete(customerToDelete);
        //        //        Console.WriteLine($"{customerToDelete} has been Deleted");
        //        //        Console.WriteLine("Du you want to Delete another Customer? Y/ENTER");
        //        //        if (!GetYesOrNoIput()) break;
        //        //    }
        //        //    CustomerStartMenu();
        //        //}
        //        public void SearchForCustomer()
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("CUSTOMER SEARCH");
        //                _customerCat.PrintCustomerList();
        //                Console.WriteLine("Search for customer by name");
        //                string name = Console.ReadLine();
        //                Customer customerToFind = _customerCat.Search(name);
        //                if (customerToFind == null) Console.WriteLine("Not Found");
        //                else
        //                {
        //                    Console.WriteLine(customerToFind);
        //                    Console.WriteLine("Du you want to Search for another Customer? Y/ENTER");
        //                    if (!GetYesOrNoIput()) break;
        //                }
        //            }
        //            CustomerStartMenu();
        //        }
        //        public void ReadCustomer()
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("READ CUSTOMER");
        //                Console.WriteLine("Search for Customer by phone number");
        //                _customerCat.PrintCustomerList();
        //                int phoneToFind = GetLongNumber();
        //                Customer customerToRead = _customerCat.Read(phoneToFind);
        //                Console.WriteLine(customerToRead);
        //                customerToRead.PrintOrder();
        //                Console.WriteLine("Du you want to Read another Customer? Y/ENTER");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //        }

        //        public void SeeCustomerList()
        //        {
        //            Console.WriteLine("LIST OF CUSTOMERS");
        //            _customerCat.PrintCustomerList();
        //            CustomerStartMenu();
        //        }

        //        #endregion
        //        #region Pizza
        //        public void PizzaStartMenu()
        //        {
        //            Console.WriteLine("PIZZA MENU");
        //            int choice = MenuChoices("Pizza");
        //            //if (choice == 1) CreatePizza();
        //            //if (choice == 2) UpdatePizza();
        //            //if (choice == 3) DeletePizza();
        //            //if (choice == 4) SearchForPizza();
        //            //if (choice == 5) ReadPizza();
        //            //if (choice == 6) SeePizzaMenu();
        //            //if (choice == 7) TopMenu();
        //            //else Console.WriteLine("The END");
        //        }
        //        public void CreatePizza()
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("CREATE PIZZA");
        //                Console.WriteLine("Type name of pizza and press enter");
        //                string name = Console.ReadLine();
        //                Console.WriteLine("Type price of pizza and press enter");
        //                int price = GetLongNumber();
        //                Pizza p = _menuCat.CreatePizza(name, price);
        //                Console.WriteLine($"{p.Name} was created");
        //                Console.WriteLine("What toppings should it have");
        //                AddToppingsOnPizza(p);
        //                Console.WriteLine(p);
        //                Console.WriteLine("Du you want to Create another Pizza? Y/ENTER");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //            PizzaStartMenu();
        //        }
        //        //public void UpdatePizza()
        //        //{
        //        //    while (true)
        //        //    {
        //        //        Pizza pizzaToUpdate = GetPizza(_menuCat.Pizzas);
        //        //        Console.WriteLine("What do you want to update?");
        //        //        List<string> list = new List<string>()
        //        //        {
        //        //            "Name",
        //        //            "Price",
        //        //            "Topping"
        //        //        };
        //        //        int whatToUpdate = StringListChoice(list);
        //        //        switch (whatToUpdate)
        //        //        {
        //        //            case 1:
        //        //                {
        //        //                    Console.WriteLine("Type name of pizza and press enter");
        //        //                    string name = Console.ReadLine();
        //        //                    _menuCat.UpdatePizza(pizzaToUpdate, name, pizzaToUpdate.Price);
        //        //                    break;
        //        //                }
        //        //            case 2:
        //        //                {
        //        //                    Console.WriteLine("Type price of pizza and press enter");
        //        //                    int price = GetLongNumber() ;
        //        //                    _menuCat.UpdatePizza(pizzaToUpdate, pizzaToUpdate.Name, price);
        //        //                    break;
        //        //                }
        //        //            case 3:
        //        //                {
        //        //                    ChangeTopping(pizzaToUpdate);
        //        //                    break;
        //        //                }
        //        //        }
        //        //        Console.WriteLine("Du you want to Update another Pizza? Y/ENTER");
        //        //        if (!GetYesOrNoIput()) break;
        //        //    }
        //        //    PizzaStartMenu();
        //        //}
        //        //public void DeletePizza()
        //        //{
        //        //    while (true)
        //        //    {
        //        //        Pizza pizzaToDelete = GetPizza(_menuCat.Pizzas);
        //        //        _menuCat.DeletePizza(pizzaToDelete);
        //        //        Console.WriteLine("Du you want to Delete another Pizza? Y/ENTER");
        //        //        if (!GetYesOrNoIput()) break;
        //        //    }
        //        //    PizzaStartMenu();
        //        //}
        //        //public void SearchForPizza()
        //        //{
        //        //    while(true)
        //        //    { 
        //        //        Console.WriteLine("SEARCH FOR PIZZA");
        //        //        _menuCat.PrintMenu();
        //        //        Console.WriteLine("Search for pizza by name");
        //        //        string name = Console.ReadLine();
        //        //        Pizza pizzaToFind = _menuCat.SearchPizza(name);
        //        //        if (pizzaToFind == null) Console.WriteLine("Not Found");
        //        //        else
        //        //        {
        //        //            Console.WriteLine(pizzaToFind);
        //        //            pizzaToFind.SeeTopping();
        //        //            Console.WriteLine("Du you want to Search for another Pizza? Y/ENTER");
        //        //            if (!GetYesOrNoIput()) break;
        //        //        }
        //        //    }
        //        //    PizzaStartMenu();
        //        //}
        //        //public void ReadPizza()
        //        //{
        //        //    while (true)
        //        //    {
        //        //        Console.WriteLine("READ PIZZA");
        //        //        Console.WriteLine("Search for pizza by number");
        //        //        _menuCat.PrintMenu();
        //        //        int numberToFind = GetNumberInputFromUser(_menuCat.Pizzas.Count);
        //        //        Pizza pizzaToFind = _menuCat.ReadPizza(numberToFind);
        //        //        Console.WriteLine(pizzaToFind);
        //        //        pizzaToFind.SeeTopping();
        //        //        Console.WriteLine("Du you want to Read another Pizza? Y/ENTER");
        //        //        if (!GetYesOrNoIput()) break;
        //        //    }
        //        //    PizzaStartMenu();
        //        //}
        //        public void SeePizzaMenu()
        //        {
        //            Console.WriteLine("PIZZA MENU");
        //            _menuCat.PrintMenu();
        //            PizzaStartMenu();
        //        }

        //        #endregion
        //        #region Topping
        //        public void ChangeTopping(Pizza p)
        //        {
        //            List<string> toppingOptions = new List<string>()
        //            {
        //                "Add Topping",
        //                "Delete Topping"
        //            };
        //            int input = StringListChoice(toppingOptions);
        //            if (input == 1) AddToppingsOnPizza(p);
        //            if (input == 2) DeleteToppingsFromPizza(p);
        //        }
        //        public void DeleteToppingsFromPizza(Pizza p)
        //        {
        //            while (true)
        //            {
        //                Console.WriteLine("What topping do you want to delete?");
        //                p.SeeTopping();
        //                int index = GetNumberInputFromUser(p.Toppings.Count) - 1;
        //                p.DeleteTopping(p.Toppings[index]);
        //                Console.WriteLine(p);
        //                p.SeeTopping();
        //                Console.WriteLine("Do you wnat to delete more toppings from pizza? Y/N");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //        }
        //        public void AddToppingsOnPizza(Pizza p)
        //        {
        //            while (true)
        //            {
        //                _menuCat.PrintToppingMenu();
        //                int index = GetNumberInputFromUser(_menuCat.Toppings.Count) - 1;
        //                p.Toppings.Add(_menuCat.Toppings[index]);
        //                Console.WriteLine(p);
        //                p.SeeTopping();
        //                Console.WriteLine("Do you want to add more toppings to pizza? Y/ENTER");
        //                if (!GetYesOrNoIput()) break;
        //            }
        //        }
        //#endregion
        //        #region Inputs
        //        public bool GetYesOrNoIput()
        //        {
        //            string input = Console.ReadKey().KeyChar.ToString().ToUpper();
        //            Console.WriteLine();
        //            if (input == "Y")
        //            {
        //                return true;
        //            }
        //            return false;
        //        }
        //        public int GetLongNumber()
        //        {
        //            bool valid = false;
        //            int inputNumber = 0;
        //            int MaxNumber = 100000000;
        //            while (!valid)
        //            {
        //                string input = Console.ReadLine();
        //                Console.WriteLine();
        //                try
        //                {
        //                    inputNumber = Int32.Parse(input);
        //                    valid = inputNumber <= MaxNumber;
        //                    if (inputNumber > MaxNumber) Console.WriteLine("Number was out of range");
        //                }
        //                catch (Exception)
        //                {

        //                    Console.WriteLine("Not a valid number");
        //                }

        //                if (valid) break;
        //            }
        //            return inputNumber;
        //        }
        //        public int GetNumberInputFromUser(int listCount)
        //        {
        //            bool valid = false;
        //            int inputNumber = 0;
        //            while (!valid)
        //            {
        //                string input = Console.ReadKey().KeyChar.ToString();
        //                Console.WriteLine();
        //                try
        //                {
        //                    inputNumber = Int32.Parse(input);
        //                    valid = inputNumber <= listCount;
        //                    if (inputNumber > listCount) Console.WriteLine("Number was out of range");
        //                }
        //                catch (FormatException)
        //                {

        //                    Console.WriteLine("Not a number");
        //                }

        //                if (valid) break;
        //            }
        //            return inputNumber;
        //        }
        //        #endregion
        //        #region Helping metoder
        //        public Pizza GetPizza(List<Pizza> pizzas)
        //        {
        //            int number = 1;
        //            foreach (var pizza in pizzas)
        //            {
        //                Console.WriteLine($"{number}. {pizza}");
        //                number++;
        //            }
        //            Pizza pizzaToReturn = pizzas[GetNumberInputFromUser(pizzas.Count) - 1];
        //            return pizzaToReturn;
        //        }

        //        public int MenuChoices(string str)
        //        {
        //            List<string> listMenu = new List<string>()
        //            {
        //                $"Add new {str}",
        //                $"Update {str}",
        //                $"Delete {str}",
        //                $"Search for {str}",
        //                $"Read {str}",
        //                $"See list of all {str}s",
        //                $"Back to top menu"
        //            };
        //            int number = 1;
        //            foreach (var item in listMenu)
        //            {
        //                Console.WriteLine($"{number}. {item}");
        //                number++;
        //            }
        //            int input = GetNumberInputFromUser(listMenu.Count);
        //            return input;
        //        }
        //        public int StringListChoice(List<string> list)
        //        {
        //            int number = 1;
        //            foreach (var str in list)
        //            {
        //                Console.WriteLine($"{number}. {str}");
        //                number++;
        //            }
        //            int numberToReturn = GetNumberInputFromUser(list.Count);
        //            return numberToReturn;
        //        }
        //        #endregion
        #endregion
    }
}
