using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class OrderCatalog
    {
        private static List<Order> _orderList;
        private CustomerCatalog _cc;
        private MenuCatalog _mc;
        public OrderCatalog()
        {
            _orderList = new List<Order>();
            _cc = new CustomerCatalog();
            _mc = new MenuCatalog();
        }
        public List<Order> OrderList { get { return _orderList; } }   
        public void OrderStartMenu()
        {
            Console.WriteLine("ORDER MENU");
            int input = Store.MenuChoices("Order");
            if (input == 1) CreateDialog();
            if(_orderList.Count == 0)
            {
                Console.WriteLine("You have no orders");
                Store.TopMenu();
            }
            if (input == 2) UpdateDialog();
            if (input == 3) DeleteDialog();
            if (input == 4) SearchDialog();
            if (input == 5) ReadDialog();
            if (input == 6)
            {
                Console.WriteLine("List of all Orders");
                PrintOrderList();
                Console.WriteLine();
                OrderStartMenu();
            }
            if (input == 7) Store.TopMenu();
        }
        private void CreateDialog()
        {
            Console.WriteLine("MAKE ORDER");
            while (true)
            {
                Customer customerOfOrder = Store.GetCustomer(_cc.CustomerList);
                    Order newOrder = Create(customerOfOrder);
                    _mc.AddPizzasToOrder(newOrder);
                    newOrder.GetOrder();
                if (!Store.EndLoop("Create", "Order")) break;
            }
            OrderStartMenu();
        }
        private void UpdateDialog()
        {
            while (true)
            {
                Console.WriteLine("UPDATE ORDER");
                Order orderToUpdate = Store.GetOrder(_orderList);
                Console.WriteLine("What do you want to update?");
                List<string> l = new List<string>()
                {
                    "ID",
                    "Change Customer",
                    "Pizzas"
                };
                int whatToUpdate = Store.StringListChoice(l);
                switch (whatToUpdate)
                {
                    case 1:
                        {
                            Console.WriteLine("Type new ID");
                            int newID = Store.GetLongNumber();
                            orderToUpdate.ID = newID;
                            orderToUpdate.GetOrder();
                            break;
                        }
                    case 2:
                        {
                            while (true)
                            {
                                Console.WriteLine("Type name of customer");
                                _cc.PrintCustomerList();
                                string nameOfCustomer = Console.ReadLine();
                                Customer changedCustomer = _cc.Search(nameOfCustomer);
                                if (changedCustomer == null) Console.WriteLine("Not a customer");
                                else
                                {
                                    orderToUpdate.OrderCustomer = changedCustomer;
                                    Console.WriteLine(orderToUpdate);
                                    break;
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            List<string> list = new List<string>()
                    {
                        "Add Pizza",
                        "Delete Pizza",
                        "Change topping"
                    };
                            int input = Store.StringListChoice(list);
                            switch (input)
                            {
                                case 1:
                                    {
                                        _mc.AddPizzasToOrder(orderToUpdate);
                                        break;
                                    }
                                case 2:
                                    {
                                        while (true)
                                        {
                                            DeletePizzaFromOrder(orderToUpdate);
                                            Console.WriteLine("Delete more from order? Y/ENTER");
                                            if (!Store.GetYesOrNoIput())
                                            {
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Pizza pizzaToChange = Store.GetPizza(orderToUpdate.Pizzas);
                                        _mc.ChangeTopping(pizzaToChange);
                                        break;
                                    }
                            }
                            break;
                        }
                }
                orderToUpdate.GetOrder();
                Console.WriteLine("Has been updated");
                if (!Store.EndLoop("Update", "Order")) break;
            }
            OrderStartMenu();
        }
        private void DeleteDialog()
        {
            while (true)
            {
                Console.WriteLine("DELETE ORDER");
                Order orderToDelete = Store.GetOrder(_orderList);
                Delete(orderToDelete);
                _cc.DeleteCustomersOrder(orderToDelete.OrderCustomer, orderToDelete);
                Console.WriteLine($"Order {orderToDelete.ID} has been deleted");
                if (_orderList.Count == 0) break;
                if (!Store.EndLoop("Delete", "Order")) break;
            }
            OrderStartMenu();
        }
        private void SearchDialog()
        {
            while (true)
            {
                _cc.PrintCustomerList();
                string name = Store.GetName("customer");
                Search(name);
                if (!Store.EndLoop("Search for", "Order"))break;
            }
            OrderStartMenu();
        }
        private void ReadDialog()
        {
            
            Console.WriteLine("READ ORDER");
            PrintOrderList();
            while (true)
            {
                Console.WriteLine("Search for order by ID");
                int idToFind = Store.GetLongNumber();
            
                Order orderToRead = _orderList.Find(x => x.ID == idToFind);
                if (orderToRead == null) Console.WriteLine("Not found");
                else
                {
                    Console.WriteLine(orderToRead);
                    orderToRead.GetOrder();
                    if (!Store.EndLoop("Read", "Order")) break;
                }

            }
            OrderStartMenu();
        }
        public void PrintOrderList()
        {
            int number = 1;
            foreach (var order in _orderList)
            {
                order.GetOrder();
                Console.WriteLine();
                number++;
            }
        }
        public void Search(string name)
        {
            Customer cus = _cc.Search(name);
            if (cus == null) Console.WriteLine("Not a customer");
            else
            {
                if (cus.Orders.Count == 0) Console.WriteLine("This customer has no orders");
                foreach (var order in cus.Orders)
                {
                    order.GetOrder();
                }
            }
        }
        public Order Create(Customer customer)
        {
            Order o = new Order(customer);
            _orderList.Add(o);
            customer.Orders.Add(o);
            o.ID = _orderList.Count;
            return o;
        }
        public static void Delete(Order order)
        {
            _orderList.Remove(order);
        }
        public void DeletePizzaFromOrder(Order order)
        {
            Pizza pizzaToDelete = Store.GetPizza(order.Pizzas);
            order.Pizzas.Remove(pizzaToDelete);
        }


    }
}
