using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class GetMonth

    {
        public static void Main(string[] args)
        {
            Console.Write("Enter month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            DisplayCalendar(month, year);
        }
        //  Get month name
        public static string GetMonthName(int month)
        {
            string[] months = { "January", "February", "March", "April", "May", "June",
                            "July", "August", "September", "October", "November", "December" };
            return months[month - 1];
        }

        //  Check leap year
        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        // Get number of days in month
        public static int GetDaysInMonth(int month, int year)
        {
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (month == 2 && IsLeapYear(year))
                return 29;
            return days[month - 1];
        }

        // get first day of the month (0=Sunday, 1=Monday,...6=Saturday)
        public static int GetFirstDay(int month, int year)
        {
            int y = year;
            int m = month;
            int d = 1; // first day of month

            int y0 = y - (14 - m) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = m + 12 * ((14 - m) / 12) - 2;
            int d0 = (d + x + (31 * m0) / 12) % 7;

            return d0;
        }

        // d+e+f. Display calendar
        public static void DisplayCalendar(int month, int year)
        {
            string monthName = GetMonthName(month);
            int days = GetDaysInMonth(month, year);
            int firstDay = GetFirstDay(month, year);

            Console.WriteLine("\n   " + monthName + " " + year);
            Console.WriteLine("Su Mo Tu We Th Fr Sa");

            // first loop for indentation
            for (int i = 0; i < firstDay; i++)
            {
                Console.Write("   "); // 3 spaces for alignment
            }

            // second loop to print days
            for (int day = 1; day <= days; day++)
            {
                Console.Write($"{day,3}"); // right-justified in 3 spaces
                if ((day + firstDay) % 7 == 0)
                    Console.WriteLine(); // new line after Saturday
            }
            Console.WriteLine(); // final line
        }
    }


}