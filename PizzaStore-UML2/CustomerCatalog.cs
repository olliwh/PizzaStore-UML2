using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class CustomerCatalog
    {
        private static List<Customer> _customerList;
        public CustomerCatalog()
        {
            _customerList = new List<Customer>();
        }
        public List<Customer> CustomerList { get { return _customerList; } }
        #region Customer
        public void CustomerStartMenu()
        {
            Console.WriteLine("CUSTOMER MENU");
            int choice = UserInput.MenuChoices("Customer");
            if (choice == 1) CreateCustomer();
            if(_customerList.Count == 0)
            {
                Console.WriteLine("You have no Customers");
                Store.TopMenu();
            }
            if (choice == 2) UpdateCustomer();
            if (choice == 3) DeleteCustomer();
            if (choice == 4) SearchForCustomer();
            if (choice == 5) ReadCustomer();
            if (choice == 6) SeeCustomerList();
            if (choice == 7) Store.TopMenu();
            else Console.WriteLine("The END");
        }
        public void CreateCustomer()
        {
            while (true)
            {
                Console.WriteLine("CREATE CUSTOMER");
                string name = UserInput.GetName("Customer");
                Console.WriteLine("Type mail and press enter");
                string mail = Console.ReadLine();
                Console.WriteLine("Type phone number and press enter");
                int phone = UserInput.GetLongNumber();
                Customer c =  Create(name, mail, phone);
                Console.WriteLine($"{c.Name} was created");
                if (!UserInput.EndLoop("Create", "Customer")) break;
            }
            CustomerStartMenu();
        }
        public Customer Create(string name, string mail, int phone)
        {
            Customer customer = new Customer(name, mail, phone);
            _customerList.Add(customer);
            return customer;
        }
        public void UpdateCustomer()
        {
            while (true)
            {
                Console.WriteLine("UPDATE CUSTOMER");
                 PrintCustomerList();
                Console.WriteLine("Sellect number of customer you want to update and press enter");
                Customer customerToUpdate =  CustomerList[UserInput.GetNumberInputFromUser( CustomerList.Count) - 1];
                Console.WriteLine(customerToUpdate);
                Console.WriteLine("What do you want to update?");
                List<string> list = new List<string>()
                {
                    "Name",
                    "Mail",
                    "Phone"
                };
                int whatToUpdate = UserInput.StringListChoice(list);
                switch (whatToUpdate)
                {
                    case 1:
                        {
                            customerToUpdate.Name = UserInput.GetName("Customer");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Type mail of customer and press enter");
                            string mail = Console.ReadLine();
                            customerToUpdate.Mail = mail;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Type phone number of customer and press enter");
                            int phone = UserInput.GetLongNumber();
                            customerToUpdate.PhoneNumber = phone;
                            break;
                        }
                }
                if (!UserInput.EndLoop("Update", "Customer")) break;
            }
            CustomerStartMenu();
        }
        public void DeleteCustomer()
        {
            while (true)
            {
                Console.WriteLine("DELETE CUSTOMER");
                 PrintCustomerList();
                Console.WriteLine("Sellect number of customer you want to Delete and press enter");
                Customer customerToDelete =  CustomerList[UserInput.GetNumberInputFromUser( CustomerList.Count) - 1];
                _customerList.Remove(customerToDelete);
                Console.WriteLine($"{customerToDelete} has been Deleted");
                if (_customerList.Count == 0) break;
                if (!UserInput.EndLoop("Delete", "Customer")) break;
            }
            CustomerStartMenu();
        }
        public void SearchForCustomer()
        {
            while (true)
            {
                Console.WriteLine("CUSTOMER SEARCH");
                 PrintCustomerList();
                Console.WriteLine("Search for customer by name");
                string name = Console.ReadLine();
                Customer customerToFind =  Search(name);
                if (customerToFind == null) Console.WriteLine("Not Found");
                else
                {
                    Console.WriteLine(customerToFind);
                    foreach(var order in customerToFind.Orders)
                    {
                        order.PrintOrder();
                    }
                    if (!UserInput.EndLoop("Search for", "Customer")) break;
                }
            }
            CustomerStartMenu();
        }
        public Customer Search(string name)
        {
            Customer customerToFind = _customerList.Find(x => x.Name == name);
            return customerToFind;
        }
        public void ReadCustomer()
        {
            while (true)
            {
                Console.WriteLine("READ CUSTOMER");
                Console.WriteLine("Search for Customer by phone number");
                PrintCustomerList();
                int phoneNumber = UserInput.GetLongNumber();
                Customer customerToRead = _customerList.Find(x => x.PhoneNumber == phoneNumber);
                Console.WriteLine(customerToRead);
                customerToRead.PrintOrder();
                Console.WriteLine("Du you want to Read another Customer? Y/ENTER");
                if (!UserInput.GetYesOrNoIput()) break;
            }
        }
        public void SeeCustomerList()
        {
            Console.WriteLine("LIST OF CUSTOMERS");
            PrintCustomerList();
            CustomerStartMenu();
        }
        public void PrintCustomerList()
        {
            int number = 1;
            foreach (var customer in _customerList)
            {
                Console.WriteLine($"{number}. {customer}");
                number++;
            }
        }
        #endregion
    }
}
