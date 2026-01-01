using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class EmployeeRecords
    {
        public int Id;             // public
        protected string Dept;     // protected
        private double Salary;     // private

        // Constructor
        public EmployeeRecords(int id, string department, double salary)
        {
            Id = id;
            Dept = department;
            Salary = salary;
        }

        // Method to update salary
        public void SetSalary(double newSalary)
        {
            Salary = newSalary;
        }

        // Method to get salary
        public double GetSalary()
        {
            return Salary;
        }
        
        public static void Main(string[] args)
        {
            // User input
            Console.Write("Enter Employee ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            // Create Manager object
            Manager manager = new Manager(id, dept, salary);

            // Display details
            manager.ShowDetails();

            // Update salary
            Console.Write("\nEnter new salary to update: ");
            double newSalary = Convert.ToDouble(Console.ReadLine());
            manager.SetSalary(newSalary);

            Console.WriteLine("Updated Salary: " + manager.GetSalary());
        }
    }


  
          


    // Derived class
    internal class Manager : EmployeeRecords
    {
        public Manager(int id, string department, double salary)
            : base(id, department, salary)
        {
        }

        // Display manager details
        public void ShowDetails()
        {
            Console.WriteLine("\n--- Manager Details ---");
            Console.WriteLine("Employee ID: " + Id);
            Console.WriteLine("Department: " + Dept);
            Console.WriteLine("Salary: " + GetSalary());
        }
    }

          

    

}
