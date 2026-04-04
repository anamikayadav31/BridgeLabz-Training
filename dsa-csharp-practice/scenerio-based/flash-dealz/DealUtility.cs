using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.flashDealz
{
        internal class DealUtility : IDeal
        {
            private Deal[] products;      // Stores all products
            private int productCount = 0; // Tracks added products

            // Constructor initializes array size
            public DealUtility()
            {
                Console.Write("Enter maximum number of products: ");
                int size = int.Parse(Console.ReadLine());
                products = new Deal[size];
            }

            // Add a new product
            public void AddProduct()
            {
                if (productCount == products.Length)
                {
                    Console.WriteLine(" Product limit reached.");
                    return;
                }

                Console.Write("Enter product name: ");
                string name = Console.ReadLine();

                Console.Write("Enter discount percentage: ");
                double discount = double.Parse(Console.ReadLine());

                products[productCount++] = new Deal(name, discount);
                Console.WriteLine(" Product added successfully.");
            }

            // View all products 
            public void ViewProduct()
            {
                if (productCount == 0)
                {
                    Console.WriteLine(" No products available.");
                    return;
                }

                Console.WriteLine("\n--- Product List ---");
                for (int i = 0; i < productCount; i++)
                {
                    Console.WriteLine(products[i]);
                }
            }

            // Sort products by discount using Quick Sort
            public void ShowDiscount()
            {
                if (productCount == 0)
                {
                    Console.WriteLine(" No products available.");
                    return;
                }

                QuickSort(0, productCount - 1);

                Console.WriteLine("\n Top Discounted Products");
                for (int i = 0; i < productCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].ProductName} - {products[i].Discount}% OFF");
                }
            }

            // Quick Sort algorithm
            private void QuickSort(int low, int high)
            {
                if (low < high)
                {
                    int pivotIndex = Partition(low, high);
                    QuickSort(low, pivotIndex - 1);
                    QuickSort(pivotIndex + 1, high);
                }
            }

            // Partition logic for Quick Sort (Descending order)
            private int Partition(int low, int high)
            {
                double pivot = products[high].Discount;
                int i = low - 1;

                for (int j = low; j < high; j++)
                {
                    if (products[j].Discount > pivot)
                    {
                        i++;
                        Swap(i, j);
                    }
                }

                Swap(i + 1, high);
                return i + 1;
            }

            // Swap two products
            private void Swap(int i, int j)
            {
                Deal temp = products[i];
                products[i] = products[j];
                products[j] = temp;
            }
        }
    }


