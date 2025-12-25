using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class GradesMethod
    {


        static Random rand = new Random();
        public static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int numStudents = int.Parse(Console.ReadLine());

            int[,] scores = GenerateScores(numStudents);

            DisplayResults(scores);
        }

        // gnerate random 2-digit scores for Physics, Chemistry, and Maths
        public static int[,] GenerateScores(int numStudents)
        {
            int[,] scores = new int[numStudents, 3];

            for (int i = 0; i < numStudents; i++)
            {
                scores[i, 0] = rand.Next(40, 101); // Physics
                scores[i, 1] = rand.Next(40, 101); // Chemistry
                scores[i, 2] = rand.Next(40, 101); // Maths
            }

            return scores;
        }

        // Calculate and display results with grade and remarks
        public static void DisplayResults(int[,] scores)
        {
            for (int i = 0; i < scores.GetLength(0); i++)
            {
                int physics = scores[i, 0];
                int chemistry = scores[i, 1];
                int maths = scores[i, 2];

                int total = physics + chemistry + maths;
                double average = total / 3.0;
                double percentage = (total / 300.0) * 100;

                string grade = GetGrade(percentage);
                string remarks = GetRemarks(grade);

                Console.WriteLine("Student " + (i + 1));
                Console.WriteLine("Physics: " + physics);
                Console.WriteLine("Chemistry: " + chemistry);
                Console.WriteLine("Maths: " + maths);
                Console.WriteLine("Total: " + total);
                Console.WriteLine("Average: " + average);
                Console.WriteLine("Percentage: " + percentage + "%");
                Console.WriteLine("Grade: " + grade);
                Console.WriteLine("Remarks: " + remarks);
                Console.WriteLine("-------------------------");
            }
        }


        // Get grade using if-else
        public static string GetGrade(double percentage)
        {
            if (percentage >= 80)
                return "A";
            else if (percentage >= 70)
                return "B";
            else if (percentage >= 60)
                return "C";
            else if (percentage >= 50)
                return "D";
            else if (percentage >= 40)
                return "E";
            else
                return "R";
        }

        // Get remarks using if-else
        public static string GetRemarks(string grade)
        {
            if (grade == "A")
                return "Level 4, above agency-normalized standards";
            else if (grade == "B")
                return "Level 3, at agency-normalized standards";
            else if (grade == "C")
                return "Level 2, below, but approaching agency-normalized standards";
            else if (grade == "D")
                return "Level 1, well below agency-normalized standards";
            else if (grade == "E")
                return "Level 1-, too below agency-normalized standards";
            else // grade == "R"
                return "Remedial standards";
        }
    }


}
