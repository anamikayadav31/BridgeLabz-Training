using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MovieScheduleManager
{
    internal class MovieMenu

    {
        

        public  void  ShowMenu()
        {
            MovieUtility utility=new MovieUtility();
            string choice = "";

            while (choice != "4")
            {
                Console.WriteLine("Choose your choice");
                Console.WriteLine("Want Add a movie then enter 1");
                Console.WriteLine("Want Search a movie then enter 2");
                Console.WriteLine("Want Display all movies then enter 3");
                Console.WriteLine("Enter 4 if you wanted to  Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        utility.addMovie();
                        break;
                    case "2":
                        utility.searchMovie();
                        break;
                    case "3":
                        utility.displayAllMovies();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
