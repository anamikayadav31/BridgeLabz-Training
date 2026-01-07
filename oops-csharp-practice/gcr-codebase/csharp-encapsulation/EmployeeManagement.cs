using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{
    using System;

    // Interface for Department management
    interface IDepartment
    {
        void AssignDepartment(string deptName);
        string GetDepartmentDetails();
    }

    // Abstract Employee class
    abstract class Employee
    {
        // Encapsulated fields
        private int employeeId;
        private string name;
        private double baseSalary;

        // Properties
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double BaseSalary
        {
            get { return baseSalary; }
            set { baseSalary = value; }
        }

        // Constructor
        public Employee(int id, string name, double salary)
        {
            EmployeeId = id;
            Name = name;
            BaseSalary = salary;
        }

        // Abstract method to calculate salary
        public abstract double CalculateSalary();

        // Concrete method to display details
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeId}, Name: {Name}, Base Salary: {BaseSalary:C}");
        }
    }

    // Full-time Employee class
    class FullTimeEmployee : Employee, IDepartment
    {
        private string department;

        public FullTimeEmployee(int id, string name, double salary)
            : base(id, name, salary) { }

        public override double CalculateSalary()
        {
            return BaseSalary;
        }

        public void AssignDepartment(string deptName)
        {
            department = deptName;
        }

        public string GetDepartmentDetails()
        {
            return department;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Type: Full-Time, Department: {GetDepartmentDetails()}, Total Salary: {CalculateSalary():C}");
        }
    }

    // Part-time Employee class
    class PartTimeEmployee : Employee, IDepartment
    {
        private string department;
        private int hoursWorked;
        private double hourlyRate;

        public PartTimeEmployee(int id, string name, double ratePerHour, int hours)
            : base(id, name, 0) // baseSalary not used for part-time
        {
            hourlyRate = ratePerHour;
            hoursWorked = hours;
        }

        public override double CalculateSalary()
        {
            return hoursWorked * hourlyRate;
        }

        public void AssignDepartment(string deptName)
        {
            department = deptName;
        }

        public string GetDepartmentDetails()
        {
            return department;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeId}, Name: {Name}");
            Console.WriteLine($"Type: Part-Time, Department: {GetDepartmentDetails()}, Hours Worked: {hoursWorked}, Hourly Rate: {hourlyRate:C}");
            Console.WriteLine($"Total Salary: {CalculateSalary():C}");
        }
    }

    // Main Program without list
    class EmployeeManagement
    {
        static void Main(string[] args)
        {
            // Input Full-Time Employee
            Console.WriteLine("Enter Full-Time Employee Details:");
            Console.Write("Employee ID: ");
            int ftId = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string ftName = Console.ReadLine();
            Console.Write("Base Salary: ");
            double ftSalary = double.Parse(Console.ReadLine());
            Console.Write("Department: ");
            string ftDept = Console.ReadLine();

            FullTimeEmployee ftEmp = new FullTimeEmployee(ftId, ftName, ftSalary);
            ftEmp.AssignDepartment(ftDept);

            // Display Full-Time Employee details
            Console.WriteLine("\n--- Full-Time Employee Details ---");
            ftEmp.DisplayDetails();

            // Input Part-Time Employee
            Console.WriteLine("\nEnter Part-Time Employee Details:");
            Console.Write("Employee ID: ");
            int ptId = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string ptName = Console.ReadLine();
            Console.Write("Hourly Rate: ");
            double rate = double.Parse(Console.ReadLine());
            Console.Write("Hours Worked: ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write("Department: ");
            string ptDept = Console.ReadLine();

            PartTimeEmployee ptEmp = new PartTimeEmployee(ptId, ptName, rate, hours);
            ptEmp.AssignDepartment(ptDept);

            // Display Part-Time Employee details
            Console.WriteLine("\n--- Part-Time Employee Details ---");
            ptEmp.DisplayDetails();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}