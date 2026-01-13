using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.MovieScheduleManager
{
    internal class Movie
    {
        public string Title {  get; set; }
        public string Time{ get; set; }
        public Movie(string title,string time)
        {
            Title = title;
            Time = time;
        }
    }
}
