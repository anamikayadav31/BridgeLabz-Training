using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{
        // Node class represents one movie
        class MovieNode
        {
            public string Title;
            public string Director;
            public int Year;
            public double Rating;
            public MovieNode Prev;
            public MovieNode Next;

            // Constructor to initialize movie details
            public MovieNode(string title, string director, int year, double rating)
            {
                Title = title;
                Director = director;
                Year = year;
                Rating = rating;
                Prev = null;
                Next = null;
            }
        }

        class MovieList
        {
            private MovieNode head;
            private MovieNode tail;

            // Add movie at the beginning
            public void AddAtBeginning()
            {
                Console.Write("Enter Movie Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Director Name: ");
                string director = Console.ReadLine();

                Console.Write("Enter Release Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter Rating: ");
                double rating = double.Parse(Console.ReadLine());

                MovieNode newNode = new MovieNode(title, director, year, rating);

                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }

                Console.WriteLine("Movie added at the beginning.\n");
            }

            // Add movie at the end
            public void AddAtEnd()
            {
                Console.Write("Enter Movie Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Director Name: ");
                string director = Console.ReadLine();

                Console.Write("Enter Release Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter Rating: ");
                double rating = double.Parse(Console.ReadLine());

                MovieNode newNode = new MovieNode(title, director, year, rating);

                if (tail == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    newNode.Prev = tail;
                    tail = newNode;
                }

                Console.WriteLine("Movie added at the end.\n");
            }

            // Add movie at a specific position
            public void AddAtPosition()
            {
                Console.Write("Enter Position: ");
                int position = int.Parse(Console.ReadLine());

                if (position <= 0)
                {
                    Console.WriteLine("Invalid position.\n");
                    return;
                }

                Console.Write("Enter Movie Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Director Name: ");
                string director = Console.ReadLine();

                Console.Write("Enter Release Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter Rating: ");
                double rating = double.Parse(Console.ReadLine());

                MovieNode newNode = new MovieNode(title, director, year, rating);

                if (position == 1)
                {
                    AddAtBeginning();
                    return;
                }

                MovieNode temp = head;
                for (int i = 1; i < position - 1 && temp != null; i++)
                {
                    temp = temp.Next;
                }

                if (temp == null)
                {
                    Console.WriteLine("Position out of range.\n");
                }
                else
                {
                    newNode.Next = temp.Next;
                    newNode.Prev = temp;

                    if (temp.Next != null)
                    {
                        temp.Next.Prev = newNode;
                    }
                    else
                    {
                        tail = newNode;
                    }

                    temp.Next = newNode;
                    Console.WriteLine("Movie added at given position.\n");
                }
            }

            // Remove movie by title
            public void RemoveByTitle()
            {
                Console.Write("Enter Movie Title to remove: ");
                string title = Console.ReadLine();

                MovieNode temp = head;

                while (temp != null)
                {
                    if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        if (temp == head)
                        {
                            head = head.Next;
                            if (head != null)
                                head.Prev = null;
                        }
                        else if (temp == tail)
                        {
                            tail = tail.Prev;
                            tail.Next = null;
                        }
                        else
                        {
                            temp.Prev.Next = temp.Next;
                            temp.Next.Prev = temp.Prev;
                        }

                        Console.WriteLine("Movie removed successfully.\n");
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Movie not found.\n");
            }

            // Search movie by director
            public void SearchByDirector()
            {
                Console.Write("Enter Director Name: ");
                string director = Console.ReadLine();

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
                    Console.WriteLine("No movies found for this director.\n");
            }

            // Search movie by rating
            public void SearchByRating()
            {
                Console.Write("Enter Rating: ");
                double rating = double.Parse(Console.ReadLine());

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
                    Console.WriteLine("No movies found with this rating.\n");
            }

            // Update rating by movie title
            public void UpdateRating()
            {
                Console.Write("Enter Movie Title: ");
                string title = Console.ReadLine();

                MovieNode temp = head;

                while (temp != null)
                {
                    if (temp.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Enter new Rating: ");
                        temp.Rating = double.Parse(Console.ReadLine());
                        Console.WriteLine("Rating updated successfully.\n");
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine("Movie not found.\n");
            }

            // Display movies forward
            public void DisplayForward()
            {
                if (head == null)
                {
                    Console.WriteLine("No movie records available.\n");
                    return;
                }

                MovieNode temp = head;
                Console.WriteLine("Movies in Forward Order:\n");

                while (temp != null)
                {
                    DisplayMovie(temp);
                    temp = temp.Next;
                }
            }

            // Display movies in reverse
            public void DisplayReverse()
            {
                if (tail == null)
                {
                    Console.WriteLine("No movie records available.\n");
                    return;
                }

                MovieNode temp = tail;
                Console.WriteLine("Movies in Reverse Order:\n");

                while (temp != null)
                {
                    DisplayMovie(temp);
                    temp = temp.Prev;
                }
            }

            // Helper method to display one movie
            private void DisplayMovie(MovieNode movie)
            {
                Console.WriteLine("Title    : " + movie.Title);
                Console.WriteLine("Director : " + movie.Director);
                Console.WriteLine("Year     : " + movie.Year);
                Console.WriteLine("Rating   : " + movie.Rating);
                Console.WriteLine();
            }
        }

        class MovieManagement
        {
            public static void Main(string[] args)
            {
                MovieList list = new MovieList();
                int choice;

                do
                {
                    Console.WriteLine(" Movie Management System ");
                    Console.WriteLine("1. Add Movie at Beginning");
                    Console.WriteLine("2. Add Movie at End");
                    Console.WriteLine("3. Add Movie at Specific Position");
                    Console.WriteLine("4. Remove Movie by Title");
                    Console.WriteLine("5. Search Movie by Director");
                    Console.WriteLine("6. Search Movie by Rating");
                    Console.WriteLine("7. Display Movies Forward");
                    Console.WriteLine("8. Display Movies Reverse");
                    Console.WriteLine("9. Update Movie Rating");
                    Console.WriteLine("10. Exit");
                    Console.Write("Enter your choice: ");

                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1: list.AddAtBeginning(); break;
                        case 2: list.AddAtEnd(); break;
                        case 3: list.AddAtPosition(); break;
                        case 4: list.RemoveByTitle(); break;
                        case 5: list.SearchByDirector(); break;
                        case 6: list.SearchByRating(); break;
                        case 7: list.DisplayForward(); break;
                        case 8: list.DisplayReverse(); break;
                        case 9: list.UpdateRating(); break;
                        case 10: Console.WriteLine("Program closed."); break;
                        default: Console.WriteLine("Invalid choice.\n"); break;
                    }

                } while (choice != 10);
            }
        }
    }

