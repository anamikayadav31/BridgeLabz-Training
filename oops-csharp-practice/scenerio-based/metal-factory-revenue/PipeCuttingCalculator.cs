using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MetalFactory
{
    internal class PipeCuttingCalculator
    {



        // Recursive method to calculate max revenue
        public int GetMaxRevenue(int length, int[] prices)
        {
            // Base case: no length means no revenue
            if (length == 0)
                return 0;

            int maxRevenue = prices[length]; // no cut case

            // Try all possible cuts
            for (int i = 1; i < length; i++)
            {
                // Cut pipe into two parts and calculate revenue
                int revenue = GetMaxRevenue(i, prices)
                            + GetMaxRevenue(length - i, prices);

                // Update max revenue
                if (revenue > maxRevenue)
                {
                    maxRevenue = revenue;
                }
            }

            return maxRevenue;

        }
    }
}
