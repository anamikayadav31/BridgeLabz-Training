using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class RemoveSpecificCh
    {
        

    
        public static void Main(string[] args)
        {
            //ask user to input string
            string  s = Console.ReadLine();

            
            char  ch = Console.ReadLine()[0]; // Read single character
            //call method
            string result = RemoveCharacter( s,   ch);

            Console.WriteLine("Modified String: "+result);
        }
        //create method to remove character
        public static string RemoveCharacter(string str, char ch)
        {
            string result = "";

            foreach (char c in str)
            {
                if (c != ch)
                {
                    result += c;
                }
            }

            return result;
        }
    }

}
