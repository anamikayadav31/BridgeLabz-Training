/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{
        // Node class
        class ItemNode
        {
            public int ItemId;
            public string ItemName;
            public int Quantity;
            public double Price;
            public ItemNode Next;

            public ItemNode(int id, string name, int qty, double price)
            {
                ItemId = id;
                ItemName = name;
                Quantity = qty;
                Price = price;
                Next = null;
            }
        }

        // Linked list class
        class InventoryLinkedList
        {
            private ItemNode head;

            // add at beginning
            public void AddAtBeginning(int id, string name, int qty, double price)
            {
                ItemNode newNode = new ItemNode(id, name, qty, price);
                newNode.Next = head;
                head = newNode;
            }

            // add at end
            public void AddAtEnd(int id, string name, int qty, double price)
            {
                ItemNode newNode = new ItemNode(id, name, qty, price);

                if (head == null)
                {
                    head = newNode;
                    return;
                }

                ItemNode temp = head;
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newNode;
            }

            // remove by id
            public void RemoveById(int id)
            {
                if (head == null) return;

                if (head.ItemId == id)
                {
                    head = head.Next;
                    return;
                }

                ItemNode temp = head;
                while (temp.Next != null && temp.Next.ItemId != id)
                    temp = temp.Next;

                if (temp.Next != null)
                    temp.Next = temp.Next.Next;
            }

            // update quantity
            public void UpdateQuantity(int id, int newQty)
            {
                ItemNode temp = head;

                while (temp != null)
                {
                    if (temp.ItemId == id)
                    {
                        temp.Quantity = newQty;
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Item not found");
            }

            // search item
            public void Search(string key)
            {
                ItemNode temp = head;

                while (temp != null)
                {
                    if (temp.ItemId.ToString() == key ||
                        temp.ItemName.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{temp.ItemId} {temp.ItemName} Qty:{temp.Quantity} Price:{temp.Price}");
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Item not found");
            }

            // total inventory value
            public void TotalInventoryValue()
            {
                double total = 0;
                ItemNode temp = head;

                while (temp != null)
                {
                    total += temp.Quantity * temp.Price;
                    temp = temp.Next;
                }

                Console.WriteLine("Total Inventory Value = " + total);
            }

            // display items
            public void Display()
            {
                if (head == null)
                {
                    Console.WriteLine("Inventory is empty");
                    return;
                }

                ItemNode temp = head;
                while (temp != null)
                {
                    Console.WriteLine($"{temp.ItemId} {temp.ItemName} Qty:{temp.Quantity} Price:{temp.Price}");
                    temp = temp.Next;
                }
            }
        }

        // main class
       internal class InventoryManagement
        {
           public  static void Main(string[] args)
            {
                InventoryLinkedList inventory = new InventoryLinkedList();
                int choice;

                do
                {
                    Console.WriteLine("\n Inventory Menu ");
                    Console.WriteLine("1. Add Item at Beginning");
                    Console.WriteLine("2. Add Item at End");
                    Console.WriteLine("3. Remove Item by ID");
                    Console.WriteLine("4. Update Quantity");
                    Console.WriteLine("5. Search Item");
                    Console.WriteLine("6. Display Inventory");
                    Console.WriteLine("7. Total Inventory Value");
                    Console.WriteLine("0. Exit");
                    Console.Write("Enter choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ReadItemData(out int id1, out string name1, out int qty1, out double price1);
                            inventory.AddAtBeginning(id1, name1, qty1, price1);
                            break;

                        case 2:
                            ReadItemData(out int id2, out string name2, out int qty2, out double price2);
                            inventory.AddAtEnd(id2, name2, qty2, price2);
                            break;

                        case 3:
                            Console.Write("Enter Item ID to remove: ");
                            int rid = Convert.ToInt32(Console.ReadLine());
                            inventory.RemoveById(rid);
                            break;

                        case 4:
                            Console.Write("Enter Item ID: ");
                            int uid = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter new quantity: ");
                            int newQty = Convert.ToInt32(Console.ReadLine());
                            inventory.UpdateQuantity(uid, newQty);
                            break;

                        case 5:
                            Console.Write("Enter Item ID or Name: ");
                            string key = Console.ReadLine();
                            inventory.Search(key);
                            break;

                        case 6:
                            inventory.Display();
                            break;

                        case 7:
                            inventory.TotalInventoryValue();
                            break;

                        case 0:
                            Console.WriteLine("Exiting...");
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }

                } while (choice != 0);
            }

            // read item details
            static void ReadItemData(out int id, out string name, out int qty, out double price)
            {
                Console.Write("Enter Item ID: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Item Name: ");
                name = Console.ReadLine();

                Console.Write("Enter Quantity: ");
                qty = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Price: ");
                price = Convert.ToDouble(Console.ReadLine());
            }
        }
    }*/


