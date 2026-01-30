using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.parcelTracker
{
    internal class ParcelStage
    {
      
            private string stageName;

            public ParcelStage(string stageName)
            {
                this.stageName = stageName;
            }

            public string GetStage()
            {
                return stageName;
            }
        }
    }

