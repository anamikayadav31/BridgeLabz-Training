using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.strings
{
    internal class FormatExec
    {
        public static void Main(string[] args)
        {
            
            try
            {//take a non-numeric string from user
                int num = int.Parse(Console.ReadLine());
               

            }
            //it throws exception
            catch ( FormatException e)
            {
                Console.WriteLine("Caught  FormatException!");
                Console.WriteLine(e.Message);


            }
        }




    }
}
