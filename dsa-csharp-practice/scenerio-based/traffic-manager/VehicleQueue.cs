using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.trafficManager
{
    internal class VehicleQueue
    {
        // Custom queue for vehicles waiting to enter
            private string[] queue;
            private int front, rear, size, capacity;

            public VehicleQueue(int capacity)
            {
                this.capacity = capacity;
                queue = new string[capacity];
                front = 0;
                rear = -1;
                size = 0;
            }

            // Enqueue vehicle
            public void Enqueue(string number)
            {
                if (size == capacity)
                {
                    Console.WriteLine(" Queue Overflow! Waiting area full.");
                    return;
                }

                rear = (rear + 1) % capacity;
                queue[rear] = number;
                size++;

                Console.WriteLine($" Vehicle {number} added to waiting queue.");
            }

            // Dequeue vehicle
            public string Dequeue()
            {
                if (size == 0)
                {
                    Console.WriteLine(" Queue Underflow! No vehicles waiting.");
                    return null;
                }

                string number = queue[front];
                front = (front + 1) % capacity;
                size--;

                return number;
            }

            public bool IsEmpty()
            {
                return size == 0;
            }
        }

    }

