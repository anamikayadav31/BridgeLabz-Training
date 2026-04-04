using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class IndexOutRange
    {
        public static void Main(string[] args)
        {
            string s = Console.ReadLine();
            try
            {
                Fun(s);
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(" Caught IndexOutOfRangeException!");
                Console.WriteLine(e.Message);
            }

        }
        public static void Fun(string s)
        {
            for (int i = 0; i <= s.Length; i++)
            {
                
                Console.WriteLine(s[i]);
            }

        }
           


        
    }
}
