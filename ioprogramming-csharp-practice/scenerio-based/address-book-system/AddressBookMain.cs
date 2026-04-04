using System;

namespace AddressBookSystem
{
    internal class AddressBookMain
    {
        // Entry point of the program
        public static async Task Main(string[] args)
        {
            try
            {
                // Welcome message shown at start
                Console.WriteLine("WELCOME TO ADDRESS BOOK SYSTEM ---> ");

                // Create menu object
                AddressBookMenu menu = new AddressBookMenu();

                // Start the menu (async because it uses async methods)
                await menu.ShowMenu();
            }
            catch (Exception ex) // catches unexpected crash
            {
                // Display any system-level errors
                Console.WriteLine("System Error: " + ex.Message);
            }
        }
    }
}
