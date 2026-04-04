using NUnit.Framework;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class StringUtilsNUnitTest
    {
        private StringUtils utils = null!;

        [SetUp]
        public void Setup()
        {
            utils = new StringUtils();
        }

        [Test]
        public void Reverse_ReturnsReversedString()
        {
            string result = utils.Reverse("hello");
            Assert.That(result, Is.EqualTo("olleh"));
        }

        [Test]
        public void IsPalindrome_ReturnsTrue_ForPalindrome()
        {
            bool result = utils.IsPalindrome("madam");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_ReturnsFalse_ForNonPalindrome()
        {
            bool result = utils.IsPalindrome("hello");
            Assert.That(result, Is.False);
        }

        [Test]
        public void ToUpperCase_ConvertsStringToUpper()
        {
            string result = utils.ToUpperCase("dotnet");
            Assert.That(result, Is.EqualTo("DOTNET"));
        }
    }
}
