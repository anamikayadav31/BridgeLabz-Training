using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.parcelTracker
{
    internal class ParcelMenu
    {
            private ParcelUtility utility = new ParcelUtility();

            public void Start()
            {
                int choice;
                do
                {
                    Console.WriteLine("\n1.Add Stage 2.Insert Checkpoint 3.Display 4.Exit");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: utility.AddStage(); break;
                        case 2: utility.InsertCheckpoint(); break;
                        case 3: utility.Display(); break;
                    }
                } while (choice != 4);
            }
        }
    }

