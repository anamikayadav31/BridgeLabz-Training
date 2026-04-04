using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class MaxNoOfHandShakesMethod
    {
        public static void Main(string[] args)
        {//ask user to input no. of students
            int num = int.Parse(Console.ReadLine());
            //call method
            Console.WriteLine(FindHandShakes(num));
        }
        //create a method to compute no of max handshakes 
        public static int FindHandShakes(int num)
        {
            int combination = (num * (num - 1)) / 2;
            //return
            return combination;
        }
    }
}
