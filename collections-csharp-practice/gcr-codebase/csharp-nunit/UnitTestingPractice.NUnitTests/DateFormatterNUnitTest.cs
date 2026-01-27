using NUnit.Framework;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class DateFormatterNUnitTest
    {
        private DateFormatter formatter = null!;

        [SetUp]
        public void Setup()
        {
            formatter = new DateFormatter();
        }

        [Test]
        public void FormatDate_ValidDate_ReturnsFormattedDate()
        {
            string result = formatter.FormatDate("2026-01-27");
            Assert.That(result, Is.EqualTo("27-01-2026"));
        }

        [Test]
        public void FormatDate_InvalidDate_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() =>
                formatter.FormatDate("27-01-2026")
            );
        }

        [Test]
        public void FormatDate_InvalidString_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() =>
                formatter.FormatDate("invalid-date")
            );
        }
    }
}
