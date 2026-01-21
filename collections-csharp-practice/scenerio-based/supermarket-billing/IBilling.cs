using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.supermarketBillingQueue
{
    internal interface IBilling
    {
        void AddCustomer();
        void RemoveCustomer();
        void ProcessBilling();
        void UpdateStock();
    }
}
