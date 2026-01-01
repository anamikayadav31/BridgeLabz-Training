using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class ProductInventory
    {


        public string ProductName;   // instance variable
        public double Price;         // instance variable

        public static int TotalProducts = 0;   // class variable

        // Constructor
        public ProductInventory(string name, double cost)
        {
            ProductName = name;
            Price = cost;
            TotalProducts++; // count objects created
        }
        public static void Main(string[] args)
        {
            Console.Write("How many products do you want to enter? ");
            int count = Convert.ToInt32(Console.ReadLine());

            ProductInventory[] products = new ProductInventory[count];

            // Input product details from the user
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for product {i + 1}:");

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                products[i] = new ProductInventory(name, price);
            }

            // Display all product details
            Console.WriteLine("\n--- Product Details ---");
            foreach (ProductInventory product in products)
            {
                product.DisplayProductDetails();
            }

            // Display total number of products
            ProductInventory.DisplayTotalProducts();

            Console.WriteLine("\nProgram finished.");
        }


        // Instance method to display product details
        public void DisplayProductDetails()
        {
            Console.WriteLine("\nProduct Name: " + ProductName);
            Console.WriteLine("Price: " + Price);
        }

        // Class method to display total products
        public static void DisplayTotalProducts()
        {
            Console.WriteLine("\nTotal Products: " + TotalProducts);
        }

    }
}