using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{


    // Interface for discount functionality
    interface IDiscount
    {
        double GetDiscountAmount();
        string GetDiscountInfo();
    }

    // Abstract base class for all food items
    abstract class MenuItem
    {
        // Private fields for encapsulation
        private string name;
        private double unitPrice;
        private int quantity;

        // Properties to access private fields
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        // Abstract method to calculate total price
        public abstract double CalculateTotal();

        // Concrete method to display item details
        public void ShowItemDetails()
        {
            Console.WriteLine("Item Name   : " + Name);
            Console.WriteLine("Unit Price  : " + UnitPrice);
            Console.WriteLine("Quantity    : " + Quantity);
            Console.WriteLine("Total Price : " + CalculateTotal());
        }
    }

    // Veg item class
    class VegMenuItem : MenuItem, IDiscount
    {
        // Total price without discount
        public override double CalculateTotal()
        {
            return UnitPrice * Quantity;
        }

        // Calculate discount for veg items
        public double GetDiscountAmount()
        {
            return CalculateTotal() * 0.10; // 10% discount
        }

        // Display discount info
        public string GetDiscountInfo()
        {
            return "10% discount on vegetarian items";
        }
    }

    // Non-veg item class
    class NonVegMenuItem : MenuItem, IDiscount
    {
        // Extra charge per item
        private double extraCharge = 50;

        // Total price including extra charges
        public override double CalculateTotal()
        {
            return (UnitPrice * Quantity) + (extraCharge * Quantity);
        }

        // Calculate discount for non-veg items
        public double GetDiscountAmount()
        {
            return CalculateTotal() * 0.05; // 5% discount
        }

        // Display discount info
        public string GetDiscountInfo()
        {
            return "5% discount on non-vegetarian items";
        }
    }

    // Main program class
    internal class FoodDeliveryApp
    {
        public static void Main(string[] args)
        {
            Console.Write("How many food items do you want to order? ");
            int totalItems = int.Parse(Console.ReadLine());

            // Array to store MenuItem references (polymorphism)
            MenuItem[] orders = new MenuItem[totalItems];

            for (int i = 0; i < totalItems; i++)
            {
                Console.WriteLine("\nSelect food type (1-Veg, 2-NonVeg): ");
                int type = int.Parse(Console.ReadLine());

                MenuItem item;

                if (type == 1)
                    item = new VegMenuItem();
                else
                    item = new NonVegMenuItem();

                Console.Write("Enter item name: ");
                item.Name = Console.ReadLine();

                Console.Write("Enter unit price: ");
                item.UnitPrice = double.Parse(Console.ReadLine());

                Console.Write("Enter quantity: ");
                item.Quantity = int.Parse(Console.ReadLine());

                orders[i] = item;
            }

            // Display all orders and discounts
            Console.WriteLine("\n--- Order Summary ---\n");

            foreach (var item in orders)
            {
                item.ShowItemDetails();

                if (item is IDiscount discount)
                {
                    Console.WriteLine("Discount Amount : " + discount.GetDiscountAmount());
                    Console.WriteLine(discount.GetDiscountInfo());
                }

                Console.WriteLine();
            }
        }
    }
}