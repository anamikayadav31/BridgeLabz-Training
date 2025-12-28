using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class SubstringCreate
    {
        public static void Main(string[] args)
        {//ask user to input a string
            string s1 = Console.ReadLine();

            Createsub(s1);

        }
        public static void Createsub(string s1)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 1; j <= s1.Length - i; j++)
                {

                    Console.WriteLine(s1.Substring(i, j));
                }

            }
        }
    }
}
