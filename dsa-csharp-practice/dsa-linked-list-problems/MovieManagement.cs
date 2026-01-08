using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{

    // Node class for movie
    class MovieNode
    {
        public string Title, Director;
        public int Year;
        public double Rating;
        public MovieNode Prev, Next;

        // Constructor
        public MovieNode(string title, string director, int year, double rating)
        {
            Title = title;
            Director = director;
            Year = year;
            Rating = rating;
            Prev = Next = null;
        }
    }

    // Doubly Linked List class
    class MovieList
    {
        private MovieNode head, tail;

        // Add movie at beginning
        public void AddAtBeginning(string title, string director, int year, double rating)
        {
            MovieNode node = new MovieNode(title, director, year, rating);

            if (head == null)
                head = tail = node;
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }
            Console.WriteLine("Movie added at beginning.");
        }

        // Add movie at end
        public void AddAtEnd(string title, string director, int year, double rating)
        {
            MovieNode node = new MovieNode(title, director, year, rating);

            if (tail == null)
                head = tail = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }
            Console.WriteLine("Movie added at end.");
        }

        // Add movie at specific position
        public void AddAtPosition(string title, string director, int year, double rating, int pos)
        {
            if (pos <= 1)
            {
                AddAtBeginning(title, director, year, rating);
                return;
            }

            MovieNode temp = head;
            for (int i = 1; i < pos - 1 && temp != null; i++)
                temp = temp.Next;

            if (temp == null || temp.Next == null)
                AddAtEnd(title, director, year, rating);
            else
            {
                MovieNode node = new MovieNode(title, director, year, rating);
                node.Next = temp.Next;
                node.Prev = temp;
                temp.Next.Prev = node;
                temp.Next = node;
                Console.WriteLine("Movie added at position " + pos);
            }
        }

        // Remove movie by title
        public void RemoveByTitle(string title)
        {
            MovieNode temp = head;

            while (temp != null)
            {
                if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    if (temp == head) head = temp.Next;
                    if (temp == tail) tail = temp.Prev;
                    if (temp.Prev != null) temp.Prev.Next = temp.Next;
                    if (temp.Next != null) temp.Next.Prev = temp.Prev;

                    Console.WriteLine("Movie removed.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Movie not found.");
        }

        // Search movie by director
        public void SearchByDirector(string director)
        {
            MovieNode temp = head;
            bool found = false;

            while (temp != null)
            {
                if (temp.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
                {
                    DisplayMovie(temp);
                    found = true;
                }
                temp = temp.Next;
            }

            if (!found)
                Console.WriteLine("No movie found.");
        }

        // Search movie by rating
        public void SearchByRating(double rating)
        {
            MovieNode temp = head;
            bool found = false;

            while (temp != null)
            {
                if (temp.Rating == rating)
                {
                    DisplayMovie(temp);
                    found = true;
                }
                temp = temp.Next;
            }

            if (!found)
                Console.WriteLine("No movie found.");
        }

        // Update movie rating
        public void UpdateRating(string title, double newRating)
        {
            MovieNode temp = head;

            while (temp != null)
            {
                if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    temp.Rating = newRating;
                    Console.WriteLine("Rating updated.");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Movie not found.");
        }

        // Display movies forward
        public void DisplayForward()
        {
            MovieNode temp = head;
            if (temp == null)
            {
                Console.WriteLine("No movies available.");
                return;
            }

            while (temp != null)
            {
                DisplayMovie(temp);
                temp = temp.Next;
            }
        }

        // Display movies reverse
        public void DisplayReverse()
        {
            MovieNode temp = tail;
            if (temp == null)
            {
                Console.WriteLine("No movies available.");
                return;
            }

            while (temp != null)
            {
                DisplayMovie(temp);
                temp = temp.Prev;
            }
        }

        // Display single movie
        private void DisplayMovie(MovieNode m)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Title   : " + m.Title);
            Console.WriteLine("Director: " + m.Director);
            Console.WriteLine("Year    : " + m.Year);
            Console.WriteLine("Rating  : " + m.Rating);
        }
    }

    // MAIN CLASS
    class MovieManagement
    {
        static void Main()
        {
            MovieList list = new MovieList();
            int choice;

            do
            {
                Console.WriteLine("\n--- Movie Management System ---");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Remove Movie");
                Console.WriteLine("3. Search by Director");
                Console.WriteLine("4. Search by Rating");
                Console.WriteLine("5. Display Forward");
                Console.WriteLine("6. Display Reverse");
                Console.WriteLine("7. Update Rating");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Director: ");
                        string director = Console.ReadLine();
                        Console.Write("Year: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Rating: ");
                        double rating = double.Parse(Console.ReadLine());
                        Console.Write("Position (1-Begin, 2-End, else index): ");
                        int pos = int.Parse(Console.ReadLine());

                        if (pos == 1)
                            list.AddAtBeginning(title, director, year, rating);
                        else if (pos == 2)
                            list.AddAtEnd(title, director, year, rating);
                        else
                            list.AddAtPosition(title, director, year, rating, pos);
                        break;

                    case 2:
                        Console.Write("Enter title: ");
                        list.RemoveByTitle(Console.ReadLine());
                        break;

                    case 3:
                        Console.Write("Enter director: ");
                        list.SearchByDirector(Console.ReadLine());
                        break;

                    case 4:
                        Console.Write("Enter rating: ");
                        list.SearchByRating(double.Parse(Console.ReadLine()));
                        break;

                    case 5:
                        list.DisplayForward();
                        break;

                    case 6:
                        list.DisplayReverse();
                        break;

                    case 7:
                        Console.Write("Enter title: ");
                        string t = Console.ReadLine();
                        Console.Write("New rating: ");
                        double r = double.Parse(Console.ReadLine());
                        list.UpdateRating(t, r);
                        break;
                }

            } while (choice != 0);
        }
    }
}