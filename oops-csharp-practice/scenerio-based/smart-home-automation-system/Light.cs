using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation
{
    // Light class inherits Appliance
    internal class Light : Appliance
    {
        // Constructor sets appliance name as "Light"
        public Light() : base("Light") { }

        // Turns ON the light
        public override void TurnOn()
        {
            Console.WriteLine(" Light is ON with normal brightness.");
        }

        // Turns OFF the light
        public override void TurnOff()
        {
            Console.WriteLine(" Light is OFF.");
        }
    }
}