using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.AadharNumber
{
    internal class AadharMenu
    {
       
            // Method to show menu and handle user actions
            public void ShowMenu()
            {
                // Create an object of AdharUtility which implements Aadhaar operations
                AadharUtility utility = new AadharUtility();
                int choice;

                // Infinite loop to keep showing menu until user chooses to exit
                while (true)
                {
                    // Display menu options
                    Console.WriteLine("\n--- Aadhaar System Menu ---");
                    Console.WriteLine("1. Input Aadhaar Numbers");
                    Console.WriteLine("2. Display Aadhaar Numbers");
                    Console.WriteLine("3. Sort Aadhaar Numbers");
                    Console.WriteLine("4. Search Aadhaar Number");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter choice: ");

                    // Read user input
                    choice = int.Parse(Console.ReadLine());

                    // Perform action based on user choice
                    switch (choice)
                    {
                        case 1:
                            utility.Input();     // Take Aadhaar numbers input
                            break;
                        case 2:
                            utility.Display();   // Display all Aadhaar numbers
                            break;
                        case 3:
                            utility.RadixSort(); // Sort numbers using Radix Sort
                            Console.WriteLine("Aadhaar numbers sorted successfully.");
                            break;
                        case 4:
                            utility.BinarySearch(); // Search for a specific Aadhaar number
                            break;
                        case 5:
                            Console.WriteLine("Exiting successfully");
                            return; // Exit the menu loop
                        default:
                            Console.WriteLine("Invalid choice"); // Handle wrong input
                            break;
                    }
                }
            }
        }
    }

