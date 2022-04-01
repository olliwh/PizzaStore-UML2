using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public class OrderCatalog
    {
        private List<Order> _orderList;
        private CustomerCatalog _cc;
        private MenuCatalog _mc;
        public OrderCatalog()
        {
            _orderList = new List<Order>();
            _cc = new CustomerCatalog();
            _mc = new MenuCatalog();
        }
        public List<Order> OrderList { get { return _orderList; } }   
        public void OrderMenu()
        {
            Console.WriteLine("ORDER MENU");
            int input = UserInput.MenuChoices("Order");
            if (input == 1) CreateOrder();
            if(_orderList.Count == 0)
            {
                Console.WriteLine("You have no orders");
                Store.TopMenu();
            }
            if (input == 2) UpdateOrder();
            if (input == 3) DeleteOrder();
            if (input == 4) SearchOrder();
            if (input == 5) ReadOrder();
            if (input == 6) PrintOrders();
            if (input == 7) Store.TopMenu();
        }
        public void CreateOrder()
        {
            Console.WriteLine("MAKE ORDER");
            while (true)
            {
                _cc.PrintCustomerList();
                Console.WriteLine("Write number of customer");
                int index = UserInput.GetNumberInputFromUser(_cc.CustomerList.Count) - 1;
                Customer customerOfOrder = _cc.CustomerList[index];

                if (customerOfOrder == null) Console.WriteLine("Not Found");
                else
                {
                    Order newOrder = CreateOrder(customerOfOrder);
                    _mc.AddPizzasToOrder(newOrder);

                }
                if (!UserInput.EndLoop("Create", "Order")) break;
            }
            OrderMenu();
        }
        public Order CreateOrder(Customer customer)
        {
            Order o = new Order(customer);
            _orderList.Add(o);
            customer.Orders.Add(o);
            o.ID = _orderList.Count;
            return o;
        }
        public void UpdateOrder()
        {
            while (true)
            {
                Console.WriteLine("UPDATE ORDER");
                Console.WriteLine("What order would you like to update?");
                PrintAllOrders();
                int index = UserInput.GetNumberInputFromUser(OrderList.Count) - 1;
                Order orderToUpdate = OrderList[index];
                Console.WriteLine("What do you want to update?");
                List<string> l = new List<string>()
                {
                    "ID",
                    "Customer",
                    "Pizzas"
                };
                int whatToUpdate = UserInput.StringListChoice(l);
                switch (whatToUpdate)
                {
                    case 1:
                        {
                            Console.WriteLine("Type new ID");
                            int newID = UserInput.GetLongNumber();
                            orderToUpdate.ID = newID;
                            Console.WriteLine(orderToUpdate);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Do you want to make a new customer first?");
                            if (UserInput.GetYesOrNoIput()) _cc.CreateCustomer();
                            else
                            {
                                Console.WriteLine("Type name of customer");
                            string nameOfCustomer = Console.ReadLine();
                            Customer newCustomer = _cc.Search(nameOfCustomer);
                            orderToUpdate.OrderCustomer = newCustomer;
                            Console.WriteLine(orderToUpdate);
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
                            int input = UserInput.StringListChoice(list);
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
                                            RemovePizzaFromOrder(orderToUpdate);
                                            Console.WriteLine("Delete more from order? Y/ENTER");
                                            if (!UserInput.GetYesOrNoIput())
                                            {
                                                orderToUpdate.PrintOrder();
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Pizza pizzaToChange = UserInput.GetPizza(orderToUpdate.Pizzas);
                                        _mc.ChangeTopping(pizzaToChange);
                                        break;
                                    }
                            }
                            break;
                        }
                }
                orderToUpdate.PrintOrder();
                Console.WriteLine("Has been updated");
                if (!UserInput.EndLoop("Update", "Order")) break;
            }
            OrderMenu();
        }

        public void RemovePizzaFromOrder(Order order)
        {
            int number = 1;
            foreach (var pizza in order.Pizzas)
            {
                Console.WriteLine($"{number}. {pizza}");
                number++;
            }
            Console.WriteLine("What pizza do you want to delete?");
            int index = UserInput.GetNumberInputFromUser(order.Pizzas.Count) - 1;
            Pizza pizzaToDelete = order.Pizzas[index];
            order.Pizzas.Remove(pizzaToDelete);
        }
        public void DeleteOrder()
        {
            while (true)
            {
                Console.WriteLine("DELETE ORDER");
                Console.WriteLine("What order do you want to Delete?");
                PrintAllOrders();
                int input = UserInput.GetNumberInputFromUser(OrderList.Count);
                Order orderToDelete = OrderList[input - 1];
                _orderList.Remove(orderToDelete);
                Console.WriteLine($"Order {orderToDelete.ID} has been deleted");
                if (_orderList.Count == 0) break;
                if (!UserInput.EndLoop("Delete", "Order")) break;
            }
            OrderMenu();
        }

        public void SearchOrder()
        {
            while (true)
            {
                Console.WriteLine("Write name of cusomer");

                _cc.PrintCustomerList();
                string name = Console.ReadLine();
                SearchOrder(name);
                if (!UserInput.EndLoop("Search for", "Order"))break;
            }
            OrderMenu();
        }
        public void SearchOrder(string name)
        {
            Customer cus = _cc.Search(name);
            if (cus == null) Console.WriteLine("net a customer");
            else
            {
                if (cus.Orders.Count == 0) Console.WriteLine("This customr has no orders");
                foreach (var order in cus.Orders)
                {
                    order.PrintOrder();
                }
            }
        }

        public void ReadOrder()
        {
            while (true)
            {
                Console.WriteLine("READ ORDER");
                PrintAllOrders();
                Console.WriteLine("Search for order by ID");
                int idToFind = UserInput.GetLongNumber();

                Order orderToRead = _orderList.Find(x => x.ID == idToFind);

                Console.WriteLine(orderToRead);
                orderToRead.PrintOrder();
                if (!UserInput.EndLoop("Read", "Order"))break;

            }
            OrderMenu();
        }
        public void PrintAllOrders()
        {
            int number = 1;
            foreach (var order in _orderList)
            {
                Console.WriteLine($"Nr. {number}.");
                Console.WriteLine($"ID: {order.ID}   {order.OrderCustomer.Name}");
                order.PrintOrder();
                Console.WriteLine();
                number++;
            }
        }
        public void PrintOrders()
        {
            PrintAllOrders();
            OrderMenu();
        }


    }
}
