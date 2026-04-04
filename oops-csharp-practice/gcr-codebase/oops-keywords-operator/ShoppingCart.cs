using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.oopsKeywordsOperator
{
    internal class ShoppingCart
    {


        // Static variable: discount applies to all products
        public static double DiscountPercent = 0;

        // Read-only product ID: cannot be changed after creation
        public readonly int ProductId;

        // Product details
        public string ProductName;
        public double Price;
        public int Quantity;

        // Constructor to initialize product details
        public ShoppingCart(int productId, string productName, double price, int quantity)
        {
            this.ProductId = productId;       // 'this' refers to current object
            this.ProductName = productName;
            this.Price = price;
            this.Quantity = quantity;
        }

        // Static method to set discount
        public static void SetDiscount(double discount)
        {
            DiscountPercent = discount;
        }

        // Method to display product details
        public void ShowProductDetails()
        {
            double totalPrice = Price * Quantity;
            double discountAmount = totalPrice * DiscountPercent / 100;
            double finalPrice = totalPrice - discountAmount;

            Console.WriteLine("\nProduct Details:");
            Console.WriteLine("Product ID     : " + ProductId);
            Console.WriteLine("Product Name   : " + ProductName);
            Console.WriteLine("Price          : " + Price);
            Console.WriteLine("Quantity       : " + Quantity);
            Console.WriteLine("Discount (%)   : " + DiscountPercent);
            Console.WriteLine("Final Amount   : " + finalPrice);
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Ask user for discount percentage
            Console.Write("Enter discount percentage: ");
            double discount = double.Parse(Console.ReadLine());

            // Update static discount
            ShoppingCart.SetDiscount(discount);

            Console.WriteLine();

            // Ask user for product details
            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            // Create a product object
            ShoppingCart product = new ShoppingCart(id, name, price, quantity);

            Console.WriteLine();

            // Check object type using 'is' keyword
            if (product is ShoppingCart)
            {
                Console.WriteLine("Valid Product Object");
                product.ShowProductDetails();
            }
            else
            {
                Console.WriteLine("Invalid Product");
            }

            Console.ReadLine();
        }
    }
}