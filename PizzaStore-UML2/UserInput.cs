using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore_UML2
{
    public static class UserInput
    {
        #region Inputs
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
        public static bool EndLoop(string action, string type)
        {
            Console.WriteLine();
            Console.WriteLine($"Du you want to {action} another {type}? Y/ENTER");
            return GetYesOrNoIput();
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
                string input = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();
                try
                {
                    inputNumber = Int32.Parse(input);
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
        public static Pizza GetPizza(List<Pizza> pizzas)
        {
            int number = 1;
            //if (pizzas.Count == 0) Console.WriteLine("You have no pizzas");
            
                foreach (var pizza in pizzas)
                {
                    Console.WriteLine($"{number}. {pizza}");
                    number++;
                }
            Pizza pizzaToReturn = pizzas[GetNumberInputFromUser(pizzas.Count) - 1];
            return pizzaToReturn;
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
        public static string GetName(string type)
        {
            string name = string.Empty;
            while(name == string.Empty)
            {
                Console.WriteLine($"Type name of {type}");
                name = Console.ReadLine(); 
            }
            return name;
        }
        #endregion
    }
}
