using System.Collections.Generic;

namespace UnitTestingPractice
{
    public class ListManager
    {
        public void AddElement(List<int> list, int element)
        {
            list.Add(element);
        }

        public void RemoveElement(List<int> list, int element)
        {
            list.Remove(element);
        }

        public int GetSize(List<int> list)
        {
            return list.Count;
        }
    }
}
