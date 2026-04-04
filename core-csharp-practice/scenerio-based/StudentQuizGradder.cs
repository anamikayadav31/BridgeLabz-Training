using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.scenerioBased
{
    internal class StudentQuizGradder
    {




        // method to calculate score
        public static int CalculateScore(string[] correct, string[] student)
        {
            int score = 0;
            for (int i = 0; i < correct.Length; i++)
            {
                // compare in lowercase
                if (student[i].ToLower() == correct[i].ToLower())
                {
                    score++;
                }
            }
            return score;
        }

        public static void Main(string[] args)
        {
            // correct answers
            string[] correctAnswers = { "A", "B", "C", "D", "A", "C", "B", "D", "A", "C" };
            // student answers
            string[] studentAnswers = new string[10];

            while (true)
            {

                Console.WriteLine("1. Enter Student Answers");
                Console.WriteLine("2. Check Answers and Show Result");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nEnter answers for 10 questions (A/B/C/D):");
                        for (int i = 0; i < studentAnswers.Length; i++)
                        {
                            Console.Write("Q" + (i + 1) + ": ");
                            studentAnswers[i] = Console.ReadLine();
                        }
                        Console.WriteLine("Answers saved.");
                        break;

                    case "2":
                        Console.WriteLine("\n Result");
                        int score = CalculateScore(correctAnswers, studentAnswers);

                        // detailed feedback
                        for (int i = 0; i < correctAnswers.Length; i++)
                        {
                            if (studentAnswers[i].ToLower() == correctAnswers[i].ToLower())
                                Console.WriteLine("Question " + (i + 1) + ": Correct");
                            else
                                Console.WriteLine("Question " + (i + 1) + ": Incorrect (Correct: " + correctAnswers[i] + ")");
                        }

                        // score and percentage
                        double percent = (score / 10.0) * 100;
                        Console.WriteLine("\nTotal Score: " + score + "/10");
                        Console.WriteLine("Percentage: " + percent + "%");

                        // pass fail
                        if (percent >= 50)
                            Console.WriteLine("Status: PASS");
                        else
                            Console.WriteLine("Status: FAIL");

                        break;

                    case "3":
                        Console.WriteLine("Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }

}

    