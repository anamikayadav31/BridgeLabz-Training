using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.browserBuddy
{

// Handles user interaction and menu
    internal class BrowserMenu
    {
        private BrowserUtility currentTab = new BrowserUtility();
        private ClosedTabStack closedTabs = new ClosedTabStack();

        // Show menu repeatedly
        public void ShowMenu()
        {
            Console.WriteLine("  Welcome to BrowserBuddy");
            Console.WriteLine("  Tab History Manager");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Visit a new website");
                Console.WriteLine("2. Go Back to previous page");
                Console.WriteLine("3. Go Forward to next page");
                Console.WriteLine("4. Close current tab");
                Console.WriteLine("5. Restore last closed tab");
                Console.WriteLine("6. Exit Browser");

                Console.Write("\nEnter your choice (1-6): ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        currentTab.Visit();
                        break;

                    case 2:
                        currentTab.Back();
                        break;

                    case 3:
                        currentTab.Forward();
                        break;

                    case 4:
                        closedTabs.CloseTab(currentTab);
                        currentTab = new BrowserUtility();
                        Console.WriteLine(" A new empty tab is opened.");
                        break;

                    case 5:
                        BrowserUtility restored = closedTabs.RestoreTab();
                        if (restored != null)
                            currentTab = restored;
                        break;

                    case 6:
                        Console.WriteLine("\nThank you for using BrowserBuddy ");
                        return;
                }
            }
        }
    }

}

