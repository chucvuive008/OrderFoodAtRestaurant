using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuItem = File.ReadAllLines("menu.txt");
            Food[] foodItems = new Food[menuItem.Length];
            List<Table> table = new List<Table>();
            int NumberOfCustomer = 0;

            for(int i= 0; i < menuItem.Length; i++)
            {
                string[] tokens = menuItem[i].Split(',');
         

                foodItems[i] = new Food();
                foodItems[i]._id = Convert.ToInt16(tokens[0]);
                foodItems[i]._name = tokens[1];
                foodItems[i]._price = Convert.ToDouble(tokens[2]);
                foodItems[i]._foodType = tokens[3];
            }

            for (int i = 0; i < menuItem.Length; i++)
            {
                Console.WriteLine("{0}     {1}     {2}     {3}", foodItems[i]._id, foodItems[i]._name, foodItems[i]._price, foodItems[i]._foodType);
            }
            try
            {
                Console.WriteLine("What is the table number?");

               

                table.Add(new Table(Convert.ToInt16(Console.ReadLine())));

                Console.WriteLine("How many customer in the table");

                NumberOfCustomer = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception )
            {
                Console.WriteLine("Please enter number not character");
            }

            for (int i = 0; i < NumberOfCustomer; i++)
            {
                table[0]._customer.Add(new Customer());

                Console.WriteLine("Which food customer {0} is ordered?", i+1);

                string orderItem="";

                int j = 0;

                while (orderItem.ToLower() != "end")
                {
                    Program p = new Program();
                    table[0]._customer[i]._foodItem.Add(new Food());
                    int index = p.searchFood(foodItems);
                    if (index == -1)
                    {
                        Console.WriteLine("You have put incorrect food item. Please look up at the menu above and retype the food");
                        orderItem = "";
                    }
                    else
                    {
                        table[0]._customer[i]._foodItem[j] = foodItems[index];
                        Console.WriteLine(table[0]._customer[i]._foodItem[j]._name);

                        Console.WriteLine("type anything to order more, type end if no more order is made ");
                        orderItem = Console.ReadLine();
                        j++;
                    }
                }
            }

            string bill = "";
            while (bill != "same" && bill != "seperate")
            {
                Console.WriteLine("Do you want to have same bill or seperate?(type same or seperate)");
                bill = Console.ReadLine().ToLower();

                if (bill != "same" && bill != "seperate")
                {
                    Console.WriteLine("unrecognize command.");
                }
            }
            if (bill == "same")
            {
                Console.WriteLine("Total: {0}",table[0].TableReceipt());
            }
            else if (bill == "seperate")
            {
                for (int i = 0; i < table[0]._customer.Count(); i++)
                {
                    Console.WriteLine("Total for Customer {0} : {1}", i + 1, table[0]._customer[i].FoodCost());
                }
            }
            Console.ReadLine();
        }

        public int searchFood(Food [] foodMenu)
        {
            int index = -1;
            string orderItem ="";
            while (orderItem != "name" && orderItem != "number")
            {
                Console.Write("Get Food by name or by number\n");

                orderItem = Console.ReadLine();
            }
            if(orderItem == "name")
            {
                Console.WriteLine("Please order the food name in the menu above");
                orderItem = Console.ReadLine();
                for (int i = 0; i < foodMenu.Length; i++)
                {
                    if (string.Equals(foodMenu[i]._name, orderItem, StringComparison.OrdinalIgnoreCase))
                    {
                        index = i;
                        break;
                    }  
                }
            }
            else if (orderItem.ToLower() == "number")
            {
                Console.WriteLine("Please type the food number in the menu above");
                orderItem = Console.ReadLine();
                int idItem = Convert.ToInt16(orderItem);

                for (int i = 0; i < foodMenu.Length; i++)
                {
                    if (foodMenu[i]._id == idItem)
                    {
                        index = i;
                        break;
                    }

                }
            }

            return index;
        }
    }
}
