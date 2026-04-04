using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class ComputeGrades
    {


        public static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());
            //create arrays to store marks of physics,chemistry,maths ,percentages and grades
            float[] physics = new float[n];
            float[] chemistry = new float[n];
            float[] maths = new float[n];
            float[] percentage = new float[n];
            char[] grade = new char[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nStudent " + (i + 1));
                Console.Write("Enter Physics marks: ");
                physics[i] = float.Parse(Console.ReadLine());
                if (physics[i] < 0)
                {
                    i--;
                    continue;
                }
                Console.Write("Enter Chemistry marks: ");
                chemistry[i] = float.Parse(Console.ReadLine());
                if (chemistry[i] < 0)
                {
                    i--;
                    continue;
                }
                Console.Write("Enter Maths marks: ");
                maths[i] = float.Parse(Console.ReadLine());
                if (maths[i] < 0)
                {
                    i--;
                    continue;
                }
                // Calculate percentage
                percentage[i] = (physics[i] + chemistry[i] + maths[i]) / 3;
                // check condition for grades
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
