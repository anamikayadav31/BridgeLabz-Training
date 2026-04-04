using System;   // Basic classes like Console
using System.IO; // File operations

Console.Write("Enter CSV file path to read: "); // Ask for CSV path
string filePath = Console.ReadLine();           // Read input

if (File.Exists(filePath))                      // Check file exists
{
    string[] lines = File.ReadAllLines(filePath); // Read all lines

    Console.WriteLine("\nStudent Details:");    // Header

    foreach (string line in lines)              // Loop each line
    {
        string[] parts = line.Split(',');       // Split by comma
        if (parts.Length >= 4)                  // Ensure 4 columns
        {
            Console.WriteLine($"ID: {parts[0]}, Name: {parts[1]}, Age: {parts[2]}, Marks: {parts[3]}"); // Print
        }
    }
}
else
{
    Console.WriteLine("File does not exist!");   // File missing
}
