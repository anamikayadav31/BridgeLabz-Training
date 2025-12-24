using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class BmiCompute
    {
        public static void Main(string[] args)
        {//ask user to input number
            int num = int.Parse(Console.ReadLine());
            //create arrays 
            int[] weight = new int[num];
            int[] height = new int[num];
            double[] bmi = new double[num];
            string[] status = new string[num];
            //ask user to input weights and heights
            for (int i = 0; i < num; i++)
            {
                weight[i] = int.Parse(Console.ReadLine());
                height[i] = int.Parse(Console.ReadLine());

            }
            //compute bmi
            for (int i = 0; i < num; i++)
            {
                double h = height[i] / 100.0;
                bmi[i] = weight[i] / (h*h);
            }
           //check conditions for status
            for (int i = 0; i < num; i++)
            {
                if (bmi[i] <= 18.4)
                {
                    status[i] = "Underweight";
                }
                else if (bmi[i] > 18.5 && bmi[i] < 24.9)
                {
                    status[i] = "Normal";
                }
                else if (bmi[i] > 25.0 && bmi[i] < 39.9)
                {
                    status[i] = "OverWeight";
                }
                else if (bmi[i] >= 40.0)
                {
                    status[i] = "Obese";
                }
            }
            //print results
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(status[i]);
                Console.WriteLine(bmi[i].ToString("F2"));
            }
        }

    }
}
