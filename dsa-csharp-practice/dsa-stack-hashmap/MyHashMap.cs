using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.stackAndHashmap
{
    internal class MyHashMap

    {
        // Each bucket will store a linked list of key-value pairs
        private LinkedList<KeyValuePair<int, int>>[] buckets;

        private int capacity; // Total number of buckets

        // Constructor
        public MyHashMap(int capacity)
        {
            this.capacity = capacity;
            buckets = new LinkedList<KeyValuePair<int, int>>[capacity];

            // Initialize each bucket
            for (int i = 0; i < capacity; i++)
            {
                buckets[i] = new LinkedList<KeyValuePair<int, int>>();
            }
        }

        // Hash function to calculate bucket index
        private int Hash(int key)
        {
            return key % capacity;
        }

        // Insert or update a key-value pair
        public void Put(int key, int value)
        {
            int index = Hash(key);

            // Check if key already exists
            foreach (var pair in buckets[index])
            {
                if (pair.Key == key)
                {
                    buckets[index].Remove(pair);
                    buckets[index].AddLast(new KeyValuePair<int, int>(key, value));
                    return;
                }
            }

            // If key not found, add new pair
            buckets[index].AddLast(new KeyValuePair<int, int>(key, value));
        }

        // Retrieve value for a key
        public int Get(int key)
        {
            int index = Hash(key);

            foreach (var pair in buckets[index])
            {
                if (pair.Key == key)
                {
                    return pair.Value;
                }
            }

            return -1; // Key not found
        }

        // Remove a key-value pair
        public void Remove(int key)
        {
            int index = Hash(key);

            foreach (var pair in buckets[index])
            {
                if (pair.Key == key)
                {
                    buckets[index].Remove(pair);
                    return;
                }
            }
        }
    }
}