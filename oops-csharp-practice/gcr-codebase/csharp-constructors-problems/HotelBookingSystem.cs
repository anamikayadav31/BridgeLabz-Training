using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class HotelBookingSystem
    {
        static void Main(string[] args)
        {
            // Using default constructor
            HotelBooking defaultBooking = new HotelBooking();
            Console.WriteLine("Default Booking:");
            Console.WriteLine("Guest Name: " + defaultBooking.GuestName);
            Console.WriteLine("Room Type: " + defaultBooking.RoomType);
            Console.WriteLine("Nights: " + defaultBooking.Nights);
            Console.WriteLine();

            // Taking user input for a new booking
            Console.WriteLine("Enter details for a new booking:");
            Console.Write("Guest Name: ");
            string guestName = Console.ReadLine();
            Console.Write("Room Type: ");
            string roomType = Console.ReadLine();
            Console.Write("Nights: ");
            int nights = Convert.ToInt32(Console.ReadLine());

            // Using parameterized constructor
            HotelBooking userBooking = new HotelBooking(guestName, roomType, nights);

            Console.WriteLine("\nUser Booking:");
            Console.WriteLine("Guest Name: " + userBooking.GuestName);
            Console.WriteLine("Room Type: " + userBooking.RoomType);
            Console.WriteLine("Nights: " + userBooking.Nights);
            Console.WriteLine();

            // Using copy constructor
            HotelBooking copiedBooking = new HotelBooking(userBooking);
            Console.WriteLine("Copied Booking:");
            Console.WriteLine("Guest Name: " + copiedBooking.GuestName);
            Console.WriteLine("Room Type: " + copiedBooking.RoomType);
            Console.WriteLine("Nights: " + copiedBooking.Nights);

            Console.ReadLine(); // Keep console open
        }
    }



    class HotelBooking
    {
        public string GuestName;
        public string RoomType;
        public int Nights;

        // Default constructor
        public HotelBooking()
        {
            GuestName = "Guest";
            RoomType = "Standard";
            Nights = 1;
        }

        // Parameterized constructor
        public HotelBooking(string guestName, string roomType, int nights)
        {
            GuestName = guestName;
            RoomType = roomType;
            Nights = nights;
        }

        // Copy constructor
        public HotelBooking(HotelBooking other)
        {
            GuestName = other.GuestName;
            RoomType = other.RoomType;
            Nights = other.Nights;
        }
    }

}