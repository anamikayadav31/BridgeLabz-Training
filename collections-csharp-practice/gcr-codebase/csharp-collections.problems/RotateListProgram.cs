using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{



    class RotateListProgram
    {
        static List<int> RotateList(List<int> list, int rotateBy)
        {
            List<int> rotatedList = new List<int>();
            int n = list.Count;

            // Handle cases where rotateBy is greater than list size
            rotateBy = rotateBy % n;

            // Add elements from rotateBy to end
            for (int i = rotateBy; i < n; i++)
            {
                rotatedList.Add(list[i]);
            }

            // Add elements from start to rotateBy
            for (int i = 0; i < rotateBy; i++)
            {
                rotatedList.Add(list[i]);
            }

            return rotatedList;
        }

        static void Main()
        {
            Console.WriteLine("Enter numbers (space separated):");
            string[] input = Console.ReadLine().Split(' ');

            List<int> numbers = new List<int>();

            // Convert input to integer list
            foreach (string item in input)
            {
                numbers.Add(int.Parse(item));
            }

            Console.WriteLine("Enter number of positions to rotate:");
            int rotateBy = int.Parse(Console.ReadLine());

            List<int> result = RotateList(numbers, rotateBy);

            Console.WriteLine("Rotated List:");
            Console.WriteLine(string.Join(", ", result));
        }
    }
}