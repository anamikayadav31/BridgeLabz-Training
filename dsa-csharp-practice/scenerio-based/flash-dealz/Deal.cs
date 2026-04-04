using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.flashDealz
{
    
        // Represents a product in flash sale
        internal class Deal
        {
            private string productName;   // Product name
            private double discount;      // Discount percentage

            public string ProductName
            {
                get { return productName; }
                set { productName = value; }
            }

            public double Discount
            {
                get { return discount; }
                set { discount = value; }
            }

            // Constructor to initialize product details
            public Deal(string productName, double discount)
            {
                this.productName = productName;
                this.discount = discount;
            }

            // Display product details
            public override string ToString()
            {
                return $"Product: {productName}, Discount: {discount}%";
            }
        }
    }


