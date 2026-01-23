using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    internal class NestedTryBlock
    {
   

        static void Main()
        {
            int[] arr = { 10, 20, 30 };

            try
            {
                // Take index
                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                try
                {
                    // Take divisor
                    Console.Write("Enter divisor: ");
                    int divisor = int.Parse(Console.ReadLine());

                    // Divide array element
                    int result = arr[index] / divisor;
                    Console.WriteLine("Result: " + result);
                }
                catch (DivideByZeroException)
                {
                    // Handle division by zero
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                // Handle invalid index
                Console.WriteLine("Invalid array index!");
            }
        }
    }
}
