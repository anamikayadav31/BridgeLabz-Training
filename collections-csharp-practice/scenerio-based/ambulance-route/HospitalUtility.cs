using System;

namespace BridgeLabzTraining.Collections.scnerio_based.ambulance_route
{
    internal class HospitalUtility
    {
        // Head of the circular linked list
        private HospitalUnit head = null;

        // Adds a new hospital unit to the circular list
        public void AddUnit(string name)
        {
            HospitalUnit newNode = new HospitalUnit(name);

            // If list is empty
            if (head == null)
            {
                head = newNode;
                newNode.Next = head;
            }
            else
            {
                // Traverse to last unit
                HospitalUnit temp = head;
                while (temp.Next != head)
                    temp = temp.Next;

                // Insert new unit at the end
                temp.Next = newNode;
                newNode.Next = head;
            }
            Console.WriteLine("Unit added successfully.");
        }

        // Displays all hospital units in the route
        public void DisplayUnits()
        {
            if (head == null)
            {
                Console.WriteLine("No units available.");
                return;
            }

            HospitalUnit temp = head;
            Console.WriteLine("\nHospital Circular Route:");
            do
            {
                Console.WriteLine($"{temp.Name} | Available: {temp.IsAvailable}");
                temp = temp.Next;
            } while (temp != head);
        }

        // Redirects patient to the next available unit
        public void RedirectPatient()
        {
            if (head == null)
            {
                Console.WriteLine("No units available.");
                return;
            }

            HospitalUnit temp = head;
            do
            {
                // Check for availability
                if (temp.IsAvailable)
                {
                    Console.WriteLine($"Patient redirected to {temp.Name}");
                    return;
                }
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("No available unit found!");
        }

        // Marks a unit as under maintenance
        public void MarkUnderMaintenance(string name)
        {
            if (head == null) return;

            HospitalUnit temp = head;
            do
            {
                if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    temp.IsAvailable = false;
                    Console.WriteLine($"{name} is now under maintenance.");
                    return;
                }
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("Unit not found.");
        }

        // Removes a hospital unit from the route
        public void RemoveUnit(string name)
        {
            if (head == null) return;

            HospitalUnit curr = head, prev = null;

            do
            {
                if (curr.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    // If not the first node
                    if (prev != null)
                        prev.Next = curr.Next;

                    // If removing the head node
                    if (curr == head)
                    {
                        HospitalUnit temp = head;
                        while (temp.Next != head)
                            temp = temp.Next;

                        head = head.Next;
                        temp.Next = head;
                    }

                    Console.WriteLine($"{name} removed.");
                    return;
                }

                prev = curr;
                curr = curr.Next;
            } while (curr != head);

            Console.WriteLine("Unit not found.");
        }
    }
}

