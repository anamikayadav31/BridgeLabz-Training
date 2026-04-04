using System;
using System.IO;

class WriteCSV
{
    static void Main()
    {
        // CSV file path
        string path = "employees.csv";

        // Create CSV file
        using (StreamWriter sw = new StreamWriter(path))
        {
            // Header
            sw.WriteLine("ID,Name,Department,Salary");

            // Writing 5 employee records
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Department: ");
                string dept = Console.ReadLine();

                Console.Write("Enter Salary: ");
                double salary = double.Parse(Console.ReadLine());

                // Write record
                sw.WriteLine($"{i},{name},{dept},{salary}");
            }
        }

        Console.WriteLine("Employee CSV file created.");
    }
}
