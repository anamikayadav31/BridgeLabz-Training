using BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation
{

    internal class Fan : Appliance
    {
        public Fan() : base("Fan") { }

        public override void TurnOn()
        {
            Console.WriteLine(" Fan is ON at medium speed.");
        }

        public override void TurnOff()
        {
            Console.WriteLine(" Fan is OFF.");
        }
    }
}