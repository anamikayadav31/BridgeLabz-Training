using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.scnerio_based.supermarketBillingQueue
{
    internal class BillingUtility : IBilling
    {


        private Queue<Customer> customerQueue = new Queue<Customer>();
        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        // Add new items to supermarket
        public void AddItems()
        {
            Console.Write("Enter number of items to add: ");
            int itemCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine($"\nEnter details of item {i + 1}:");
                Console.Write("Item Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                int price = int.Parse(Console.ReadLine());

                Console.Write("Stock: ");
                int stock = int.Parse(Console.ReadLine());

                items[name] = new Item
                {
                    Name = name,
                    Price = price,
                    Stock = stock
                };
            }

            Console.WriteLine("\nItems added successfully!");
        }

        // Add a customer to the queue
        public void AddCustomer()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items available in the supermarket. Add items first!");
                return;
            }

            Customer customer = new Customer();
            Console.Write("Enter customer name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Enter number of items customer wants to purchase: ");
            int purchaseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < purchaseCount; i++)
            {
                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine();

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                customer.PurchasedItems[itemName] = quantity;
            }

            customerQueue.Enqueue(customer);
            Console.WriteLine($"{customer.Name} added to the billing queue.");
        }

        // Remove customer from queue
        public void RemoveCustomer()
        {
            if (customerQueue.Count > 0)
            {
                Customer customer = customerQueue.Dequeue();
                Console.WriteLine($"{customer.Name}'s billing removed from queue.");
            }
            else
            {
                Console.WriteLine("No customers in the queue.");
            }
        }

        // Process billing for customers
        public void ProcessBilling()
        {
            if (customerQueue.Count == 0)
            {
                Console.WriteLine("No customers in queue to process billing.");
                return;
            }

            while (customerQueue.Count > 0)
            {
                Customer customer = customerQueue.Dequeue();
                int totalBill = 0;
                Console.WriteLine($"\nProcessing billing for {customer.Name}:");

                foreach (var purchase in customer.PurchasedItems)
                {
                    if (items.ContainsKey(purchase.Key))
                    {
                        Item item = items[purchase.Key];
                        if (item.Stock >= purchase.Value)
                        {
                            int cost = item.Price * purchase.Value;
                            totalBill += cost;
                            item.Stock -= purchase.Value;
                        }
                        else
                        {
                            Console.WriteLine($"Insufficient stock for {purchase.Key}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Item {purchase.Key} not found in supermarket.");
                    }
                }

                Console.WriteLine($"Total Bill Amount for {customer.Name}: ₹{totalBill}");
            }
        }

        // Display current stock
        public void UpdateStock()
        {
            Console.WriteLine("\nCurrent Stock:");
            if (items.Count == 0)
            {
                Console.WriteLine("No items in supermarket.");
                return;
            }

            foreach (var item in items.Values)
            {
                Console.WriteLine($"{item.Name} - {item.Stock} units");
            }
        }
    }
}