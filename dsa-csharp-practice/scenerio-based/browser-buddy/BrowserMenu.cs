using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.browserbuddy
{
    internal class BrowserMenu
    {
       public void ShowMenu()
        {
            TabHistory browser = new TabHistory();
            
            int choice;
            while (true)
            {


                Console.WriteLine("\n--- BrowserBuddy Menu ---");
                Console.WriteLine("1. Visit Page");
                Console.WriteLine("2. Back");
                Console.WriteLine("3 Forward");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());



                switch (choice)
                {
                    case 1:
                        browser.Visit();
                        break;
                    case 2:
                        browser.Back();
                        break;
                    case 3:
                        browser.Forward();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Browser Buddy...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }


                
            }
        }
    }
}