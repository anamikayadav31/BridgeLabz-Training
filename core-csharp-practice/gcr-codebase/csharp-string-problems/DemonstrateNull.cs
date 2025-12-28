using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class DemonstrateNull
    {
        public static void Main(string[] args)
        {//take a string as null
            string s = null;
            try
            {
                NuLLReference(s);
            }

            catch (NullReferenceException e)
            {
                Console.WriteLine("Caught NullReferenceException!");
                Console.WriteLine(e.Message);


            }
        }

        //create method to access a null string 
        public static void NuLLReference(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }

        }
    }

}
