using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.Annotations
{



    [AttributeUsage(AttributeTargets.Method)]
    class CacheResultAttribute : Attribute
    {
    }

    class MathService
    {
        private static Dictionary<int, int> cache = new Dictionary<int, int>();

        [CacheResult]
        public int Square(int number)
        {
            if (cache.ContainsKey(number))
            {
                Console.WriteLine("Fetching from cache...");
                return cache[number];
            }

            Console.WriteLine("Calculating result...");
            int result = number * number;
            cache[number] = result;

            return result;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            MathService service = new MathService();

            while (true)
            {
                Console.Write("\nEnter a number (or -1 to exit): ");
                int input = int.Parse(Console.ReadLine());

                if (input == -1)
                    break;

                int output = service.Square(input);
                Console.WriteLine("Result: " + output);
            }
        }
    }
}