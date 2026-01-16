using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{



    // Node class
    class TicketNode
    {
        public int TicketId;
        public string CustomerName;
        public string MovieName;
        public string SeatNumber;
        public string BookingTime;
        public TicketNode Next;

        // Constructor
        public TicketNode(int id, string cname, string mname, string seat, string time)
        {
            TicketId = id;
            CustomerName = cname;
            MovieName = mname;
            SeatNumber = seat;
            BookingTime = time;
            Next = null;
        }
    }

    // Circular Linked List class
    class TicketList
    {
        private TicketNode head = null;
        private TicketNode tail = null;

        // Add ticket at end
        public void AddTicket(int id, string cname, string mname, string seat, string time)
        {
            TicketNode node = new TicketNode(id, cname, mname, seat, time);

            if (head == null)
            {
                head = tail = node;
                node.Next = head;
            }
            else
            {
                tail.Next = node;
                node.Next = head;
                tail = node;
            }
            Console.WriteLine("Ticket booked successfully.");
        }

        // Remove ticket by Ticket ID
        public void RemoveTicket(int id)
        {
            if (head == null)
            {
                Console.WriteLine("No tickets booked.");
                return;
            }

            TicketNode curr = head, prev = tail;

            do
            {
                if (curr.TicketId == id)
                {
                    if (curr == head)
                        head = head.Next;

                    prev.Next = curr.Next;

                    if (curr == tail)
                        tail = prev;

                    Console.WriteLine("Ticket cancelled.");
                    return;
                }
                prev = curr;
                curr = curr.Next;

            } while (curr != head);

            Console.WriteLine("Ticket not found.");
        }

        // Display all tickets
        public void DisplayTickets()
        {
            if (head == null)
            {
                Console.WriteLine("No tickets booked.");
                return;
            }

            TicketNode temp = head;
            do
            {
                DisplayTicket(temp);
                temp = temp.Next;
            } while (temp != head);
        }

        // Search ticket by customer or movie name
        public void Search(string key)
        {
            if (head == null)
            {
                Console.WriteLine("No tickets booked.");
                return;
            }

            TicketNode temp = head;
            bool found = false;

            do
            {
                if (temp.CustomerName.Equals(key, StringComparison.OrdinalIgnoreCase) ||
                    temp.MovieName.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    DisplayTicket(temp);
                    found = true;
                }
                temp = temp.Next;
            } while (temp != head);

            if (!found)
                Console.WriteLine("Ticket not found.");
        }

        // Count total tickets
        public void CountTickets()
        {
            if (head == null)
            {
                Console.WriteLine("Total Tickets: 0");
                return;
            }

            int count = 0;
            TicketNode temp = head;
            do
            {
                count++;
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("Total Booked Tickets: " + count);
        }

        // Display single ticket
        private void DisplayTicket(TicketNode t)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ticket ID     : " + t.TicketId);
            Console.WriteLine("Customer Name : " + t.CustomerName);
            Console.WriteLine("Movie Name    : " + t.MovieName);
            Console.WriteLine("Seat Number   : " + t.SeatNumber);
            Console.WriteLine("Booking Time  : " + t.BookingTime);
        }
    }

    // MAIN CLASS
    class OnlineTicket
    {
        static void Main()
        {
            TicketList list = new TicketList();
            int choice;

            do
            {
                Console.WriteLine("\n--- Online Ticket Reservation ---");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Cancel Ticket");
                Console.WriteLine("3. Display Tickets");
                Console.WriteLine("4. Search Ticket");
                Console.WriteLine("5. Count Tickets");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Ticket ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Customer Name: ");
                        string cname = Console.ReadLine();
                        Console.Write("Movie Name: ");
                        string mname = Console.ReadLine();
                        Console.Write("Seat Number: ");
                        string seat = Console.ReadLine();
                        Console.Write("Booking Time: ");
                        string time = Console.ReadLine();

                        list.AddTicket(id, cname, mname, seat, time);
                        break;

                    case 2:
                        Console.Write("Enter Ticket ID: ");
                        list.RemoveTicket(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        list.DisplayTickets();
                        break;

                    case 4:
                        Console.Write("Enter Customer or Movie Name: ");
                        list.Search(Console.ReadLine());
                        break;

                    case 5:
                        list.CountTickets();
                        break;
                }

            } while (choice != 0);
        }
    }

}