using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class ComputeGrades2DArray
    {
     
        public static void Main(string[] args)
        {
            Console.Write("Enter the number of students: ");
            int n = int.Parse(Console.ReadLine());
            int[,] marks = new int[n, 3];
            double[] percentage = new double[n];
            char[] grade = new char[n];
            string[] subjects = { "Physics", "Chemistry", "Maths" };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Enter {subjects[j]} marks for student {i + 1}: ");
                    int input = int.Parse(Console.ReadLine());
                    if (input < 0)
                    {
                        j--; 
                    }
                    else
                    {
                        marks[i, j] = input;
                    }
                }

                // Calculate Percentage
                percentage[i] = (marks[i, 0] + marks[i, 1] + marks[i, 2]) / 3.0;

                // Assign Grade according conditions
                if (percentage[i] >= 80)
                    grade[i] = 'A';
                else if (percentage[i] > 70 && percentage[i] < 79)
                {
                    grade[i] = 'B';
                }
                else if (percentage[i] > 60 && percentage[i] < 69)
                {
                    grade[i] = 'C';
                }
                else if (percentage[i] > 50 && percentage[i] < 59)
                {
                    grade[i] = 'D';
                }
                else if (percentage[i] > 40 && percentage[i] < 49)
                {
                    grade[i] = 'E';
                }
                else
                    grade[i] = 'R';
            }

            // print results
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nStudent " + (i + 1));
                Console.WriteLine("Percentage: " + percentage[i] + "%");
                Console.WriteLine("Grade: " + grade[i]);
            }
        }
    }

}
