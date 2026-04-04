using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation
{
    // AC class inherits Appliance
    internal class AC : Appliance
    {
        // Constructor sets appliance name as "AC"
        public AC() : base("AC") { }

        // Turns ON the AC
        public override void TurnOn()
        {
            Console.WriteLine(" AC is ON at 24°C cooling mode.");
        }

        // Turns OFF the AC
        public override void TurnOff()
        {
            Console.WriteLine(" AC is OFF.");
        }
    }
}