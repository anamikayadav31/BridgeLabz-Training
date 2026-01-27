using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class StringUtilsMSTest
    {
        private StringUtils utils = null!;

        [TestInitialize]
        public void Setup()
        {
            utils = new StringUtils();
        }

        [TestMethod]
        public void Reverse_ReturnsReversedString()
        {
            // Arrange
            string input = "hello";

            // Act
            string result = utils.Reverse(input);

            // Assert
            Assert.AreEqual("olleh", result);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsTrue_ForPalindrome()
        {
            // Arrange
            string input = "madam";

            // Act
            bool result = utils.IsPalindrome(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPalindrome_ReturnsFalse_ForNonPalindrome()
        {
            // Arrange
            string input = "hello";

            // Act
            bool result = utils.IsPalindrome(input);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ToUpperCase_ConvertsStringToUpper()
        {
            // Arrange
            string input = "dotnet";

            // Act
            string result = utils.ToUpperCase(input);

            // Assert
            Assert.AreEqual("DOTNET", result);
        }
    }
}
