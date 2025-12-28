using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class ToggleCase
    {
       

        public static void Main(string[] args)
        {
            //ask user to input a string
            string  s = Console.ReadLine();
            //create a variable to store toggled string
            string  t = "";

            foreach (char c in  s)
            {
                if (char.IsUpper(c))
                {
                     t += char.ToLower(c); // Convert uppercase to lowercase
                }
                else if (char.IsLower(c))
                {
                     t += char.ToUpper(c); // Convert lowercase to uppercase
                }
                else
                {
                     t += c; // Keep non-letter characters as they are
                }
            }

            Console.WriteLine("Toggled case string: " +  t);
        }
    }

}
