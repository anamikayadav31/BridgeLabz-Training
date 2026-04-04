using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level2
{
    internal class DateArithmetic
    {
       
        public static void Main(string[] args)
        {
            // Take date input from user
            Console.Write("Enter a date (yyyy-MM-dd) ");
            DateTime inputDate = DateTime.Parse(Console.ReadLine());

            // Add 7 days
            DateTime newDate = inputDate.AddDays(7);

            // Add 1 month
            newDate = newDate.AddMonths(1);

            // Add 2 years
            newDate = newDate.AddYears(2);

            // Subtract 3 weeks (3*7 = 21 days)
            newDate = newDate.AddDays(-21);

            // print the final result
            Console.WriteLine("Resulting date: " + newDate.ToString("yyyy-MM-dd"));
        }
    }


}
