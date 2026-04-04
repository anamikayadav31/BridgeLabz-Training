using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class StudentVote
    {
        public static void Main(string[] args)
        {
            // create an array to store age of 10 students
            int[] ages = new int[10];
           // loop to take input
            for (int i = 0; i < ages.Length; i++)
            {
                Console.WriteLine("Enter age of student " + (i + 1) + ":");
                ages[i] = int.Parse(Console.ReadLine());
                // call method to check if student can vote
                bool canVote = CanStudentVote(ages[i]);
               //print result
                if (canVote)
                {
                    Console.WriteLine("Student " + (i + 1) + " can vote.");
                }
                else
                {
                    Console.WriteLine("Student " + (i + 1) + " cannot vote.");
                }
            }
        }
        // create method 
        public static bool CanStudentVote(int age)
        {
            if (age < 0)
            {
                return false;
            }
            if (age >= 18)
            {
                return true;
            }

            return false;
        }
    }
}

            

        
  

