using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    internal class FileNotFound
    {
  

        static void Main()
        {
            // Ask user to press Enter (simple input)
            Console.WriteLine("Press Enter to read the file data.txt");
            Console.ReadLine();

            try
            {
                // Read all text from the file
                string content = File.ReadAllText("data.txt");

                // Print file content
                Console.WriteLine("File contents:");
                Console.WriteLine(content);
            }
            catch (IOException)
            {
                // If file is not found or cannot be read
                Console.WriteLine("File not found");
            }
        }
    }
}
