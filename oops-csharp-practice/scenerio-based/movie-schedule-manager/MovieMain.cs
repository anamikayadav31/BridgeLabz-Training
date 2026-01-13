using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MovieScheduleManager
{
    internal class MovieMain

    {

        static void Main()
        {
             
             MovieUtility utility = new MovieUtility();
             Console.WriteLine("Welcome to Movie Schedule Manager");
             MovieMenu.ShowMenu(utility);
        }
    }
}
