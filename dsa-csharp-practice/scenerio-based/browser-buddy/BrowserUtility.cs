using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.browserBuddy
{

    // Handles browser history
    class BrowserUtility : IBrowserHistory
    {
        private HistoryNode current; // Points to current page

        // Visit a new website
        public void Visit()
        {
            Console.Write("\nPlease enter the website URL: ");
            string url = Console.ReadLine();

            HistoryNode node = new HistoryNode(url);

            if (current != null)
            {
                current.Next = null;   // Remove forward history
                node.Prev = current;   // Link to previous page
                current.Next = node;   // Link to next page
            }

            current = node;
            Console.WriteLine(" You are now visiting: " + url);
        }

        // Go to previous page
        public void Back()
        {
            if (current != null && current.Prev != null)
            {
                current = current.Prev;
                Console.WriteLine(" Moved back to: " + current.Url);
            }
            else
            {
                Console.WriteLine(" You are already on the first page.");
            }
        }

        // Go to next page
        public void Forward()
        {
            if (current != null && current.Next != null)
            {
                current = current.Next;
                Console.WriteLine(" Moved forward to: " + current.Url);
            }
            else
            {
                Console.WriteLine(" No forward page available.");
            }
        }
    }

}

