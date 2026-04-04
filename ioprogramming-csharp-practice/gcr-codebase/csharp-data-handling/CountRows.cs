using System;
using System.IO;

class CountRows
{
    static void Main()
    {
        // Read all lines
        string[] lines = File.ReadAllLines("employees.csv");

        // Exclude header row
        int count = lines.Length - 1;

        Console.WriteLine("Total Records: " + count);
    }
}
