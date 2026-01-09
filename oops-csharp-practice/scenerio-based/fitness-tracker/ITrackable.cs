using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.fitnessTracker
{
    internal interface ITrackable
    {
        double CalculateCaloriesBurned();   // Calculates calories
        void DisplayWorkoutDetails();       // Shows workout details
    }
}

