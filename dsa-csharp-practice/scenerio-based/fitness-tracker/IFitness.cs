using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.fitnessTracker
{
    internal interface IFitness
    {
        void AddUserDetails();
        void Sort();
        void DisplayLeaderboard();
    }
}
