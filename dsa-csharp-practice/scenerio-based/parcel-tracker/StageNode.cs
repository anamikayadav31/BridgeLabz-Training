using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.parcelTracker
{
    internal class StageNode
    {
       
            public ParcelStage Data;
            public StageNode? Next;

            public StageNode(ParcelStage stage)
            {
                Data = stage;
                Next = null;
            }
        }
    }

