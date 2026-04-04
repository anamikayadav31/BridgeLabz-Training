using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class ArgumentOutOfRange
    {
        public static void Main(string[] args)
        {//take a string from user
            string s = Console.ReadLine();
            try
            {
                string result = s.Substring(s.Length + 1, 2);
                Console.WriteLine(result);
            }

            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Caught ArgumentsOutOfRangeException!");
                Console.WriteLine(e.Message);


            }
        }



    }
}
