/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.flashDealz
{
        internal class DealMenu
        {
            public void ShowMenu()
            {
                DealUtility utility = new DealUtility();

                while (true)
                {
                    Console.WriteLine("  Welcome to Flash Dealz ");
                    Console.WriteLine("1. Add a product");
                    Console.WriteLine("2. View all products");
                    Console.WriteLine("3. View products sorted by discount");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice (1-4): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            utility.AddProduct();
                            break;

                        case "2":
                            utility.ViewProduct();
                            break;

                        case "3":
                            utility.ShowDiscount();
                            break;

                        case "4":
                            Console.WriteLine(" Exiting Flash Dealz Application...");
                            return;

                        default:
                            Console.WriteLine(" Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }*/




