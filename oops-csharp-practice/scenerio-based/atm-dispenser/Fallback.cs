using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.atmDispenser
{


    // Handles fallback when exact amount not possible
    internal class Fallback
    {
        public void ShowFallback(int amount)
        {
            Console.WriteLine("Exact change not possible.");
            Console.WriteLine("Please try a different amount.");
        }
    }


}