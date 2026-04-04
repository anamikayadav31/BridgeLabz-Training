using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{
    internal class LuckyDraw
    {


        // Method to check whether the number is lucky
        public void CheckLuckyNumber(int visitorNumber)
        {
            if (visitorNumber % 3 == 0 && visitorNumber % 5 == 0)
            {
                Console.WriteLine("Congratulations! You won a gift 🎁");
            }
            else
            {
                Console.WriteLine("Sorry! Better luck next time.");
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            LuckyDraw luckyDraw = new LuckyDraw();
            int menuChoice = 0;

            while (true)
            {
                // Display menu
                Console.WriteLine("\n--- Diwali Lucky Draw ---");
                Console.WriteLine("1. Enter Visitor Number");
                Console.WriteLine("2. Exit");
                Console.Write("Please select an option: ");

                string menuChoiceInput = Console.ReadLine();

                // Validate menu input
                if (menuChoiceInput != "1" && menuChoiceInput != "2")
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    continue;
                }

                menuChoice = int.Parse(menuChoiceInput);

                if (menuChoice == 2)
                {
                    Console.WriteLine("Thank you for visiting the Diwali Mela!");
                    break;
                }

                Console.Write("Enter your lucky draw number: ");
                string visitorNumberInput = Console.ReadLine();

                bool isValidNumber = true;

                for (int i = 0; i < visitorNumberInput.Length; i++)
                {
                    if (visitorNumberInput[i] < '0' || visitorNumberInput[i] > '9')
                    {
                        isValidNumber = false;
                        break;
                    }
                }

                if (!isValidNumber || visitorNumberInput.Length == 0)
                {
                    Console.WriteLine("Invalid number. Please enter digits only.");
                    continue;
                }

                int visitorNumber = int.Parse(visitorNumberInput);

                // Check lucky number
                luckyDraw.CheckLuckyNumber(visitorNumber);
            }
        }
    }
}