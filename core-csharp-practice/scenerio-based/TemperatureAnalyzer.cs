using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.scenerioBased
{
    internal class TemperatureAnalyzer
    {


        public static void Main(string[] args)
        {
            float[,] weeklyTemperatures = new float[7, 24]; // hourly temperature for 7 days
            float[] scores = null;
            Random random = new Random();

            while (true)
            {
                Console.WriteLine("1. Temperature Analyzer");
                Console.WriteLine("2. Student Score Manager");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        // Generate random temperature values
                        for (int day = 0; day < 7; day++)
                        {
                            for (int hour = 0; hour < 24; hour++)
                            {
                                weeklyTemperatures[day, hour] = (float)(random.NextDouble() * 40);
                            }
                        }

                        float[] dailyAverages = CalculateDailyAverages(weeklyTemperatures);
                        int hottestDayIndex = FindHottestDay(weeklyTemperatures);
                        int coldestDayIndex = FindColdestDay(weeklyTemperatures);

                        Console.WriteLine("\nAverage temperature of each day:");
                        for (int i = 0; i < 7; i++)
                        {
                            Console.WriteLine($"Day {i + 1}: {dailyAverages[i]:0.00} °C");
                        }

                        Console.WriteLine("Hottest day number is: " + (hottestDayIndex + 1));
                        Console.WriteLine("Coldest day number is: " + (coldestDayIndex + 1));
                        break;

                    case "2":
                        scores = ReadStudentScores();
                        if (scores == null)
                        {
                            break;
                        }

                        float averageScore = CalculateAverageScore(scores);

                        Console.WriteLine("\nStudent Score Report:");
                        Console.WriteLine("Average score: " + averageScore.ToString("0.00"));
                        Console.WriteLine("Highest score: " + FindHighestScore(scores));
                        Console.WriteLine("Lowest score: " + FindLowestScore(scores));

                        Console.WriteLine("Scores above average:");
                        foreach (float score in scores)
                        {
                            if (score > averageScore)
                            {
                                Console.WriteLine(score);
                            }
                        }
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        // Calculate average temperature per day
        public static float[] CalculateDailyAverages(float[,] temperatures)
        {
            float[] averages = new float[7];

            for (int day = 0; day < 7; day++)
            {
                float total = 0;
                for (int hour = 0; hour < 24; hour++)
                {
                    total += temperatures[day, hour];
                }
                averages[day] = total / 24;
            }
            return averages;
        }

        // Find hottest day based on average temperature
        public static int FindHottestDay(float[,] temperatures)
        {
            float[] averages = CalculateDailyAverages(temperatures);
            int hottestDay = 0;

            for (int i = 1; i < averages.Length; i++)
            {
                if (averages[i] > averages[hottestDay])
                {
                    hottestDay = i;
                }
            }
            return hottestDay;
        }

        // Find coldest day based on average temperature
        public static int FindColdestDay(float[,] temperatures)
        {
            float[] averages = CalculateDailyAverages(temperatures);
            int coldestDay = 0;

            for (int i = 1; i < averages.Length; i++)
            {
                if (averages[i] < averages[coldestDay])
                {
                    coldestDay = i;
                }
            }
            return coldestDay;
        }

        // Read student scores
        public static float[] ReadStudentScores()
        {
            Console.Write("\nEnter number of students: ");
            int studentCount;

            if (!int.TryParse(Console.ReadLine(), out studentCount) || studentCount <= 0)
            {
                Console.WriteLine("Invalid number of students!");
                return null;
            }

            float[] studentScores = new float[studentCount];

            for (int i = 0; i < studentCount; i++)
            {
                Console.Write($"Enter score of student {i + 1}: ");
                float score;

                if (!float.TryParse(Console.ReadLine(), out score) || score < 0)
                {
                    Console.WriteLine("Invalid score. Please enter again.");
                    i--;
                    continue;
                }
                studentScores[i] = score;
            }
            return studentScores;
        }

        // Calculate average score
        public static float CalculateAverageScore(float[] scores)
        {
            float sum = 0;
            foreach (float score in scores)
            {
                sum += score;
            }
            return sum / scores.Length;
        }

        // Find highest score
        public static float FindHighestScore(float[] scores)
        {
            float highest = scores[0];
            foreach (float score in scores)
            {
                if (score > highest)
                {
                    highest = score;
                }
            }
            return highest;
        }

        // Find lowest score
        public static float FindLowestScore(float[] scores)
        {
            float lowest = scores[0];
            foreach (float score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            return lowest;
        }
    }
}

      
   