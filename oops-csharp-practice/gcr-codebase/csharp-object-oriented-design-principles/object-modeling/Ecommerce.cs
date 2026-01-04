using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class Ecommerce
    {


        public class Product
        {
            // Product details
            public string itemName;
            public double itemPrice;

            // Constructor
            public Product(string itemName, double itemPrice)
            {
                this.itemName = itemName;
                this.itemPrice = itemPrice;
            }

            // Display product info
            public void ShowProduct()
            {
                Console.WriteLine("Product: " + itemName + ", Price: " + itemPrice);
            }
        }

        // Order class (contains products)
        public class Order
        {
            // Order details
            public int orderNumber;
            public List<Product> productList;

            // Constructor
            public Order(int orderNumber)
            {
                this.orderNumber = orderNumber;
                productList = new List<Product>();
            }

            // Add product to order (Aggregation)
            public void AddProduct(Product productObj)
            {
                productList.Add(productObj);
            }

            // Display order details
            public void ShowOrder()
            {
                Console.WriteLine("\nOrder ID: " + orderNumber);
                Console.WriteLine("Products in this order:");

                for (int i = 0; i < productList.Count; i++)
                {
                    productList[i].ShowProduct();
                }
            }
        }

        // Customer class
        public class Customer
        {
            // Customer name
            public string buyerName;

            // Constructor
            public Customer(string buyerName)
            {
                this.buyerName = buyerName;
            }

            // Customer places an order (Communication)
            public void PlaceOrder(Order orderObj)
            {
                Console.WriteLine("\nCustomer " + buyerName +
                                  " placed Order ID: " + orderObj.orderNumber);
                orderObj.ShowOrder();
            }
        }

        // Main method
        public static void Main(string[] args)
        {
            // Take customer name
            Console.WriteLine("Enter Customer Name:");
            string inputCustomerName = Console.ReadLine();

            Customer customerObj = new Customer(inputCustomerName);

            // Take order ID
            Console.WriteLine("Enter Order ID:");
            int inputOrderId = int.Parse(Console.ReadLine());

            Order orderObj = new Order(inputOrderId);

            // Take number of products
            Console.WriteLine("Enter Number of Products:");
            int productCount = int.Parse(Console.ReadLine());

            // Loop to add products
            for (int i = 1; i <= productCount; i++)
            {
                Console.WriteLine("\nEnter Product Name:");
                string productNameInput = Console.ReadLine();

                Console.WriteLine("Enter Product Price:");
                double productPriceInput = double.Parse(Console.ReadLine());

                Product productObj = new Product(productNameInput, productPriceInput);
                orderObj.AddProduct(productObj);
            }

            // Customer places the order
            customerObj.PlaceOrder(orderObj);
        }
    }
}
