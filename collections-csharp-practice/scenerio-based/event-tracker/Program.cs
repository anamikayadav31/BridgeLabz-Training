// See https://aka.ms/new-console-template for more information

namespace EventTrackerApp;

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of UserActions
        UserActions actions = new UserActions();

        // Track and execute user actions with auditing
        EventTracker.TrackEvents(actions);
    }
}
