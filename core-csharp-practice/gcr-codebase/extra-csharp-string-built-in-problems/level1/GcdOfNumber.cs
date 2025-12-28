using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class GcdOfNumber
    {
       

        public static void Main(string[] args)
        {
            // Take input from the user
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            // call method 
            (int gcd, int lcm) = CalculateGcdAndLcm(num1, num2);

            //print results
            Console.WriteLine("GCD of " + num1 + " and " + num2 + " is  " + gcd);
            Console.WriteLine("LCM of " + num1 + " and " + num2 + " is  " + lcm);
        }

        // create a method to calculate both GCD and LCM
        public static (int, int) CalculateGcdAndLcm(int a, int b)
        {
            int originalA = a, originalB = b;

           
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            int gcd = a;

           
            int lcm = (originalA * originalB) / gcd;

            return (gcd, lcm);
        }
    }
}
