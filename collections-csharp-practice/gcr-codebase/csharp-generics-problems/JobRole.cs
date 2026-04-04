using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.generics_problems
{


    // Base class for job roles
    abstract class JobRole
    {
        public string RoleName { get; set; }
    }

    // Job role types
    class SoftwareEngineer : JobRole { }
    class DataScientist : JobRole { }

    // Generic Resume class
    class Resume<T> where T : JobRole
    {
        public List<T> Candidates = new List<T>(); // Stores candidates
    }

    class Program
    {
        static void Main()
        {
            // Create resume objects
            Resume<SoftwareEngineer> seResume = new Resume<SoftwareEngineer>();
            Resume<DataScientist> dsResume = new Resume<DataScientist>();

            int choice;
            do
            {
                // Menu
                Console.WriteLine("\n1. Add Software Engineer");
                Console.WriteLine("2. Add Data Scientist");
                Console.WriteLine("3. Show Software Engineers");
                Console.WriteLine("4. Show Data Scientists");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add Software Engineer
                        Console.Write("Enter role name: ");
                        seResume.Candidates.Add(
                            new SoftwareEngineer { RoleName = Console.ReadLine() });
                        break;

                    case 2:
                        // Add Data Scientist
                        Console.Write("Enter role name: ");
                        dsResume.Candidates.Add(
                            new DataScientist { RoleName = Console.ReadLine() });
                        break;

                    case 3:
                        // Display Software Engineers
                        Console.WriteLine("Software Engineers:");
                        foreach (var c in seResume.Candidates)
                            Console.WriteLine(c.RoleName);
                        break;

                    case 4:
                        // Display Data Scientists
                        Console.WriteLine("Data Scientists:");
                        foreach (var c in dsResume.Candidates)
                            Console.WriteLine(c.RoleName);
                        break;
                }
            }
            while (choice != 0); // Exit loop
        }
    }

}