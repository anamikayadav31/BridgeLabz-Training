using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class ReverseStr
    {
       




         public static void Main(string[] args)
        {
            
            string  s = Console.ReadLine();

            string reversed = ""; // To store the reversed string

            // Loop from the end of the string to the beginning
            for (int i =  s.Length - 1; i >= 0; i--)
            {
                reversed +=  s[i];
            }

            Console.WriteLine("Reversed string: " + reversed);
        }
    }

}

