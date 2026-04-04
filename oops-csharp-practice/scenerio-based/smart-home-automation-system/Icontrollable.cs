using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.smartHomeAutomation
{
    // Interface that defines common control operations
    internal interface IControllable
    {
        // Turns the appliance ON
        void TurnOn();

        // Turns the appliance OFF
        void TurnOff();
    }
}