using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MetalFactory
{
    internal class FactoryMain
    {

        static void Main()
        {
            // Object for input
            PriceInput input = new PriceInput();

            // Object for pipe cutting logic
            PipeCuttingCalculator service = new PipeCuttingCalculator();

            // Get pipe length
            int length = input.GetPipeLength();

            // Get price list
            int[] prices = input.GetPrices(length);

            // Calculate revenue using recursion
            int optimizedRevenue = service.GetMaxRevenue(length, prices);

            // Display result
            Console.WriteLine("\n--- Revenue Report ---");
            Console.WriteLine("Revenue without cutting: " + prices[length]);
            Console.WriteLine("Revenue with recursive cutting: " + optimizedRevenue);
        }
    }

}
