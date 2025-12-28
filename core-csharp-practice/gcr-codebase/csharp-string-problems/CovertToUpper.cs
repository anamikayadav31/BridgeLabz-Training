using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class CovertToUpper
    {
        public static void Main(string[] args)
        {//take a string from user
            string s = Console.ReadLine();
            //convert to uppercase using pre-built methods
            string a = s.ToUpper();
            //call method
            string b=ConvertUpper(s);
            //compare both
            if(a.Equals(b))

            {
                Console.WriteLine("Both results are the SAME.");

            }
            else
            {
                
                  Console.WriteLine("Results are DIFFERENT.");
                
            }
        }
        //create a method to convert lowercase to uppercase 
        public static string ConvertUpper(string s)
        {
            char[] res = new char[s.Length];
           

            for (int i = 0; i < s.Length; i++)
            {
                char c=s[i];
                if(c>='a' && c <= 'z')
                {
                    res[i] = (char)(c - 32);
                }
                else
                {
                    res[i] = c;
                }
            }
            return new String(res);

        }
    }
}
