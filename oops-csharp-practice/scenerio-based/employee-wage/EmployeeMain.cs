using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.employeeWage
{
    
    internal class EmployeeMain
    {
        // Reference for menu class
        private EmployeeMenu employeeMenu;

        // Program execution starts here
        public static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Welcome to Employee Wage Computation Program\n");

            // Create menu object to show options
            new EmployeeMenu();

            // Exit message
            Console.WriteLine("\nThank You");
        }
    }
}