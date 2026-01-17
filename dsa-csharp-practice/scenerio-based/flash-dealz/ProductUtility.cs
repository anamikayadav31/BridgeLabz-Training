using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.FlashDealz
{
    internal class ProductUtility : IDeal
    {
        private string[] productNames;  //store product names
        private int[] discount;          //store discounts on products
        private int numberofProducts;    //store number of products

        public ProductUtility()
        {
            Console.WriteLine("Enter the number of products:");
            numberofProducts = int.Parse(Console.ReadLine());
            productNames = new string[numberofProducts];
            discount = new int[numberofProducts];
        }
        //method to add products names and discount
        public void AddProductDetails()
        {
            for (int i = 0; i < numberofProducts; i++)
            {
                Console.WriteLine($"Enter the names of product{i + 1}");
                string names = Console.ReadLine();
                productNames[i] = names;
                Console.WriteLine($"Enter the discount {i + 1}");
                int dis = int.Parse(Console.ReadLine());
                discount[i] = dis;

            }

        }
        //method to sort products based on discount;
        public void QuickSort()
        {
            QuickSortHelper(0, numberofProducts - 1);
            Console.WriteLine("Sort successfully");
        }

        // Recursive QuickSort helper
        private void QuickSortHelper(int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high);
                QuickSortHelper(low, pivotIndex - 1);
                QuickSortHelper(pivotIndex + 1, high);
            }
        }

        // Partition method
        private int Partition(int low, int high)
        {
            int pivot = discount[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (discount[j] < pivot)
                {
                    i++;

                    // Swap discounts
                    int tempDis = discount[i];
                    discount[i] = discount[j];
                    discount[j] = tempDis;

                    // Swap product names to keep alignment
                    string tempName = productNames[i];
                    productNames[i] = productNames[j];
                    productNames[j] = tempName;
                }
            }

            // Place pivot in correct position
            int temp = discount[i + 1];
            discount[i + 1] = discount[high];
            discount[high] = temp;

            string tempProd = productNames[i + 1];
            productNames[i + 1] = productNames[high];
            productNames[high] = tempProd;

            return i + 1;
        }

        // Display sorted products
        public void DisplayProducts()
        {
            Console.WriteLine("\nProducts after sorting by discount:");
            for (int i = 0; i < numberofProducts; i++)
            {
                Console.WriteLine($"{productNames[i]} - Discount: {discount[i]}%");
            }
        }

    }
}