using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.trafficManager
{

    // Controls user interaction
    internal class TrafficMenu
    {      
        private Roundabout roundabout = new Roundabout();
        private VehicleQueue queue = new VehicleQueue(5);

        public void Start()
        {
            Console.WriteLine(" TrafficManager System ");

            while (true)
            {
                Console.WriteLine("\n1. Add vehicle to waiting queue");
                Console.WriteLine("2. Allow vehicle to enter roundabout");
                Console.WriteLine("3. Remove vehicle from roundabout");
                Console.WriteLine("4. Display roundabout status");
                Console.WriteLine("5. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter vehicle number: ");
                        queue.Enqueue(Console.ReadLine());
                        break;

                    case 2:
                        if (!queue.IsEmpty())
                        {
                            string v = queue.Dequeue();
                            roundabout.AddVehicle(v);
                        }
                        break;

                    case 3:
                        Console.Write("Enter vehicle number to remove: ");
                        roundabout.RemoveVehicle(Console.ReadLine());
                        break;

                    case 4:
                        roundabout.Display();
                        break;

                    case 5:
                        Console.WriteLine(" Traffic system closed.");
                        return;
                }
            }
        }
    }

}

