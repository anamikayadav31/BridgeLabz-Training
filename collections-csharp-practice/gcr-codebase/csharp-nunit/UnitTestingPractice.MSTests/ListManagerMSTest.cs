using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class ListManagerMSTest
    {
        private ListManager manager = null!;
        private List<int> list = null!;

        [TestInitialize]
        public void Setup()
        {
            manager = new ListManager();
            list = new List<int> { 1, 2, 3 };
        }

        [TestMethod]
        public void AddElement_AddsItemToList()
        {
            // Act
            manager.AddElement(list, 4);

            // Assert
            Assert.AreEqual(4, list.Count);
            Assert.IsTrue(list.Contains(4));
        }

        [TestMethod]
        public void RemoveElement_RemovesItemFromList()
        {
            // Act
            manager.RemoveElement(list, 2);

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.IsFalse(list.Contains(2));
        }

        [TestMethod]
        public void GetSize_ReturnsCorrectSize()
        {
            // Act
            int size = manager.GetSize(list);

            // Assert
            Assert.AreEqual(3, size);
        }
    }
}
