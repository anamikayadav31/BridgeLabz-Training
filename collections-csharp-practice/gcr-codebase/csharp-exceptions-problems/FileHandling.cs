using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    internal class FileHandling
    {
    
   

        static void Main()
        {
            try
            {
                // Read first line using using statement
                using (StreamReader reader = new StreamReader("info.txt"))
                {
                    string line = reader.ReadLine();
                    Console.WriteLine("First line: " + line);
                }
            }
            catch (IOException)
            {
                // Handle file errors
                Console.WriteLine("Error reading file");
            }
        }
    }
}
