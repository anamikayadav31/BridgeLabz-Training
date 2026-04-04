using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class SimpleInterestMethod
    {
        public static void Main(string[] args)
        {//ask user to input principal amount
            int p=int.Parse(Console.ReadLine());
            //ask user to input rate
            int r = int.Parse(Console.ReadLine());
            //ask user to input time in years
            int t = int.Parse(Console.ReadLine());
            //call method
            Console.WriteLine(simpleInterst(p, r, t));

        }
        //create a method to compute simple interest
        public static int simpleInterst(int p,int r,int t)
        {
            int si = (p * r * t) / 100;
            return si;
        }
    }
}
