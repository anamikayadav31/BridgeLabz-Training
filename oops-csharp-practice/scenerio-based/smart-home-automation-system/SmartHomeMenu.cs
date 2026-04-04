using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation
{
    // Handles user interaction and menu options
    internal class SmartHomeMenu
    {
        // Stores the currently active appliance
        private Appliance currentAppliance;

        // Displays menu repeatedly
        public void ShowMenu()
        {
            while (true)
            {
                // Display menu options
                Console.WriteLine("\n===== Smart Home Automation =====");
                Console.WriteLine("1. Turn ON Light");
                Console.WriteLine("2. Turn ON Fan");
                Console.WriteLine("3. Turn ON AC");
                Console.WriteLine("4. Turn OFF Appliance");
                Console.WriteLine("5. Exit");

                // Ask user for input
                Console.Write("Enter your choice: ");

                // Validate numeric input
                bool isValid = int.TryParse(Console.ReadLine(), out int choice);

                // If input is invalid
                if (!isValid)
                {
                    Console.WriteLine("⚠️ Please enter a valid number.");
                    continue;
                }

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        currentAppliance = new Light(); // Create Light object
                        currentAppliance.TurnOn();
                        break;

                    case 2:
                        currentAppliance = new Fan(); // Create Fan object
                        currentAppliance.TurnOn();
                        break;

                    case 3:
                        currentAppliance = new AC(); // Create AC object
                        currentAppliance.TurnOn();
                        break;

                    case 4:
                        // Turn OFF currently active appliance
                        if (currentAppliance != null)
                            currentAppliance.TurnOff();
                        else
                            Console.WriteLine(" No appliance is currently ON.");
                        break;

                    case 5:
                        // Exit from application
                        Console.WriteLine(" Exiting Smart Home System...");
                        return;

                    default:
                        // Handle invalid menu choice
                        Console.WriteLine(" Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
