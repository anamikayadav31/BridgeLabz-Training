using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.generics_problems
{




	// Base product class
	abstract class Product
	{
		public string Title { get; set; }
		public double Price { get; set; }
	}

	// Product types
	class Book : Product { }
	class Clothing : Product { }

	// Generic catalog
	class Catalog<T> where T : Product
	{
		public List<T> Products = new List<T>();
	}

	// Discount service
	class DiscountService
	{
		public static void ApplyDiscount<T>(T product, double percentage) where T : Product
		{
			product.Price -= product.Price * percentage / 100;
		}
	}

	class MarketPlace

	{
		static void Main()
		{
			// Create catalogs
			Catalog<Book> books = new Catalog<Book>();
			Catalog<Clothing> clothes = new Catalog<Clothing>();

			// Input books
			Console.WriteLine("Enter number of books:");
			int bookCount = int.Parse(Console.ReadLine());
			for (int i = 0; i < bookCount; i++)
			{
				Book book = new Book();
				Console.Write("Book Title: ");
				book.Title = Console.ReadLine();
				Console.Write("Book Price: ");
				book.Price = double.Parse(Console.ReadLine());
				books.Products.Add(book);
			}

			// Input clothing
			Console.WriteLine("\nEnter number of clothing items:");
			int clothingCount = int.Parse(Console.ReadLine());
			for (int i = 0; i < clothingCount; i++)
			{
				Clothing clothing = new Clothing();
				Console.Write("Clothing Name: ");
				clothing.Title = Console.ReadLine();
				Console.Write("Clothing Price: ");
				clothing.Price = double.Parse(Console.ReadLine());
				clothes.Products.Add(clothing);
			}

			// Apply discount
			Console.Write("Enter discount percentage: ");
			double discount = double.Parse(Console.ReadLine());
			foreach (Book book in books.Products)
				DiscountService.ApplyDiscount(book, discount);
			foreach (Clothing clothing in clothes.Products)
				DiscountService.ApplyDiscount(clothing, discount);

			// Display results
			Console.WriteLine("\nBooks after discount:");
			foreach (Book book in books.Products)
				Console.WriteLine($"{book.Title} - Rs. {book.Price}");

			Console.WriteLine("\nClothing after discount:");
			foreach (Clothing clothing in clothes.Products)
				Console.WriteLine($"{clothing.Title} - Rs. {clothing.Price}");
		}
	}

}