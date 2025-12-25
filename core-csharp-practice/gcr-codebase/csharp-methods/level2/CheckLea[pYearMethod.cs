using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class CheckLea_pYearMethod
    {

            public static void Main(string[] args)
            {
                //ask user to input year
                int year = int.Parse(Console.ReadLine());
               // check whether year is valid or not
                if (year < 1582)
                {                    
                    return; // Exit program
                }

                // call method
                if (IsLeapYear(year))
                {
                    Console.WriteLine(year + " is a Leap year");
                }
                else
                {
                    Console.WriteLine(year + " is not a Leap year");
                }
            }

            //create method to check whether the given year is a leap year
            public static bool IsLeapYear(int year)
            {
                if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                {
                    return true;
                }

                return false;
            }
        
    }

}

