using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.oopsKeywordsOperator
{
    internal class Employee
    {


        // static variable: shared company name
        public static string CompanyName;

        // static variable to count total employees
        private static int TotalEmployees = 0;

        // readonly employee ID (cannot change after creation)
        public readonly int EmployeeId;

        // normal variables
        public string EmployeeName;
        public string EmployeeRole;

        // Constructor using 'this' keyword
        public Employee(int employeeId, string employeeName, string employeeRole)
        {
            this.EmployeeId = employeeId;       // refers to current object
            this.EmployeeName = employeeName;
            this.EmployeeRole = employeeRole;

            TotalEmployees++;                   // increase total employee count
        }

        // Static method to display total employees
        public static void ShowTotalEmployees()
        {
            Console.WriteLine("\nTotal Employees in " + CompanyName + " : " + TotalEmployees);
        }

        // Display employee details
        public void ShowDetails()
        {
            Console.WriteLine("\nEmployee Information:");
            Console.WriteLine("Company Name   : " + CompanyName);
            Console.WriteLine("Employee ID    : " + EmployeeId);
            Console.WriteLine("Employee Name  : " + EmployeeName);
            Console.WriteLine("Designation    : " + EmployeeRole);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Management System\n");

            // Ask company name
            Console.Write("Enter Company Name: ");
            Employee.CompanyName = Console.ReadLine();

            // Ask number of employees to create
            Console.Write("\nHow many employees do you want to add? : ");
            int numEmployees = int.Parse(Console.ReadLine());

            // Array to store employee objects
            Employee[] employeeArray = new Employee[numEmployees];

            // Input details for each employee
            for (int i = 0; i < numEmployees; i++)
            {
                Console.WriteLine($"\nEnter details for Employee {i + 1}:");

                Console.Write("Employee ID      : ");
                int empId = int.Parse(Console.ReadLine());

                Console.Write("Employee Name    : ");
                string empName = Console.ReadLine();

                Console.Write("Designation      : ");
                string empRole = Console.ReadLine();

                // Create Employee object and store in array
                employeeArray[i] = new Employee(empId, empName, empRole);
            }

            // Display details of all employees using 'is' keyword
            Console.WriteLine("\nEmployee Details");
            for (int i = 0; i < numEmployees; i++)
            {
                if (employeeArray[i] is Employee)
                {
                    employeeArray[i].ShowDetails();
                }
            }

            // Show total employees
            Employee.ShowTotalEmployees();

            Console.WriteLine("\nThank you for using Employee Management System!");
        }
    }
}
