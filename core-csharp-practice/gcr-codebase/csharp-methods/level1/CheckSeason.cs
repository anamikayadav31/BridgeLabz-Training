using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods
{
    internal class CheckSeason
    {
        public static void Main(string[] args)
        { // Read month from user
            int month = int.Parse(Console.ReadLine());
            // Read date from user
            int date = int.Parse(Console.ReadLine());
            // Call method to check if it is Spring Season
            if (Checkseason(date, month))
            {
                Console.WriteLine("It is a spring season");
            }
            else
            {
                Console.WriteLine("Not a spring season");
            }
        }//create method to check whether given month and day fall in Spring Season
        public static bool Checkseason(int date, int month)
        {
            if ((month == 3 && date >= 20) ||
           (month == 4) ||
           (month == 5) ||
           (month == 6 && date <= 20))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
