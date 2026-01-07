using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.employeeWage
{
    





    internal class EmployeeMenu
    {
        // Interface reference for employee operations
        private IEmployee employeeUtility;

        // Constructor initializes utility and shows menu
        public EmployeeMenu()
        {
            employeeUtility = new EmployeeUtilityImpl(); // Create implementation object
            EmployeeChoice(); // Display menu
        }

        // Method to display menu and take user choice
        public void EmployeeChoice()
        {
            Console.WriteLine("1. Calculate Employee Wage");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()); // Read user input

            switch (choice)
            {
                case 1:
                    employeeUtility.AddEmployee(); // Call wage calculation
                    break;

                default:
                    Console.WriteLine("Invalid Choice"); // Invalid option
                    break;
            }
        }
    }
}