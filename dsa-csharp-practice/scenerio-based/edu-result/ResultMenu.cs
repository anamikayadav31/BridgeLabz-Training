using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.EduResults
{
        internal class ResultMenu
        {
            public void ShowMenu()
            {
                ResultUtility utility = new ResultUtility();

                while (true)
                {
                    Console.WriteLine(" EDU RESULTS MENU ");
                    Console.WriteLine("1.  Add Student");
                    Console.WriteLine("2.  Add District to Student");
                    Console.WriteLine("3.  Add Score to Student");
                    Console.WriteLine("4.  Generate Rank Sheet (Merge Sort)");
                    Console.WriteLine("5.  Exit");
                    Console.Write(" Enter your choice: ");

                    string choice = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            utility.AddStudent();
                            break;
                        case "2":
                            utility.AddDistrict();
                            break;
                        case "3":
                            utility.AddScore();
                            break;
                        case "4":
                            utility.ViewRank();
                            break;
                        case "5":
                            Console.WriteLine(" Exiting EduResults. Thank you!");
                            return;
                        default:
                            Console.WriteLine(" Invalid choice. Try again.\n");
                            break;
                    }
                }
            }
        }
    }

