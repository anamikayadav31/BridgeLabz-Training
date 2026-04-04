using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraString
{
    internal class OrderString
    {

    
        public static void Main(string[] args)
        {
            
        
            string str1 = Console.ReadLine();       
            string str2 = Console.ReadLine();

            int result = CompareStrings(str1, str2);

            if (result < 0)
            {
                Console.WriteLine(str1+" comes before "+str2+" in lexicographical order");
            }
            else if (result > 0)
            {
                Console.WriteLine(str1+" comes after "+str2+" in lexicographical order");
            }
            else
            {
                Console.WriteLine(str1+ " is equal to "+str2);
            }
        }

        public static int CompareStrings(string s1, string s2)
        {
            int minLength = Math.Min(s1.Length, s2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (s1[i] != s2[i])
                {
                    return s1[i] - s2[i]; 

                }
            }

            

            return s1.Length - s2.Length;
        }
    }

}
