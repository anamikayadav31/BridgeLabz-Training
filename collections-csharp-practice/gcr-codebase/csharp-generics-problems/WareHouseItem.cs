using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.generics_problems
{



    // Base class for all warehouse items
    abstract class WarehouseItem
    {
        public string Name { get; set; }   // Item name
    }

    // Different item types
    class Electronics : WarehouseItem { }
    class Groceries : WarehouseItem { }
    class Furniture : WarehouseItem { }

    // Generic storage class with constraint
    class Storage<T> where T : WarehouseItem
    {
        private List<T> items = new List<T>(); // Stores items

        // Add item to storage
        public void AddItem(T item)
        {
            items.Add(item);
        }

        // Display stored items
        public void DisplayItems()
        {
            foreach (var item in items)
                Console.WriteLine(item.Name);
        }
    }

    class Program
    {
        static void Main()
        {
            // Separate storage for each category
            Storage<Electronics> electronicsStorage = new Storage<Electronics>();
            Storage<Groceries> groceriesStorage = new Storage<Groceries>();
            Storage<Furniture> furnitureStorage = new Storage<Furniture>();

            int choice;
            do
            {
                // Menu options
                Console.WriteLine("\n===== Warehouse Menu =====");
                Console.WriteLine("1. Add Electronics");
                Console.WriteLine("2. Add Groceries");
                Console.WriteLine("3. Add Furniture");
                Console.WriteLine("4. Display Electronics");
                Console.WriteLine("5. Display Groceries");
                Console.WriteLine("6. Display Furniture");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add electronics item
                        electronicsStorage.AddItem(
                            new Electronics { Name = Console.ReadLine() });
                        break;

                    case 2:
                        // Add grocery item
                        groceriesStorage.AddItem(
                            new Groceries { Name = Console.ReadLine() });
                        break;

                    case 3:
                        // Add furniture item
                        furnitureStorage.AddItem(
                            new Furniture { Name = Console.ReadLine() });
                        break;

                    case 4:
                        // Show electronics
                        electronicsStorage.DisplayItems();
                        break;

                    case 5:
                        // Show groceries
                        groceriesStorage.DisplayItems();
                        break;

                    case 6:
                        // Show furniture
                        furnitureStorage.DisplayItems();
                        break;
                }
            }
            while (choice != 0); // Exit when 0
        }
    }
}