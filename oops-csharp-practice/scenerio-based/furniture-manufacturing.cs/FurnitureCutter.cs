using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.FurnitureManufacturing
{
    internal class FurnitureCutter
    {

        // Scenario A: Maximize revenue (simple greedy)
        public CutResult MaximizeRevenue(int rodLength, WoodPiece[] pieces)
        {
            CutResult result = new CutResult(20);

            // Manual sorting by price (descending)
            for (int i = 0; i < pieces.Length - 1; i++)
            {
                for (int j = i + 1; j < pieces.Length; j++)
                {
                    if (pieces[i].Price < pieces[j].Price)
                    {
                        WoodPiece temp = pieces[i];
                        pieces[i] = pieces[j];
                        pieces[j] = temp;
                    }
                }
            }

            // Cut wood
            for (int i = 0; i < pieces.Length; i++)
            {
                while (rodLength >= pieces[i].Length)
                {
                    rodLength -= pieces[i].Length;
                    result.Revenue += pieces[i].Price;
                    result.Cuts[result.CutCount++] = pieces[i].Length;
                }
            }

            result.Waste = rodLength;
            return result;
        }

        // Scenario B: Revenue with waste constraint
        public CutResult RevenueWithWasteLimit(int rodLength, WoodPiece[] pieces, int maxWaste)
        {
            CutResult result = MaximizeRevenue(rodLength, pieces);

            // Reject if waste exceeds limit
            if (result.Waste > maxWaste)
            {
                result.CutCount = 0;
                result.Revenue = 0;
            }

            return result;
        }

        // Scenario C: Maximize revenue with minimal waste
        public CutResult MaxRevenueMinWaste(int rodLength, WoodPiece[] pieces)
        {
            CutResult result = new CutResult(20);

            // Sort by length (descending) to reduce waste
            for (int i = 0; i < pieces.Length - 1; i++)
            {
                for (int j = i + 1; j < pieces.Length; j++)
                {
                    if (pieces[i].Length < pieces[j].Length)
                    {
                        WoodPiece temp = pieces[i];
                        pieces[i] = pieces[j];
                        pieces[j] = temp;
                    }
                }
            }

            // Perform cuts
            for (int i = 0; i < pieces.Length; i++)
            {
                if (rodLength >= pieces[i].Length)
                {
                    rodLength -= pieces[i].Length;
                    result.Revenue += pieces[i].Price;
                    result.Cuts[result.CutCount++] = pieces[i].Length;
                }
            }

            result.Waste = rodLength;
            return result;
        }
    }
}