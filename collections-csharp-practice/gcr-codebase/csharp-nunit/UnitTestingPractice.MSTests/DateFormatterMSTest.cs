using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class DateFormatterMSTest
    {
        private DateFormatter formatter = null!;

        [TestInitialize]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [TestMethod]
        public void FormatDate_ValidDate_ReturnsFormattedDate()
        {
            // Arrange
            string input = "2026-01-27";

            // Act
            string result = formatter.FormatDate(input);

            // Assert
            Assert.AreEqual("27-01-2026", result);
        }

        [TestMethod]
        public void FormatDate_InvalidDate_ThrowsFormatException()
        {
            Assert.ThrowsException<FormatException>(() =>
                formatter.FormatDate("27-01-2026")
            );
        }

        [TestMethod]
        public void FormatDate_InvalidString_ThrowsFormatException()
        {
            Assert.ThrowsException<FormatException>(() =>
                formatter.FormatDate("invalid-date")
            );
        }
    }
}
