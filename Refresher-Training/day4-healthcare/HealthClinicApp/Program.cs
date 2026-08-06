using HealthClinicApp.Menu;

namespace HealthClinicApp
{
    // =====================================================
    // Program Class
    // This is the starting point of the application.
    // The Main() method is the first method that runs.
    // =====================================================
    public class Program
    {
        // Main method - Entry point of the application
        public static void Main(string[] args)
        {
            // Create object of MainMenu class
            MainMenu menu = new MainMenu();

            // Display the main menu
            menu.ShowMenu();
        }
    }
}