using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation
{
    internal abstract class Appliance : IControllable
    {
        // Appliance name
        public string Name { get; set; }

        // Constructor
        protected Appliance(string name)
        {
            Name = name;
        }

        // Abstract methods
        public abstract void TurnOn();
        public abstract void TurnOff();
    }
}
