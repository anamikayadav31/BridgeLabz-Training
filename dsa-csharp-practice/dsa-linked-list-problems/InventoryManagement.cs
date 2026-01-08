using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{


    // Node class
    class ItemNode
    {
        public int ItemId;
        public string ItemName;
        public int Quantity;
        public double Price;
        public ItemNode Next;

        // Constructor
        public ItemNode(int id, string name, int qty, double price)
        {
            ItemId = id;
            ItemName = name;
            Quantity = qty;
            Price = price;
            Next = null;
        }
    }

    // Singly Linked List class
    class InventoryList
    {
        private ItemNode head;

        // Add item at beginning
        public void AddAtBeginning(int id, string name, int qty, double price)
        {
            ItemNode node = new ItemNode(id, name, qty, price);
            node.Next = head;
            head = node;
            Console.WriteLine("Item added at beginning.");
        }

        // Add item at end
        public void AddAtEnd(int id, string name, int qty, double price)
        {
            ItemNode node = new ItemNode(id, name, qty, price);

            if (head == null)
            {
                head = node;
                return;
            }

            ItemNode temp = head;
            while (temp.Next != null)
                temp = temp.Next;

            temp.Next = node;
            Console.WriteLine("Item added at end.");
        }

        // Add item at specific position
        public void AddAtPosition(int id, string name, int qty, double price, int pos)
        {
            if (pos <= 1)
            {
                AddAtBeginning(id, name, qty, price);
                return;
            }

            ItemNode temp = head;
            for (int i = 1; i < pos - 1 && temp != null; i++)
                temp = temp.Next;

            ItemNode node = new ItemNode(id, name, qty, price);
            node.Next = temp.Next;
            temp.Next = node;

            Console.WriteLine("Item added at position " + pos);
        }

        // Remove item by ID
        public void RemoveById(int id)
        {
            if (head == null)
            {
                Console.WriteLine("Inventory empty.");
                return;
            }

            if (head.ItemId == id)
            {
                head = head.Next;
                Console.WriteLine("Item removed.");
                return;
            }

            ItemNode temp = head;
            while (temp.Next != null)
            {
                if (temp.Next.ItemId == id)
                {
                    temp.Next = temp.Next.Next;
                    Console.WriteLine("Item removed.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Item not found.");
        }

        // Update quantity by ID
        public void UpdateQuantity(int id, int newQty)
        {
            ItemNode temp = head;
            while (temp != null)
            {
                if (temp.ItemId == id)
                {
                    temp.Quantity = newQty;
                    Console.WriteLine("Quantity updated.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Item not found.");
        }

        // Search by ID or Name
        public void Search(string key)
        {
            ItemNode temp = head;
            bool found = false;

            while (temp != null)
            {
                if (temp.ItemId.ToString() == key ||
                    temp.ItemName.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    DisplayItem(temp);
                    found = true;
                }
                temp = temp.Next;
            }

            if (!found)
                Console.WriteLine("Item not found.");
        }

        // Calculate total inventory value
        public void TotalValue()
        {
            double total = 0;
            ItemNode temp = head;

            while (temp != null)
            {
                total += temp.Price * temp.Quantity;
                temp = temp.Next;
            }

            Console.WriteLine("Total Inventory Value: " + total);
        }

        // Sort inventory
        public void Sort(int choice, bool ascending)
        {
            for (ItemNode i = head; i != null; i = i.Next)
            {
                for (ItemNode j = i.Next; j != null; j = j.Next)
                {
                    bool condition = false;

                    if (choice == 1) // Sort by name
                        condition = ascending ? i.ItemName.CompareTo(j.ItemName) > 0
                                              : i.ItemName.CompareTo(j.ItemName) < 0;
                    else // Sort by price
                        condition = ascending ? i.Price > j.Price : i.Price < j.Price;

                    if (condition)
                    {
                        Swap(i, j);
                    }
                }
            }
            Console.WriteLine("Inventory sorted.");
        }

        // Swap node data
        private void Swap(ItemNode a, ItemNode b)
        {
            (a.ItemId, b.ItemId) = (b.ItemId, a.ItemId);
            (a.ItemName, b.ItemName) = (b.ItemName, a.ItemName);
            (a.Quantity, b.Quantity) = (b.Quantity, a.Quantity);
            (a.Price, b.Price) = (b.Price, a.Price);
        }

        // Display all items
        public void DisplayAll()
        {
            ItemNode temp = head;
            if (temp == null)
            {
                Console.WriteLine("Inventory empty.");
                return;
            }

            while (temp != null)
            {
                DisplayItem(temp);
                temp = temp.Next;
            }
        }

        // Display single item
        private void DisplayItem(ItemNode i)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("ID       : " + i.ItemId);
            Console.WriteLine("Name     : " + i.ItemName);
            Console.WriteLine("Quantity : " + i.Quantity);
            Console.WriteLine("Price    : " + i.Price);
        }
    }

    // MAIN CLASS
    class InventoryManagement
    {
        static void Main()
        {
            InventoryList list = new InventoryList();
            int choice;

            do
            {
                Console.WriteLine("\n--- Inventory Management ---");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Update Quantity");
                Console.WriteLine("4. Search Item");
                Console.WriteLine("5. Display Inventory");
                Console.WriteLine("6. Total Inventory Value");
                Console.WriteLine("7. Sort Inventory");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Quantity: ");
                        int qty = int.Parse(Console.ReadLine());
                        Console.Write("Price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.Write("Position (1-Begin, 2-End, else index): ");
                        int pos = int.Parse(Console.ReadLine());

                        if (pos == 1)
                            list.AddAtBeginning(id, name, qty, price);
                        else if (pos == 2)
                            list.AddAtEnd(id, name, qty, price);
                        else
                            list.AddAtPosition(id, name, qty, price, pos);
                        break;

                    case 2:
                        Console.Write("Enter Item ID: ");
                        list.RemoveById(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        Console.Write("Item ID: ");
                        int uid = int.Parse(Console.ReadLine());
                        Console.Write("New Quantity: ");
                        int nq = int.Parse(Console.ReadLine());
                        list.UpdateQuantity(uid, nq);
                        break;

                    case 4:
                        Console.Write("Enter Item ID or Name: ");
                        list.Search(Console.ReadLine());
                        break;

                    case 5:
                        list.DisplayAll();
                        break;

                    case 6:
                        list.TotalValue();
                        break;

                    case 7:
                        Console.Write("Sort by (1-Name, 2-Price): ");
                        int sc = int.Parse(Console.ReadLine());
                        Console.Write("Order (1-Asc, 2-Desc): ");
                        int so = int.Parse(Console.ReadLine());
                        list.Sort(sc, so == 1);
                        break;
                }

            } while (choice != 0);
        }
    }
}

