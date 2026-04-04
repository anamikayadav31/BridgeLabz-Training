using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level2
{
    internal class DateFormat
    {
        
        public static void Main(string[] args)
        {
            // Get current date
            DateTime today = DateTime.Now;

            // Format 1- dd/MM/yyyy
            string format1 = today.ToString("dd/MM/yyyy");
            Console.WriteLine("Format 1: " + format1);

            // Format 2- yyyy-MM-dd
            string format2 = today.ToString("yyyy-MM-dd");
            Console.WriteLine("Format 2: " + format2);

            // Format 3- EEE, MMM dd, yyyy
           
            string format3 = today.ToString("ddd, MMM dd, yyyy");
            Console.WriteLine("Format 3: " + format3);
        }
    }

}
