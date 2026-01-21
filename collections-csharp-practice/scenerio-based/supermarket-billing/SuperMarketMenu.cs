using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.supermarketBillingQueue
{
    internal class SuperMarketMenu
    {


        public void ShowMenu()
        {
            BillingUtility utility = new BillingUtility();

            while (true)
            {
                Console.WriteLine("\n---------- Supermarket Menu ----------");
                Console.WriteLine("1. Add items to supermarket");
                Console.WriteLine("2. Add customer to billing queue");
                Console.WriteLine("3. Remove customer from queue");
                Console.WriteLine("4. Process billing for customers");
                Console.WriteLine("5. Show current stock");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Enter a number between 1 and 6.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        utility.AddItems();
                        break;
                    case 2:
                        utility.AddCustomer();
                        break;
                    case 3:
                        utility.RemoveCustomer();
                        break;
                    case 4:
                        utility.ProcessBilling();
                        break;
                    case 5:
                        utility.UpdateStock();
                        break;
                    case 6:
                        Console.WriteLine("Exiting Supermarket System...");
                        return; // exit the loop
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
    }
}