using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class UpperCaseToLower
    {
   

        static void Main()
        {
            Console.Write("Enter source text file path: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Enter destination file path: ");
            string destPath = Console.ReadLine();

            try
            {
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine("Source file does not exist.");
                    return;
                }

                // Open file streams
                using (FileStream fsRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (FileStream fsWrite = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                using (BufferedStream bsRead = new BufferedStream(fsRead))
                using (BufferedStream bsWrite = new BufferedStream(fsWrite))
                using (StreamReader reader = new StreamReader(bsRead, Encoding.UTF8))
                using (StreamWriter writer = new StreamWriter(bsWrite, Encoding.UTF8))
                {
                    string line;

                    // Read line by line and convert to lowercase
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line.ToLower());
                    }
                }

                Console.WriteLine("File converted to lowercase successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
        }
    }

}
