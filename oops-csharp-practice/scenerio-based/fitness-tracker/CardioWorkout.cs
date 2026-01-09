using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.fitnessTracker
{
    // Cardio workout class
    public class CardioWorkout(
        string name,
        int duration,
        double distanceKm
    ) : Workout(name, duration)
    {
        public double DistanceKm { get; set; } = distanceKm;

        public override double CalculateCaloriesBurned()
        {
            return DistanceKm * 60;
        }

        public override void DisplayWorkoutDetails()
        {
            Console.WriteLine("\n--- Cardio Workout ---");
            Console.WriteLine($"Name     : {WorkoutName}");
            Console.WriteLine($"Duration : {DurationMinutes} minutes");
            Console.WriteLine($"Distance : {DistanceKm} km");
            Console.WriteLine($"Calories : {CalculateCaloriesBurned()}");
        }
    }
}