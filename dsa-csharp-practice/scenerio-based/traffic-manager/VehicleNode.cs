using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.trafficManager
{
    
        // Represents a vehicle in the roundabout
        internal class VehicleNode
        {
            public string VehicleNumber;   // Vehicle ID
            public VehicleNode Next;        // Next vehicle in roundabout

            public VehicleNode(string number)
            {
                VehicleNumber = number;
                Next = null;
            }
        }

    }

