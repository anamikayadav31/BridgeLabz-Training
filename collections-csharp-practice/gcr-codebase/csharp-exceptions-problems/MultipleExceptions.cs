using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    internal class MultipleExceptions
    {
    
  

        static void Main()
        {
            try
            {
                // Create and initialize array
                int[] arr = { 10, 20, 30, 40 };

                // Take index from user
                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                // Print value at index
                Console.WriteLine("Value at index " + index + ": " + arr[index]);
            }
            catch (IndexOutOfRangeException)
            {
                // Index outside array range
                Console.WriteLine("Invalid index!");
            }
            catch (NullReferenceException)
            {
                // Array not initialized
                Console.WriteLine("Array is not initialized!");
            }
        }
    }
}
