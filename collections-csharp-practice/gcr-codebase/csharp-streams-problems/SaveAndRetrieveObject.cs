using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BridgeLabzTraining.Collections.streams
{
   

    class Employee
    {
        

            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public double Salary { get; set; }
        
    }

    internal class SaveAndRetrieveObject
    {
   

        static void Main()
        {
            string filePath = "employees.json";

            try
            {
                List<Employee> employees = new List<Employee>();

                Console.Write("Enter number of employees: ");
                int count = int.Parse(Console.ReadLine());

                // Take employee details
                for (int i = 0; i < count; i++)
                {
                    Employee emp = new Employee();

                    Console.Write($"Enter ID of {i+1}st employee: ");
                    emp.Id = int.Parse(Console.ReadLine());

                    Console.Write($"Enter Name of {i+1}st employee: ");
                    emp.Name = Console.ReadLine();

                    Console.Write($"Enter Department of {i+1}st employee: ");
                    emp.Department = Console.ReadLine();

                    Console.Write($"Enter Salary of {i+1}st employee: ");
                    emp.Salary = double.Parse(Console.ReadLine());

                    employees.Add(emp);
                }

                // Serialize to file
                string jsonData = JsonSerializer.Serialize(employees);
                File.WriteAllText(filePath, jsonData);

                Console.WriteLine("\nEmployees saved successfully.\n");

                // Deserialize from file
                string readData = File.ReadAllText(filePath);
                List<Employee> empList = JsonSerializer.Deserialize<List<Employee>>(readData);

                Console.WriteLine("Employee Details:");
                foreach (Employee e in empList)
                {
                    Console.WriteLine($"{e.Id} | {e.Name} | {e.Department} | {e.Salary}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}
