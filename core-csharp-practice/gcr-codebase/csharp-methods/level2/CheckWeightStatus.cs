using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class CheckWeightStatus

    {
        public static void Main(string[] args)
        {
            int teamSize = 10;
            double[,] data = new double[teamSize, 3];
            string[] status = new string[teamSize];

            // input weight and height for 10 members
            for (int i = 0; i < teamSize; i++)
            {
                Console.WriteLine("Enter weight (kg) of member " + (i + 1) + ":");
                data[i, 0] = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter height (cm) of member " + (i + 1) + ":");
                data[i, 1] = double.Parse(Console.ReadLine());
            }

            // calculate BMI 
            CalculateBMI(data);

            // determine BMI status 
            status = DetermineBMIStatus(data);

            // print results
            for (int i = 0; i < teamSize; i++)
            {
                Console.WriteLine("Member " + (i + 1) + ":");
                Console.WriteLine("Weight (kg): " + data[i, 0]);
                Console.WriteLine("Height (cm): " + data[i, 1]);
                Console.WriteLine("BMI: " + data[i, 2].ToString("0.00"));
                Console.WriteLine("Status: " + status[i]);
                Console.WriteLine(); 
            }

        }

        // create method to calculate BMI 
        public static void CalculateBMI(double[,] data)
        {
            int rows = data.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                double weight = data[i, 0];
                double heightInMeters = data[i, 1] / 100; // Convert cm to meters
                double bmi = weight / (heightInMeters * heightInMeters);
                data[i, 2] = bmi;
            }
        }

        // create method to determine weight status
        public static string[] DetermineBMIStatus(double[,] data)
        {
            int rows = data.GetLength(0);
            string[] status = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                double bmi = data[i, 2];

                if (bmi < 18.5)
                {
                    status[i] = "Underweight";
                }
                else if (bmi >= 18.5 && bmi < 24.9)
                {
                    status[i] = "Normal";
                }
                else if (bmi >= 25 && bmi < 29.9)
                {
                    status[i] = "Overweight";
                }
                else
                {
                    status[i] = "Obese";
                }
            }


             return status;
            

        }
    }

}

