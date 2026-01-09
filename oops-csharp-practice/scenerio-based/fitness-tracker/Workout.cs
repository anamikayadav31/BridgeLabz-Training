using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.fitnessTracker
{// Base class for all workouts
    public abstract class Workout(string workoutName, int durationMinutes) : ITrackable
    {
        public string WorkoutName { get; set; } = workoutName;   // Workout name
        public int DurationMinutes { get; set; } = durationMinutes; // Duration

        public abstract double CalculateCaloriesBurned();
        public abstract void DisplayWorkoutDetails();
    }
}