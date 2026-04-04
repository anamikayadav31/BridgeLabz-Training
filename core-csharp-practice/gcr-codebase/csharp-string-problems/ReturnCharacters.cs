using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class ReturnCharacters
    {
        public static void Main(string[] args)
        {//ask user to input a string
            string s=Console.ReadLine();
            ReturnCh(s);

        }
        //create a method to return all charcters of string
        public static void ReturnCh(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
        }
    }
}
