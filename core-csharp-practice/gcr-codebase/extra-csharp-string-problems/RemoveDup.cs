using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class RemoveDup
    {
       

        public static void Main(string[] args)
        {
            
            //ask user to input string
            string  s = Console.ReadLine();

            string result = ""; // To store string without duplicates

            foreach (char c in  s)
            {
                if (!result.Contains(c)) // Add only if it is not already in result
                {
                    result += c;
                }
            }

            Console.WriteLine("String after removing duplicates: " + result);
        }
    }


}
