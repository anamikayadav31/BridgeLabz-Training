using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.Annotations
{

    class LegacyAPI
    {
        // Mark old method as obsolete
        [Obsolete("OldFeature is outdated. Use NewFeature instead.")]
        public void OldFeature()
        {
            Console.WriteLine("This is the old feature.");
        }

        // New recommended method
        public void NewFeature()
        {
            Console.WriteLine("This is the new feature.");
        }
    }

    class ObsoleteAttribute
    {
        static void Main()
        {
            LegacyAPI api = new LegacyAPI();

            // Calling obsolete method (shows warning)
            api.OldFeature();

            // Calling new method
            api.NewFeature();
        }
    }
}
