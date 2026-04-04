using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MovieScheduleManager
{
    internal class MovieMain

    {
    static void Main()
    {

        MovieMenu menu = new MovieMenu();   
        Console.WriteLine("Welcome to Movie Schedule Manager");
        menu.ShowMenu();
    }
    }
}
