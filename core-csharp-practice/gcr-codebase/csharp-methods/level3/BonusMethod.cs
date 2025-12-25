using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class BonusMethod
    {


        static Random rand = new Random();
        public static void Main(string[] args)
        {
            int n = 10; // number of employees

            // Generate employee data
            int[,] employees = GenerateEmployees(n);

            // Calculate bonus and new salary
            double[,] result = CalculateBonus(employees);

            // Display summary table
            DisplaySummary(result);
        }

        // Generate random salary (5-digit) and years of service (1-10)
        public static int[,] GenerateEmployees(int n)
        {
            int[,] employees = new int[n, 2]; // [salary, yearsOfService]
            for (int i = 0; i < n; i++)
            {
                employees[i, 0] = rand.Next(10000, 100000); // 5-digit salary
                employees[i, 1] = rand.Next(1, 11);         // years of service 1-10
            }
            return employees;
        }

        //  Calculate bonus and new salary
        public static double[,] CalculateBonus(int[,] employees)
        {
            int n = employees.GetLength(0);
            double[,] result = new double[n, 3]; // [oldSalary, bonus, newSalary]

            for (int i = 0; i < n; i++)
            {
                double oldSalary = employees[i, 0];
                int years = employees[i, 1];
                double bonus = (years > 5) ? oldSalary * 0.05 : oldSalary * 0.02;
                double newSalary = oldSalary + bonus;

                result[i, 0] = oldSalary;
                result[i, 1] = bonus;
                result[i, 2] = newSalary;
            }

            return result;
        }

        //  Calculate totals and display
        public static void DisplaySummary(double[,] employees)
        {
            double totalOld = 0, totalBonus = 0, totalNew = 0;

            Console.WriteLine("\nEmployee\tOld Salary\tBonus\tNew Salary");

            for (int i = 0; i < employees.GetLength(0); i++)
            {
                double oldSalary = employees[i, 0];
                double bonus = employees[i, 1];
                double newSalary = employees[i, 2];

                Console.WriteLine("Employee " + (i + 1));
                Console.WriteLine("Old Salary: " + oldSalary);
                Console.WriteLine("Bonus: " + bonus);
                Console.WriteLine("New Salary: " + newSalary);
                Console.WriteLine("-------------------------");

                totalOld += oldSalary;
                totalBonus += bonus;
                totalNew += newSalary;
            }

            Console.WriteLine("TOTALS:");
            Console.WriteLine("Total Old Salary: " + totalOld);
            Console.WriteLine("Total Bonus: " + totalBonus);
            Console.WriteLine("Total New Salary: " + totalNew);
        }
    }




}