using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation
{
    // Entry point of the application
    internal class SmartHomeMain
    {
        public static void Main()
        {
            // Create menu object
            SmartHomeMenu menu = new SmartHomeMenu();

            // Start menu
            menu.ShowMenu();
        }
    }
}