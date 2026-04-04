using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.supermarketBillingQueue
{
    internal class Customer
    {
      


        public string Name { get; set; }
        public Dictionary<string, int> PurchasedItems { get; set; }
            = new Dictionary<string, int>();
    }
}
