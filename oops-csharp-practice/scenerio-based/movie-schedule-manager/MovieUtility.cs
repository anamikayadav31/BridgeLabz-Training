using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MovieScheduleManager
{
    internal class MovieUtility : IMovie

    {


        private string[] title;
        private string[] showTime;
        private int moviecount=0;
        public void addMovie()

        {
            Console.WriteLine("Enter number of movies you want to " +
                "add:");
            int numberMovies = int.Parse(Console.ReadLine());
            title = new string[numberMovies];
            showTime = new string[numberMovies];
            for (int i = 0; i < numberMovies; i++)
            {
                Console.Write($"Enter movie name {i + 1}: ");
                title[i] = Console.ReadLine();
                Console.WriteLine($"Enter show time{i + 1}:");
                showTime[i]= Console.ReadLine();
                moviecount++;


            }
        }


        public void searchMovie()
        {
            Console.Write("Search movie name: ");
            string search = Console.ReadLine();
            for (int i = 0; i < moviecount; i++)
            {
                if (title[i].Equals(search))
                {
                    Console.WriteLine($"MovieName:{title[i]},ShowTime:{showTime[i]}");
                    return;
                }
            }

            Console.WriteLine("Invalid movie");
                


            
        }
        public void displayAllMovies()
        {
            if (moviecount == 0)
            {
                Console.WriteLine("No movies Available");
                return;
            }
            Console.WriteLine("List of movies:");
            for (int i = 0; i < moviecount; i++)
            {
                Console.WriteLine($"{i + 1}.{title[i]}-{showTime[i]}");

            }
        }
    }
}