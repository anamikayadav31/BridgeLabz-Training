using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.browserBuddy
{
    // Stores recently closed tabs using stack (LIFO)
   internal class ClosedTabStack
    {
        // Node for stack
        private class StackNode
        {
            public BrowserUtility Data; // Closed tab
            public StackNode Next;      // Next stack item

            public StackNode(BrowserUtility tab)
            {
                Data = tab;
                Next = null;
            }
        }

        private StackNode top; // Top of stack

        // Close the current tab
        public void CloseTab(BrowserUtility tab)
        {
            StackNode node = new StackNode(tab);
            node.Next = top;
            top = node;
            Console.WriteLine(" Tab closed successfully.");
        }

        // Restore the last closed tab
        public BrowserUtility RestoreTab()
        {
            if (top == null)
            {
                Console.WriteLine(" No closed tabs available to restore.");
                return null;
            }

            BrowserUtility tab = top.Data;
            top = top.Next;
            Console.WriteLine(" Last closed tab has been restored.");
            return tab;
        }
    }

}

