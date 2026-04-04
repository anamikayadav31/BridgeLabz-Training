using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.ambulance_route
{
    internal class HospitalMenu
    {
        // Utility class instance to handle hospital operations
        HospitalUtility utility = new HospitalUtility();

        // Displays the main menu and handles user interaction
        public void ShowMenu()
        {
            int choice; // Stores user's menu choice

            do
            {
                // Display menu options
                Console.WriteLine("\n--- Ambulance Route Menu ---");
                Console.WriteLine("1. Add Hospital Unit");
                Console.WriteLine("2. Display Route");
                Console.WriteLine("3. Redirect Patient");
                Console.WriteLine("4. Mark Unit Under Maintenance");
                Console.WriteLine("5. Remove Unit");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                // Read and parse user input
                choice = int.Parse(Console.ReadLine());

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        // Add a new hospital unit
                        Console.Write("Enter unit name: ");
                        utility.AddUnit(Console.ReadLine());
                        break;

                    case 2:
                        // Display all hospital units
                        utility.DisplayUnits();
                        break;

                    case 3:
                        // Redirect patient to another unit
                        utility.RedirectPatient();
                        break;

                    case 4:
                        // Mark a unit as under maintenance
                        Console.Write("Enter unit name: ");
                        utility.MarkUnderMaintenance(Console.ReadLine());
                        break;

                    case 5:
                        // Remove a hospital unit
                        Console.Write("Enter unit name: ");
                        utility.RemoveUnit(Console.ReadLine());
                        break;

                    case 6:
                        // Exit the system
                        Console.WriteLine("Exiting system...");
                        break;

                    default:
                        // Handle invalid menu choices
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            // Repeat menu until user chooses to exit
            while (choice != 6);
        }
    }
}