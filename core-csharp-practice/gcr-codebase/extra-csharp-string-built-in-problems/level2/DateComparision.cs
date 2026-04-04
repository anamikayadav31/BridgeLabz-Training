using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level2
{
    internal class DateComparision
    {
     
        public static void Main(string[] args)
        {
            // take first date input
            Console.Write("Enter the first date (yyyy-MM-dd): ");
            DateTime date1 = DateTime.Parse(Console.ReadLine());

            // take second date input
            Console.Write("Enter the second date (yyyy-MM-dd): ");
            DateTime date2 = DateTime.Parse(Console.ReadLine());

            // compare the two dates
            int result = DateTime.Compare(date1, date2);

            if (result < 0)
            {
                Console.WriteLine("The first date is before the second date.");
            }
            else if (result > 0)
            {
                Console.WriteLine("The first date is after the second date.");
            }
            else
            {
                Console.WriteLine("Both dates are the same.");
            }
        }
    }

}

