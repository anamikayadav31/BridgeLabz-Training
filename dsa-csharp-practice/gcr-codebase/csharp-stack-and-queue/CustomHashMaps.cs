/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
        // Node to store key-value pair
        internal class HashNode
        {
            public int Key;
            public string Value;

            public HashNode(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        internal class CustomHashMap
        {
            private int size = 10;
            private LinkedList<HashNode>[] buckets;

            // Constructor
            public CustomHashMap()
            {
                buckets = new LinkedList<HashNode>[size];
            }

            // Hash function
            private int GetIndex(int key)
            {
                return key % size;
            }

            // Insert or update value
            public void Put(int key, string value)
            {
                int index = GetIndex(key);

                if (buckets[index] == null)
                {
                    buckets[index] = new LinkedList<HashNode>();
                }

                // Check if key already exists
                foreach (HashNode node in buckets[index])
                {
                    if (node.Key == key)
                    {
                        node.Value = value;
                        return;
                    }
                }

                // Add new node
                buckets[index].AddLast(new HashNode(key, value));
            }

            // Get value by key
            public string Get(int key)
            {
                int index = GetIndex(key);

                if (buckets[index] != null)
                {
                    foreach (HashNode node in buckets[index])
                    {
                        if (node.Key == key)
                        {
                            return node.Value;
                        }
                    }
                }

                return null;
            }

            // Remove key-value pair
            public void Remove(int key)
            {
                int index = GetIndex(key);

                if (buckets[index] == null)
                {
                    return;
                }

                foreach (HashNode node in buckets[index])
                {
                    if (node.Key == key)
                    {
                        buckets[index].Remove(node);
                        return;
                    }
                }
            }
        }

        internal class CustomHashMaps
        {
            public static void Main(string[] args)
            {
                CustomHashMap map = new CustomHashMap();

                map.Put(1, "Apple");
                map.Put(2, "Banana");
                map.Put(12, "Mango");   // Collision handled

                Console.WriteLine("Key 1: " + map.Get(1));
                Console.WriteLine("Key 2: " + map.Get(2));
                Console.WriteLine("Key 12: " + map.Get(12));

                map.Remove(2);

                Console.WriteLine("After removing key 2:");
                Console.WriteLine("Key 2: " + map.Get(2));
            }
        }
    }*/


