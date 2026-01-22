using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class ReadFileLineByLine
    {
  

        static void Main()
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    // Read file line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Case-insensitive check for "error"
                        if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
        }
    }

}
