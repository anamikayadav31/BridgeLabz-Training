using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.browserbuddy
{
    class PageNode
    {
        public string Url;
        public PageNode Prev;
        public PageNode Next;

        public PageNode(string url)
        {
            Url = url;
            Prev = null;
            Next = null;
        }
    }

    internal class TabHistory : IBrowse
    {

        private PageNode current;

        // Visit new page
        public void Visit()
        {
            Console.WriteLine("Enter URL");
            string url=Console.ReadLine();
            PageNode newPage = new PageNode(url);

            if (current != null)
            {
                current.Next = null; // clear forward history
                newPage.Prev = current;
                current.Next = newPage;
            }

            current = newPage;
            Console.WriteLine("Visited: " + url);
        }

        // Back navigation
        public void Back()
        {
            if (current?.Prev != null)
            {
                current = current.Prev;
                Console.WriteLine("Back to: " + current.Url);
            }
            else
            {
                Console.WriteLine("No previous page");
            }
        }

        // Forward navigation
        public void Forward()
        {
            if (current?.Next != null)
            {
                current = current.Next;
                Console.WriteLine("Forward to: " + current.Url);
            }
            else
            {
                Console.WriteLine("No next page");
            }
        }


    }
}
