using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.browserbuddy
{
    internal class BrowserMain
    {
        static void Main()
        {
            // Creating menu object to handle browser operations
            BrowserMenu menu = new BrowserMenu();

            Console.WriteLine("Welcome to Browser Buddy!");

            // Display browser menu
            menu.ShowMenu();
        }
    }
}
