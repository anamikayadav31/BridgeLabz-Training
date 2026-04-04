using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class ReadUserInput
    {
  

        static void Main()
        {
            try
            {
                // StreamReader for console input
                StreamReader reader = new StreamReader(Console.OpenStandardInput());

                Console.Write("Enter your name: ");
                string name = reader.ReadLine();

                Console.Write("Enter your age: ");
                string age = reader.ReadLine();

                Console.Write("Enter your favorite programming language: ");
                string language = reader.ReadLine();

                // StreamWriter to write data to file
                using (StreamWriter writer = new StreamWriter("UserInfo.txt"))
                {
                    writer.WriteLine("Name: " + name);
                    writer.WriteLine("Age: " + age);
                    writer.WriteLine("Favorite Language: " + language);
                }

                Console.WriteLine("User information saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}
