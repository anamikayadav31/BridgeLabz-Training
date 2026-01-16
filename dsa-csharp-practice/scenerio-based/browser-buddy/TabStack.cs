using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.browserbuddy
{
    internal class TabStack
    {

        private TabNode top;

        private class TabNode
        {
            public TabHistory Tab;
            public TabNode Next;

            public TabNode(TabHistory tab)
            {
                Tab = tab;
                Next = null;
            }
        }

        // Push closed tab
        public void Push(TabHistory tab)
        {
            TabNode node = new TabNode(tab);
            node.Next = top;
            top = node;
            Console.WriteLine("Tab closed and saved");
        }

        // Reopen tab
        public TabHistory Pop()
        {
            if (top == null)
            {
                Console.WriteLine("No tabs to restore");
                return null;
            }

            TabHistory tab = top.Tab;
            top = top.Next;
            Console.WriteLine("Tab restored");
            return tab;
        }
    }
}