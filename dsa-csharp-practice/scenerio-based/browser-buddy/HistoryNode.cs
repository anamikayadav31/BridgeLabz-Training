using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.browserBuddy
{
    // Represents a single webpage in history
    class HistoryNode
    {
        public string Url;          // Website address
        public HistoryNode Prev;    // Previous page
        public HistoryNode Next;    // Next page

        public HistoryNode(string url)
        {
            Url = url;
            Prev = null;
            Next = null;
        }
    }
}

