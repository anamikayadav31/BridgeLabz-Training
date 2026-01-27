using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class PasswordValidatorMSTest
    {
        private PasswordValidator validator = null!;

        [TestInitialize]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [TestMethod]
        public void ValidPassword_ReturnsTrue()
        {
            // Arrange
            string password = "Password1";

            // Act
            bool result = validator.IsValid(password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordTooShort_ReturnsFalse()
        {
            Assert.IsFalse(validator.IsValid("Pass1"));
        }

        [TestMethod]
        public void PasswordWithoutUppercase_ReturnsFalse()
        {
            Assert.IsFalse(validator.IsValid("password1"));
        }

        [TestMethod]
        public void PasswordWithoutDigit_ReturnsFalse()
        {
            Assert.IsFalse(validator.IsValid("Password"));
        }
    }
}
