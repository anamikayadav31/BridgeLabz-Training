using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.bookShelf
{
    
        class HashNode
        {
            public string Key;
            public BookLinkedList Value;
            public HashNode Next;

            public HashNode(string key)
            {
                Key = key;
                Value = new BookLinkedList();
                Next = null;
            }
        }

        class CustomHashMap
        {
            private HashNode[] buckets = new HashNode[10];

            private int GetIndex(string key)
            {
                return Math.Abs(key.GetHashCode()) % buckets.Length;
            }

            public HashNode Get(string key)
            {
                int index = GetIndex(key);
                HashNode temp = buckets[index];

                while (temp != null)
                {
                    if (temp.Key == key)
                        return temp;
                    temp = temp.Next;
                }
                return null;
            }

            public HashNode Put(string key)
            {
                int index = GetIndex(key);

                HashNode node = new HashNode(key);
                node.Next = buckets[index];
                buckets[index] = node;

                return node;
            }

            public void Display()
            {
                for (int i = 0; i < buckets.Length; i++)
                {
                    HashNode temp = buckets[i];
                    while (temp != null)
                    {
                        Console.WriteLine("\nGenre: " + temp.Key);
                        temp.Value.Display();
                        temp = temp.Next;
                    }
                }
            }
        }
    }


