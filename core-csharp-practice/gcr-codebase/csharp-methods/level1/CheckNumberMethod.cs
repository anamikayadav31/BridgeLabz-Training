using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class CheckNumberMethod
    {
        public static void Main(string[] args)
        {//ask user to input a number 
            int num = int.Parse(Console.ReadLine());
            //call method
            Console.WriteLine(CheckNumber(num));
        }
        //create a method to check number 
        public static int CheckNumber(int num)
        {//if negative return -1
            if (num < 0)
            {
                return -1;
            }
            //if positive then returns 1
            else if (num > 0)
            {
                return 1;
            }
            // if number is zero return 0
            else
            {
                return 0;
            }
        }
    }
}
