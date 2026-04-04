using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.inheritance
{
    internal class EmployeeSystem
    {


        // Common employee variables
        public string employeeName;
        public int employeeId;
        public double employeeSalary;

        // Constructor to initialize employee details
        public EmployeeSystem(string employeeName, int employeeId, double employeeSalary)
        {
            this.employeeName = employeeName;
            this.employeeId = employeeId;
            this.employeeSalary = employeeSalary;
        }

        // Method to display common employee details
        public virtual void DisplayDetails()
        {
            Console.WriteLine("Name   : " + employeeName);
            Console.WriteLine("ID     : " + employeeId);
            Console.WriteLine("Salary : " + employeeSalary);
        }
    }

    // Manager class
    class Manager : EmployeeSystem
    {
        // Manager-specific variable
        public int managerTeamSize;

        public Manager(string employeeName, int employeeId, double employeeSalary, int managerTeamSize)
            : base(employeeName, employeeId, employeeSalary)
        {
            this.managerTeamSize = managerTeamSize;
        }

        // Override method
        public override void DisplayDetails()
        {
            Console.WriteLine("\nEmployee Type: Manager");
            base.DisplayDetails();
            Console.WriteLine("Team Size : " + managerTeamSize);
        }
    }

    // Developer class
    class Developer : EmployeeSystem
    {
        // Developer-specific variable
        public string programmingLanguage;

        public Developer(string employeeName, int employeeId, double employeeSalary, string programmingLanguage)
            : base(employeeName, employeeId, employeeSalary)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("\nEmployee Type: Developer");
            base.DisplayDetails();
            Console.WriteLine("Language  : " + programmingLanguage);
        }
    }

    // Intern class
    class Intern : EmployeeSystem
    {
        // Intern-specific variable
        public string internshipDuration;

        public Intern(string employeeName, int employeeId, double employeeSalary, string internshipDuration)
            : base(employeeName, employeeId, employeeSalary)
        {
            this.internshipDuration = internshipDuration;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("\nEmployee Type: Intern");
            base.DisplayDetails();
            Console.WriteLine("Duration  : " + internshipDuration);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Get employee type
            Console.WriteLine("Enter Employee Type (Manager / Developer / Intern):");
            string employeeType = Console.ReadLine();

            // Get common details
            Console.WriteLine("Enter Name:");
            string inputName = Console.ReadLine();

            Console.WriteLine("Enter ID:");
            int inputId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Salary:");
            double inputSalary = double.Parse(Console.ReadLine());

            // Parent class reference
            EmployeeSystem employee;

            // Create object based on employee type
            if (employeeType.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter Team Size:");
                int teamSizeInput = int.Parse(Console.ReadLine());

                employee = new Manager(inputName, inputId, inputSalary, teamSizeInput);
            }
            else if (employeeType.Equals("Developer", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter Programming Language:");
                string languageInput = Console.ReadLine();

                employee = new Developer(inputName, inputId, inputSalary, languageInput);
            }
            else if (employeeType.Equals("Intern", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter Internship Duration:");
                string durationInput = Console.ReadLine();

                employee = new Intern(inputName, inputId, inputSalary, durationInput);
            }
            else
            {
                Console.WriteLine("Invalid Employee Type");
                return;
            }

            // Polymorphism in action
            employee.DisplayDetails();
        }
    }
}
