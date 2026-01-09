using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.fitnessTracker
{
    // Strength workout class
    // Strength workout class
    public class StrengthWorkout(
        string name,
        int duration,
        int sets,
        int repsPerSet
    ) : Workout(name, duration)
    {
        public int Sets { get; set; } = sets;
        public int RepsPerSet { get; set; } = repsPerSet;

        public override double CalculateCaloriesBurned()
        {
            return DurationMinutes * 8;
        }

        public override void DisplayWorkoutDetails()
        {
            Console.WriteLine("\n--- Strength Workout ---");
            Console.WriteLine($"Name     : {WorkoutName}");
            Console.WriteLine($"Duration : {DurationMinutes} minutes");
            Console.WriteLine($"Sets     : {Sets}");
            Console.WriteLine($"Reps     : {RepsPerSet}");
            Console.WriteLine($"Calories : {CalculateCaloriesBurned()}");
        }
    }
}