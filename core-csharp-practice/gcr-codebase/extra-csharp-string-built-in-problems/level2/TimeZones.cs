using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level2
{
    internal class TimeZones
    {
       
      
        public static void Main(string[] args)
        {
            //current UTC time
            DateTimeOffset utcTime = DateTimeOffset.UtcNow;
            Console.WriteLine("Current UTC Time: " + utcTime);

            // display GMT (same as UTC)
            TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            DateTimeOffset gmtTime = TimeZoneInfo.ConvertTime(utcTime, gmtZone);
            Console.WriteLine("Current GMT Time: " + gmtTime);

            // display IST (Indian Standard Time, UTC+5:30)
            TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTimeOffset istTime = TimeZoneInfo.ConvertTime(utcTime, istZone);
            Console.WriteLine("Current IST Time: " + istTime);

            // display PST (Pacific Standard Time, UTC-8)
            TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTimeOffset pstTime = TimeZoneInfo.ConvertTime(utcTime, pstZone);
            Console.WriteLine("Current PST Time: " + pstTime);
        }
    }


}

