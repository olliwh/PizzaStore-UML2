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
        #region Methods
        public void CustomerStartMenu()
        {
            Console.WriteLine("CUSTOMER MENU");
            int choice = Store.MenuChoices("Customer");
            if (choice == 1) CreateDialog();
            if(_customerList.Count == 0)
            {
                Console.WriteLine("You have no Customers");
                Store.TopMenu();
            }
            if (choice == 2) UpdateDialog();
            if (choice == 3) DeleteCustomer();
            if (choice == 4) SearchDialog();
            if (choice == 5) ReadDialog();
            if (choice == 6)
            {
                Console.WriteLine("LIST OF CUSTOMERS");
                PrintCustomerList();
                Console.WriteLine();
                CustomerStartMenu();
            }
            if (choice == 7) Store.TopMenu();
        }
        private void CreateDialog()
        {
            while (true)
            {
                Console.WriteLine("CREATE CUSTOMER");
                string name = Store.GetName("Customer");
                string mail = Store.GetMail();
                Console.WriteLine("Type phone number and press enter");
                int phone = Store.GetLongNumber();
                while (phone < 10000000) 
                {
                    Console.WriteLine("Must be 8 charecters");
                    phone = Store.GetLongNumber();
                }
                Customer c = Create(name, mail, phone);
                c.GetCustomer();
                Console.WriteLine($"was created");
                if (!Store.EndLoop("Create", "Customer")) break;
            }
            CustomerStartMenu();
        }
        private void UpdateDialog()
        {
            while (true)
            {
                Console.WriteLine("UPDATE CUSTOMER");
                Customer customerToUpdate = Store.GetCustomer(_customerList);
                Console.WriteLine(customerToUpdate);
                Console.WriteLine("What do you want to update?");
                List<string> list = new List<string>()
                {
                    "Name",
                    "Mail",
                    "Phone"
                };
                int whatToUpdate = Store.StringListChoice(list);
                switch (whatToUpdate)
                {
                    case 1:
                        {
                            customerToUpdate.Name = Store.GetName("Customer");
                            break;
                        }
                    case 2:
                        {
                            customerToUpdate.Mail = Store.GetMail();
                            break;  
                        }
                    case 3:
                        {
                            Console.WriteLine("Type phone number of customer and press enter");
                            int phone = Store.GetLongNumber();
                            customerToUpdate.PhoneNumber = phone;
                            break;
                        }
                }
                customerToUpdate.GetCustomer();
                Console.WriteLine("was updated");
                if (!Store.EndLoop("Update", "Customer")) break;
            }
            CustomerStartMenu();
        }
        private void DeleteCustomer()
        {
            while (true)
            {
                Console.WriteLine("DELETE CUSTOMER");
                Customer customerToDelete =  Store.GetCustomer(_customerList);
                _customerList.Remove(customerToDelete);
                foreach(var order in customerToDelete.Orders)
                {
                    OrderCatalog.Delete(order);
                }
                customerToDelete.GetCustomer();
                Console.WriteLine($"has been Deleted");
                if (_customerList.Count == 0) break;
                if (!Store.EndLoop("Delete", "Customer")) break;
            }
            CustomerStartMenu();
        }
        private void SearchDialog()
        {
            while (true)
            {
                Console.WriteLine("CUSTOMER SEARCH BY NAME");
                PrintCustomerList();
                string name = Store.GetName("Customer");
                Customer customerToFind =  Search(name);
                if (customerToFind == null) Console.WriteLine("Not Found");
                else
                {
                    customerToFind.GetCustomer();
                    if (!Store.EndLoop("Search for", "Customer")) break;
                }
            }
            CustomerStartMenu();
        }
        private void ReadDialog()
        {
            while (true)
            {
                Console.WriteLine("READ CUSTOMER");
                Console.WriteLine("Search for Customer by phone number");
                PrintCustomerList();
                int phoneNumber = Store.GetLongNumber();
                Customer customerToRead = _customerList.Find(x => x.PhoneNumber == phoneNumber);
                if (customerToRead == null) Console.WriteLine("Not found");
                else
                {
                    customerToRead.GetCustomer();
                    Console.WriteLine("Du you want to Read another Customer? Y/ENTER");
                    if (!Store.GetYesOrNoIput()) break;
                }
            }
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
        public Customer Search(string name)
        {
            Customer customerToFind = _customerList.Find(x => x.Name == name);
            return customerToFind;
        }
        public Customer Create(string name, string mail, int phone)
        {
            Customer customer = new Customer(name, mail, phone);
            _customerList.Add(customer);
            return customer;
        }
        public void DeleteCustomersOrder(Customer customer, Order orderToDelete)
        {
            customer.Orders.Remove(orderToDelete);
        }
        #endregion
    }
}
