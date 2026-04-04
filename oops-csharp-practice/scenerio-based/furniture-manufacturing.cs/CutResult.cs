using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.FurnitureManufacturing
{
    internal class CutResult
    {


        public int[] Cuts;      // Stores cut sizes
        public int CutCount;    // Number of cuts
        public int Revenue;     // Total earning
        public int Waste;       // Remaining wood

        public CutResult(int maxCuts)
        {
            Cuts = new int[maxCuts];
            CutCount = 0;
        }
    }

}

