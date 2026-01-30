using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.trafficManager
{
   

// Manages vehicles inside the roundabout using Circular Linked List
internal class Roundabout
    {
        private VehicleNode head;   // Starting point of circular list

        // Add vehicle into the roundabout
        public void AddVehicle(string number)
        {
            VehicleNode newNode = new VehicleNode(number);

            // Case 1: Roundabout is empty
            if (head == null)
            {
                head = newNode;
                head.Next = head;   // Point to itself (circular)
            }
            else
            {
                VehicleNode temp = head;

                // Move to last vehicle
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }

                temp.Next = newNode;   // Last vehicle points to new one
                newNode.Next = head;   // New vehicle points back to head
            }

            Console.WriteLine($" Vehicle {number} entered the roundabout.");
        }

        // Remove vehicle from roundabout
        public void RemoveVehicle(string number)
        {
            // Case 1: Roundabout empty
            if (head == null)
            {
                Console.WriteLine(" Roundabout is empty.");
                return;
            }

            VehicleNode current = head;
            VehicleNode previous = null;

            // Traverse circular list 
            while (true)
            {
                // Vehicle found
                if (current.VehicleNumber == number)
                {
                    // Case 2: Only one vehicle
                    if (current == head && current.Next == head)
                    {
                        head = null;
                    }
                    // Case 3: Removing head vehicle
                    else if (current == head)
                    {
                        VehicleNode temp = head;

                        // Move to last node
                        while (temp.Next != head)
                        {
                            temp = temp.Next;
                        }

                        temp.Next = head.Next;
                        head = head.Next;
                    }
                    // Case 4: Removing middle or last vehicle
                    else
                    {
                        previous.Next = current.Next;
                    }

                    Console.WriteLine($" Vehicle {number} exited the roundabout.");
                    return;
                }

                previous = current;
                current = current.Next;

                // If full circle completed
                if (current == head)
                    break;
            }

            Console.WriteLine(" Vehicle not found in roundabout.");
        }

        // Display vehicles in roundabout
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine(" Roundabout is empty.");
                return;
            }

            Console.Write(" Vehicles in roundabout: ");

            VehicleNode temp = head;

            // Print until we come back to head
            while (true)
            {
                Console.Write(temp.VehicleNumber + " → ");
                temp = temp.Next;

                if (temp == head)
                    break;
            }

            Console.WriteLine("(back to start)");
        }
    }
}

