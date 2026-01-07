using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{



    // Interface for reservable items
    interface IBookable
    {
        void Reserve(string borrower);
        bool IsAvailable();
    }

    // Abstract base class for all library items
    abstract class Item
    {
        // Encapsulated fields
        private int id;
        private string name;
        private string creator;

        // Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }

        // Abstract method for loan duration
        public abstract int LoanDurationDays();

        // Concrete method to display details
        public void ShowDetails()
        {
            Console.WriteLine("Item ID       : " + Id);
            Console.WriteLine("Name          : " + Name);
            Console.WriteLine("Creator       : " + Creator);
            Console.WriteLine("Loan Duration : " + LoanDurationDays() + " days");
        }
    }

    // Book class
    class BookItem : Item, IBookable
    {
        private string borrower;
        private bool available = true;

        public override int LoanDurationDays()
        {
            return 14;
        }

        public void Reserve(string borrowerName)
        {
            borrower = borrowerName;
            available = false;
        }

        public bool IsAvailable()
        {
            return available;
        }
    }

    // Magazine class
    class MagazineItem : Item, IBookable
    {
        private string borrower;
        private bool available = true;

        public override int LoanDurationDays()
        {
            return 7;
        }

        public void Reserve(string borrowerName)
        {
            borrower = borrowerName;
            available = false;
        }

        public bool IsAvailable()
        {
            return available;
        }
    }

    // DVD class
    class DVDItem : Item, IBookable
    {
        private string borrower;
        private bool available = true;

        public override int LoanDurationDays()
        {
            return 3;
        }

        public void Reserve(string borrowerName)
        {
            borrower = borrowerName;
            available = false;
        }

        public bool IsAvailable()
        {
            return available;
        }
    }

    // Main program class
    internal class DigitalLibrarySystem
    {
        static void Main(string[] args)
        {
            Console.Write("How many items do you want to add to the library? ");
            int totalItems = int.Parse(Console.ReadLine());

            Item[] libraryItems = new Item[totalItems];

            for (int i = 0; i < totalItems; i++)
            {
                Console.WriteLine("\nSelect item type (1-Book, 2-Magazine, 3-DVD): ");
                int type = int.Parse(Console.ReadLine());

                Item item;

                if (type == 1)
                    item = new BookItem();
                else if (type == 2)
                    item = new MagazineItem();
                else
                    item = new DVDItem();

                Console.Write("Enter item ID: ");
                item.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter item name: ");
                item.Name = Console.ReadLine();

                Console.Write("Enter creator/author: ");
                item.Creator = Console.ReadLine();

                libraryItems[i] = item;
            }

            Console.WriteLine("\n--- Library Items ---\n");

            foreach (var item in libraryItems)
            {
                item.ShowDetails();

                if (item is IBookable bookable)
                {
                    Console.WriteLine("Available: " + bookable.IsAvailable());

                    Console.Write("Enter borrower name to reserve this item: ");
                    string borrowerName = Console.ReadLine();

                    bookable.Reserve(borrowerName);
                    Console.WriteLine("Item has been reserved successfully!");
                }

                Console.WriteLine();
            }
        }
    }
}