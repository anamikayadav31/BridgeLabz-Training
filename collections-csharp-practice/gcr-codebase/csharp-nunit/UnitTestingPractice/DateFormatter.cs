using System;
using System.Globalization;

namespace UnitTestingPractice
{
    public class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            // Try to parse exact format yyyy-MM-dd
            DateTime date = DateTime.ParseExact(
                inputDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture
            );

            // Convert to dd-MM-yyyy
            return date.ToString("dd-MM-yyyy");
        }
    }
}
