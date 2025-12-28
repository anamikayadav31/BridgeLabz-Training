using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class NumberGuessingGame
    {


        public static void Main(string[] args)
        {

            int low = 1;
            int high = 100;
            bool guessedCorrectly = false;

            while (!guessedCorrectly)
            {
                int guess = GenerateGuess(low, high);
                char feedback = GetUserFeedback(guess);

                if (feedback == 'c')
                {
                    Console.WriteLine($"Yay! I guessed your number "+guess+" correctly!");
                    guessedCorrectly = true;
                }
                else if (feedback == 'h')
                {
                    high = guess - 1; // Next guess should be lower
                }
                else if (feedback == 'l')
                {
                    low = guess + 1; // Next guess should be higher
                }
                else
                {
                    Console.WriteLine("Invalid input. Please respond with 'h', 'l', or 'c'.");
                }
            }
        }

        // Function to generate a random guess between low and high
        static int GenerateGuess(int low, int high)
        {
            Random rnd = new Random();
            return rnd.Next(low, high + 1); // high + 1 because upper bound is exclusive
        }

        // Function to get feedback from the user
        static char GetUserFeedback(int guess)
        {
            Console.Write($"Is it {guess}? (h/l/c): ");
            return Console.ReadLine().ToLower()[0]; // Take first character and convert to lowercase
        }
    }

}
