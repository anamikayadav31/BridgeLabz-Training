using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    internal class FinallyBlock
    {
   
        static void Main()
        {
            try
            {
                // Take numbers
                Console.Write("Enter first number: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int b = int.Parse(Console.ReadLine());

                // Perform division
                int result = a / b;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                // Handle division by zero
                Console.WriteLine("Cannot divide by zero");
            }
            finally
            {
                // Always executed
                Console.WriteLine("Operation completed");
            }
        }
    }
}
