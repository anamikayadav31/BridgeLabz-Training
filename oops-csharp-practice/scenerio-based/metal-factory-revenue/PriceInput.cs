using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MetalFactory
{
    internal class PriceInput
    {



        // Read total pipe length
        public int GetPipeLength()
        {
            Console.Write("Enter total pipe length: ");
            return int.Parse(Console.ReadLine());
        }

        // Read prices for each length
        public int[] GetPrices(int length)
        {
            int[] prices = new int[length + 1];

            Console.WriteLine("Enter price for each length:");
            for (int i = 1; i <= length; i++)
            {
                Console.Write("Price of length " + i + ": ");
                prices[i] = int.Parse(Console.ReadLine());
            }
            return prices;
        }
    }
}