using NUnit.Framework;
using System.Collections.Generic;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    public class ListManagerNUnitTest
    {
        private ListManager manager = null!;
        private List<int> list = null!;

        [SetUp]
        public void Setup()
        {
            manager = new ListManager();
            list = new List<int> { 1, 2, 3 };
        }

        [Test]
        public void AddElement_AddsItemToList()
        {
            manager.AddElement(list, 4);

            Assert.That(list.Count, Is.EqualTo(4));
            Assert.That(list.Contains(4), Is.True);
        }

        [Test]
        public void RemoveElement_RemovesItemFromList()
        {
            manager.RemoveElement(list, 2);

            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list.Contains(2), Is.False);
        }

        [Test]
        public void GetSize_ReturnsCorrectSize()
        {
            int size = manager.GetSize(list);

            Assert.That(size, Is.EqualTo(3));
        }
    }
}
