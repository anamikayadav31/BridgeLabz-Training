using System;

namespace AddressBookSystem
{
    internal class AddressBookMain
    {
        // Main method - starting point of the program
        public static async Task Main(string[] args)
        {
            try
            {
                // Display welcome message to user
                Console.WriteLine("WELCOME TO ADDRESS BOOK SYSTEM ---> ");
                
                // Create object of AddressBookMenu
                AddressBookMenu menu = new AddressBookMenu();
                
                // Call menu method to show options (async call)
                await menu.ShowMenu();
            }
            catch (Exception ex) // Catch any unexpected errors
            {
                // Print error message if something goes wrong
                Console.WriteLine("System Error: " + ex.Message);
            }
        }
    }
}
