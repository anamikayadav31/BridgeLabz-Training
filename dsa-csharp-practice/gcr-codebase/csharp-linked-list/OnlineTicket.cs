using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{    
        // ticket node
        class TicketNode
        {
            public int TicketId;
            public string CustomerName;
            public string MovieName;
            public int SeatNumber;
            public string BookingTime;
            public TicketNode Next;

            public TicketNode(int id, string customer, string movie, int seat, string time)
            {
                TicketId = id;
                CustomerName = customer;
                MovieName = movie;
                SeatNumber = seat;
                BookingTime = time;
                Next = null;
            }
        }

        // ticket system logic
        class TicketSystem
        {
            private TicketNode tail;

            // add ticket at end
            public void AddTicket(int id, string customer, string movie, int seat, string time)
            {
                TicketNode newTicket = new TicketNode(id, customer, movie, seat, time);

                if (tail == null)
                {
                    tail = newTicket;
                    tail.Next = tail;
                    return;
                }

                newTicket.Next = tail.Next;
                tail.Next = newTicket;
                tail = newTicket;
            }

            // remove ticket by id
            public void RemoveTicket(int id)
            {
                if (tail == null)
                {
                    Console.WriteLine("No tickets available");
                    return;
                }

                TicketNode curr = tail.Next;
                TicketNode prev = tail;

                do
                {
                    if (curr.TicketId.Equals(id))
                    {
                        if (curr.Equals(tail) && curr.Equals(tail.Next))
                        {
                            tail = null;
                        }
                        else
                        {
                            prev.Next = curr.Next;
                            if (curr.Equals(tail))
                                tail = prev;
                        }

                        Console.WriteLine("Ticket removed");
                        return;
                    }

                    prev = curr;
                    curr = curr.Next;

                } while (!curr.Equals(tail.Next));

                Console.WriteLine("Ticket not found");
            }

            // display tickets
            public void DisplayTickets()
            {
                if (tail == null)
                {
                    Console.WriteLine("No tickets to display");
                    return;
                }

                TicketNode temp = tail.Next;

                Console.WriteLine("Booked Tickets:");
                do
                {
                    Console.WriteLine(
                        "ID: " + temp.TicketId +
                        ", Customer: " + temp.CustomerName +
                        ", Movie: " + temp.MovieName +
                        ", Seat: " + temp.SeatNumber +
                        ", Time: " + temp.BookingTime);

                    temp = temp.Next;

                } while (!temp.Equals(tail.Next));
            }

            // search ticket
            public void SearchTicket(string key)
            {
                if (tail == null)
                {
                    Console.WriteLine("No tickets available");
                    return;
                }

                TicketNode temp = tail.Next;

                do
                {
                    if (temp.CustomerName.Equals(key, StringComparison.OrdinalIgnoreCase) ||
                        temp.MovieName.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(
                            "ID: " + temp.TicketId +
                            ", Customer: " + temp.CustomerName +
                            ", Movie: " + temp.MovieName +
                            ", Seat: " + temp.SeatNumber +
                            ", Time: " + temp.BookingTime);
                        return;
                    }

                    temp = temp.Next;

                } while (!temp.Equals(tail.Next));

                Console.WriteLine("Ticket not found");
            }

            // count tickets
            public void CountTickets()
            {
                if (tail == null)
                {
                    Console.WriteLine("Total tickets: 0");
                    return;
                }

                int count = 0;
                TicketNode temp = tail.Next;

                do
                {
                    count++;
                    temp = temp.Next;

                } while (!temp.Equals(tail.Next));

                Console.WriteLine("Total tickets: " + count);
            }
        }

        // MAIN CLASS
        class OnlineTicket
        {
            public static void Main(string[] args)
            {
                TicketSystem system = new TicketSystem();
                int choice;

                do
                {
                    Console.WriteLine("\nOnline Ticket Menu");
                    Console.WriteLine("1 Add Ticket");
                    Console.WriteLine("2 Remove Ticket");
                    Console.WriteLine("3 Display Tickets");
                    Console.WriteLine("4 Search Ticket");
                    Console.WriteLine("5 Count Tickets");
                    Console.WriteLine("0 Exit");
                    Console.Write("Choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Ticket ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Customer Name: ");
                            string customer = Console.ReadLine();

                            Console.Write("Movie Name: ");
                            string movie = Console.ReadLine();

                            Console.Write("Seat Number: ");
                            int seat = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Booking Time: ");
                            string time = Console.ReadLine();

                            system.AddTicket(id, customer, movie, seat, time);
                            break;

                        case 2:
                            Console.Write("Ticket ID: ");
                            system.RemoveTicket(Convert.ToInt32(Console.ReadLine()));
                            break;

                        case 3:
                            system.DisplayTickets();
                            break;

                        case 4:
                            Console.Write("Customer or Movie Name: ");
                            system.SearchTicket(Console.ReadLine());
                            break;

                        case 5:
                            system.CountTickets();
                            break;
                    }

                } while (!choice.Equals(0));
            }
        }
    }


