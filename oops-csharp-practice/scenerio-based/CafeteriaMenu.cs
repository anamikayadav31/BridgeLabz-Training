using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{
    internal class CafeteriaMenu
    {

        // Stores fixed 10 menu items
        private string[] foodMenu = new string[10];

        // Owner adds food items
        public void AddMenuItems()
        {
            Console.WriteLine("\nOwner: Enter 10 Food Items");
            for (int i = 0; i < foodMenu.Length; i++)
            {
                Console.Write("Enter item " + (i + 1) + ": ");
                foodMenu[i] = Console.ReadLine();
            }
            Console.WriteLine("Menu updated successfully!");
        }

        // Display all menu items
        public void ShowMenu()
        {
            Console.WriteLine("\nCafeteria Menu:");
            for (int i = 0; i < foodMenu.Length; i++)
            {
                Console.WriteLine(i + ". " + foodMenu[i]);
            }
        }

        // Get food item by index
        public string GetMenuItem(int itemIndex)
        {
            if (itemIndex >= 0 && itemIndex < foodMenu.Length)
                return foodMenu[itemIndex];
            else
                return "Invalid item number!";
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            CafeteriaMenu cafeteria = new CafeteriaMenu();
            bool isMenuAvailable = false; // checks if owner added items

            while (true)
            {
                // Login options
                Console.WriteLine("\nLogin Menu:");
                Console.WriteLine("1. Owner");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int loginOption = int.Parse(Console.ReadLine());

                switch (loginOption)
                {
                    // Owner section
                    case 1:
                        bool ownerMenuActive = true;
                        while (ownerMenuActive)
                        {
                            Console.WriteLine("\nOWNER PANEL:");
                            Console.WriteLine("1. Add Food Items");
                            Console.WriteLine("2. View Menu");
                            Console.WriteLine("3. Back");
                            Console.Write("Enter choice: ");
                            int ownerOption = int.Parse(Console.ReadLine());

                            switch (ownerOption)
                            {
                                case 1:
                                    cafeteria.AddMenuItems();
                                    isMenuAvailable = true;
                                    break;

                                case 2:
                                    if (isMenuAvailable)
                                        cafeteria.ShowMenu();
                                    else
                                        Console.WriteLine("Please add menu items first!");
                                    break;

                                case 3:
                                    ownerMenuActive = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        }
                        break;

                    // Customer section
                    case 2:
                        if (!isMenuAvailable)
                        {
                            Console.WriteLine("Menu not available yet. Contact owner.");
                            break;
                        }

                        bool customerMenuActive = true;
                        while (customerMenuActive)
                        {
                            Console.WriteLine("\nCUSTOMER PANEL:");
                            Console.WriteLine("1. Order Items");
                            Console.WriteLine("2. Back");
                            Console.Write("Enter choice: ");
                            int customerOption = int.Parse(Console.ReadLine());

                            switch (customerOption)
                            {
                                case 1:
                                    cafeteria.ShowMenu();

                                    Console.Write("\nEnter number of items to order: ");
                                    int orderCount = int.Parse(Console.ReadLine());

                                    Console.WriteLine("\nYour Order:");
                                    for (int i = 0; i < orderCount; i++)
                                    {
                                        Console.Write("Enter item index " + (i + 1) + ": ");
                                        int selectedIndex = int.Parse(Console.ReadLine());
                                        Console.WriteLine("- " + cafeteria.GetMenuItem(selectedIndex));
                                    }

                                    Console.WriteLine("\nThank you for ordering!");
                                    break;

                                case 2:
                                    customerMenuActive = false;
                                    break;

                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        }
                        break;

                    // Exit system
                    case 3:
                        Console.WriteLine("System Closed. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option! Try again.");
                        break;
                }
            }
        }
    }
}


