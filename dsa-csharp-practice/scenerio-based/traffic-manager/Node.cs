using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.trafficmanger
{
    internal class Node
    {



        // Represents a vehicle in the roundabout


        public string VehicleNumber;   // Vehicle ID
        public  Node Next;        // Next vehicle in roundabout

        public Node(string number)
        {
            VehicleNumber = number;
            Next = null;
        }
    }
}