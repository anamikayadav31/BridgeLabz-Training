using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.parcelTracker
{
    internal class ParcelUtility
    {
            private StageNode? head = null;

            public void AddStage()
            {
                Console.Write("Enter stage name: ");
                string stage = Console.ReadLine()!;

                StageNode newNode = new StageNode(new ParcelStage(stage));

                if (head == null)
                {
                    head = newNode;
                    return;
                }

                StageNode temp = head;
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newNode;
            }

            public void InsertCheckpoint()
            {
                Console.Write("Insert after stage: ");
                string target = Console.ReadLine()!;

                Console.Write("New checkpoint: ");
                string checkpoint = Console.ReadLine()!;

                StageNode? temp = head;
                while (temp != null)
                {
                    if (temp.Data.GetStage().Equals(target, StringComparison.OrdinalIgnoreCase))
                    {
                        StageNode newNode = new StageNode(new ParcelStage(checkpoint));
                        newNode.Next = temp.Next;
                        temp.Next = newNode;
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Stage not found.");
            }

            public void Display()
            {
                if (head == null)
                {
                    Console.WriteLine("Parcel lost or not initialized.");
                    return;
                }

                StageNode? temp = head;
                while (temp != null)
                {
                    Console.Write(temp.Data.GetStage() + " -> ");
                    temp = temp.Next;
                }
                Console.WriteLine("END");
            }
        }
    }

