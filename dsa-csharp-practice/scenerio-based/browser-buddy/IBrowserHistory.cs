using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.browserBuddy
{
    // Defines browser navigation actions
    interface IBrowserHistory
    {
        void Visit();     // Open a new website
        void Back();      // Go to previous page
        void Forward();   // Go to next page
    }
}

