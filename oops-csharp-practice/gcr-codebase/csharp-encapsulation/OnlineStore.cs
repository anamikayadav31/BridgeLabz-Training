using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{


    interface ITaxableItem
    {
        double ComputeTax();
        string GetTaxDescription();
    }

    // ABSTRACT BASE class for products
    abstract class StoreProduct
    {
        private int id;
        private string productName;
        private double unitPrice;

        // Encapsulated properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        // Abstract discount method
        public abstract double ComputeDiscount();

        // Final price (polymorphic)
        public double CalculateFinalPrice()
        {
            double taxAmount = 0;

            if (this is ITaxableItem taxable)
            {
                taxAmount = taxable.ComputeTax();
            }

            return UnitPrice + taxAmount - ComputeDiscount();
        }

        // Display method
        public void ShowProductDetails()
        {
            Console.WriteLine("\nProduct ID   : " + Id);
            Console.WriteLine("Product Name : " + ProductName);
            Console.WriteLine("Unit Price   : " + UnitPrice);
            Console.WriteLine("Final Price  : " + CalculateFinalPrice());
        }
    }

    // ELECTRONIC product (taxable)
    class ElectronicProduct : StoreProduct, ITaxableItem
    {
        public override double ComputeDiscount()
        {
            return UnitPrice * 0.10; // 10% discount
        }

        public double ComputeTax()
        {
            return UnitPrice * 0.18; // 18% tax
        }

        public string GetTaxDescription()
        {
            return "18% GST on Electronics";
        }
    }

    // APPAREL product (taxable)
    class ApparelProduct : StoreProduct, ITaxableItem
    {
        public override double ComputeDiscount()
        {
            return UnitPrice * 0.20; // 20% discount
        }

        public double ComputeTax()
        {
            return UnitPrice * 0.05; // 5% tax
        }

        public string GetTaxDescription()
        {
            return "5% GST on Apparel";
        }
    }

    // FOOD product (non-taxable)
    class FoodProduct : StoreProduct
    {
        public override double ComputeDiscount()
        {
            return UnitPrice * 0.05; // 5% discount
        }
    }

    // MAIN class for execution
    internal class OnlineStore
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter total number of products: ");
            int totalProducts = int.Parse(Console.ReadLine());

            StoreProduct[] productList = new StoreProduct[totalProducts];

            for (int idx = 0; idx < totalProducts; idx++)
            {
                Console.WriteLine("\nSelect product type for item #" + (idx + 1));
                Console.WriteLine("1. Electronic");
                Console.WriteLine("2. Apparel");
                Console.WriteLine("3. Food");
                Console.Write("Enter choice (1-3): ");
                int productType = int.Parse(Console.ReadLine());

                StoreProduct product;

                if (productType == 1)
                    product = new ElectronicProduct();
                else if (productType == 2)
                    product = new ApparelProduct();
                else
                    product = new FoodProduct();

                Console.Write("Enter Product ID: ");
                product.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                product.ProductName = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                product.UnitPrice = double.Parse(Console.ReadLine());

                productList[idx] = product;
            }

            // POLYMORPHISM: Display products
            Console.WriteLine("\n--- ALL PRODUCTS DETAILS ---");
            foreach (StoreProduct prod in productList)
            {
                prod.ShowProductDetails();

                if (prod is ITaxableItem taxableItem)
                {
                    Console.WriteLine("Tax Info      : " + taxableItem.GetTaxDescription());
                }
                else
                {
                    Console.WriteLine("Tax Info      : No tax applicable");
                }
            }

            Console.WriteLine("\nPress Enter to finish...");
            Console.ReadLine();
        }
    }
}

