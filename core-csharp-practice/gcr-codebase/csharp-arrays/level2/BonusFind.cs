using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.arrays.level2
{
    internal class BonusFind
    {
        public static void Main(string[] args)
        {//create a array to store bonus 
            double[] bonus = new double[10];
            //create an array to store new Salary
            double[] newSalary = new double[10];
            //create an array to store salary
            double[] salary = new double[10];
            //ask user to input salaries
            for (int i = 0; i < salary.Length; i++)
            {
                salary[i] = double.Parse(Console.ReadLine());
            }
            //create an array to store years of service
            int[]  years = new  int[10];
            //ask user to input years of service
            for (int i = 0; i <  years.Length; i++)
            {
                 years[i] = int.Parse(Console.ReadLine());
            }
            //initialise totalbonus,totaloldsalary,totalnewSalary as 0
            double totalBonus=0;
            double totalOldSalary=0;
            double totalNewSalary=0;
            //iterate loop 
            for (int i = 0; i <  years.Length; i++)
            {//check condition 
                if (years[i] > 5)
                {
                    bonus[i] =salary[i]* 0.05;   
                }
                else 
                {
                    bonus[i] =  salary[i] * 0.02;
                }
                //compute newsalary,totalBonus and totalOldSalary
                newSalary[i] = salary[i] + bonus[i];
                totalBonus += bonus[i];
                totalOldSalary += salary[i];
                totalNewSalary += salary[i];
            }
            //print results
            Console.WriteLine("Total Old Salary is  " + totalOldSalary);
            Console.WriteLine("Total Bonus Paid is  " + totalBonus);
            Console.WriteLine("Total New Salary is  " + totalNewSalary);
        }
    }
}
