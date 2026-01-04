using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class Composition
    {


        // Company class (Company contains Departments)
        class Company
        {
            public string companyTitle;
            public List<Department> departmentList;

            // Constructor
            public Company(string companyTitle)
            {
                this.companyTitle = companyTitle;
                departmentList = new List<Department>();
            }

            // Add department to company
            public void AddDepartment(string departmentTitle)
            {
                departmentList.Add(new Department(departmentTitle));
            }

            // Display company details
            public void DisplayCompany()
            {
                Console.WriteLine("\nCompany Name: " + companyTitle);

                for (int i = 0; i < departmentList.Count; i++)
                {
                    departmentList[i].DisplayDepartment();
                }
            }
        }

        // Department class (Department contains Employees)
        class Department
        {
            public string departmentTitle;
            public List<Employee> employeeList;

            // Constructor
            public Department(string departmentTitle)
            {
                this.departmentTitle = departmentTitle;
                employeeList = new List<Employee>();
            }

            // Add employee to department
            public void AddEmployee(string employeeName)
            {
                employeeList.Add(new Employee(employeeName));
            }

            // Display department details
            public void DisplayDepartment()
            {
                Console.WriteLine("\nDepartment: " + departmentTitle);

                for (int i = 0; i < employeeList.Count; i++)
                {
                    employeeList[i].DisplayEmployee();
                }
            }
        }

        // Employee class
        class Employee
        {
            public string employeeName;

            // Constructor
            public Employee(string employeeName)
            {
                this.employeeName = employeeName;
            }

            // Display employee name
            public void DisplayEmployee()
            {
                Console.WriteLine("Employee: " + employeeName);
            }
        }

        // Main method
        public static void Main(string[] args)
        {
            // Take company name from user
            Console.WriteLine("Enter Company Name:");
            string inputCompanyName = Console.ReadLine();

            Company companyObj = new Company(inputCompanyName);

            // Take number of departments
            Console.WriteLine("Enter Number of Departments:");
            int deptCount = int.Parse(Console.ReadLine());

            // Loop to add departments
            for (int i = 0; i < deptCount; i++)
            {
                Console.WriteLine("\nEnter Department Name:");
                string deptName = Console.ReadLine();

                companyObj.AddDepartment(deptName);

                // Take number of employees
                Console.WriteLine("Enter Number of Employees in " + deptName + ":");
                int empCount = int.Parse(Console.ReadLine());

                // Add employees
                for (int j = 0; j < empCount; j++)
                {
                    Console.WriteLine("Enter Employee Name:");
                    string empName = Console.ReadLine();

                    companyObj.departmentList[i].AddEmployee(empName);
                }
            }

            // Display full company structure
            companyObj.DisplayCompany();
        }
    }
}