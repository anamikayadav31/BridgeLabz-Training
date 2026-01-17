using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.FlashDealz
{
    internal class DealsMenu
    {
         public void  ShowMenu()
        {
            ProductUtility system = new ProductUtility();
            int choice;
            while (true)
            {
                // Display menu options
                Console.WriteLine("\n--- FlashDealz Menu ---");
                Console.WriteLine("1. Add product:");
                Console.WriteLine("2. Sort the products based on discounts");
                Console.WriteLine("3.Display products");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                // Read user choice
                choice = int.Parse(Console.ReadLine());

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        system.AddProductDetails();
                        break;
                    case 2:
                        system.QuickSort();
                        break;
                    case 3:
                        system.DisplayProducts();
                        break;
                    case 4:
                        Console.WriteLine("Exiting SuccessFully");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

        }
    }
}