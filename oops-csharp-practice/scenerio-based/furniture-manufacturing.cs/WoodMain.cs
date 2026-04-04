using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.FurnitureManufacturing
{
    internal class WoodMain
    {


        static void Main()
        {
            Console.Write("Enter rod length: ");
            int rodLength = int.Parse(Console.ReadLine());

            Console.Write("Enter number of wood sizes: ");
            int n = int.Parse(Console.ReadLine());

            WoodPiece[] pieces = new WoodPiece[n];

            // Take user input
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter length: ");
                int len = int.Parse(Console.ReadLine());

                Console.Write("Enter price: ");
                int price = int.Parse(Console.ReadLine());

                pieces[i] = new WoodPiece(len, price);
            }

            FurnitureCutter cutter = new FurnitureCutter();

            // Scenario A
            Console.WriteLine("\nScenario A: Maximize Revenue");
            PrintResult(cutter.MaximizeRevenue(rodLength, pieces));

            // Scenario B
            Console.Write("\nEnter max allowed waste: ");
            int maxWaste = int.Parse(Console.ReadLine());

            Console.WriteLine("Scenario B: Revenue with Waste Constraint");
            PrintResult(cutter.RevenueWithWasteLimit(rodLength, pieces, maxWaste));

            // Scenario C
            Console.WriteLine("Scenario C: Max Revenue + Min Waste");
            PrintResult(cutter.MaxRevenueMinWaste(rodLength, pieces));
        }

        // Display result
        static void PrintResult(CutResult result)
        {
            if (result.CutCount == 0)
            {
                Console.WriteLine("No valid cutting possible.");
                return;
            }

            Console.Write("Cuts: ");
            for (int i = 0; i < result.CutCount; i++)
            {
                Console.Write(result.Cuts[i] + " ");
            }

            Console.WriteLine("\nRevenue: " + result.Revenue);
            Console.WriteLine("Waste: " + result.Waste);
        }
    }
}