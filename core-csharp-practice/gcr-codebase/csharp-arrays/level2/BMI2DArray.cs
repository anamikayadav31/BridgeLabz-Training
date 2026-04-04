using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BridgeLabzTraining.arrays.level2
{
    internal class BMI2DArray
    {
        public static void Main(string[] args)
        {//ask user to input number
            int num = int.Parse(Console.ReadLine());
            //create arrays 


            double[ , ] personData = new double[num,3];
            string[] status = new string[num];
            //ask user to input weights and heights
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("\nEnter details for Person " + (i + 1));
                Console.Write("Enter weight (in kg): ");
                personData[i, 0] = double.Parse(Console.ReadLine());
                while (personData[i, 0] <= 0)
                {
                    Console.Write("Enter weight (in kg): ");
                    personData[i, 0] = double.Parse(Console.ReadLine());
                }
                Console.Write("Enter height (in meters): ");
                personData[i, 1] = double.Parse(Console.ReadLine());
                while (personData[i, 1] <= 0)
                {
                    Console.WriteLine("Height must be positive. Please re-enter.");
                    Console.Write("Enter height (in meters): ");
                    personData[i, 1] = double.Parse(Console.ReadLine());
                }

                //compute bmi
                personData[i,2] = personData[i, 0] /
                               (personData[i, 1] * personData[i, 1]);
            //check conditions for status
           
                if (personData[i, 2]  <= 18.4)
                {
                    status[i] = "Underweight";
                }
                else if (personData[i, 2] > 18.5 && personData[i, 2]  < 24.9)
                {
                    status[i] = "Normal";
                }
                else if (personData[i, 2]  > 25.0 && personData[i, 2] < 39.9)
                {
                    status[i] = "OverWeight";
                }
                else if (personData[i, 2] >= 40.0)
                {
                    status[i] = "Obese";
                }
            }
            //print results
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("\nPerson " + (i + 1));
                Console.WriteLine("Weight : " + personData[i, 0] + " kg");
                Console.WriteLine("Height : " + personData[i, 1] + " m");
                Console.WriteLine("BMI    : " + personData[i, 2].ToString("F2"));
                Console.WriteLine("Status : " + status[i]);
            }
        }
    }
}
