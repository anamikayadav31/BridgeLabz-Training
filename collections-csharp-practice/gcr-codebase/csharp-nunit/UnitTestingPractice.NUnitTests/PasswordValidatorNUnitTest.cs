using NUnit.Framework;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class PasswordValidatorNUnitTest
    {
        private PasswordValidator validator = null!;

        [SetUp]
        public void Setup()
        {
            validator = new PasswordValidator();
        }

        [Test]
        public void ValidPassword_ReturnsTrue()
        {
            Assert.That(validator.IsValid("Password1"), Is.True);
        }

        [Test]
        public void PasswordTooShort_ReturnsFalse()
        {
            Assert.That(validator.IsValid("Pass1"), Is.False);
        }

        [Test]
        public void PasswordWithoutUppercase_ReturnsFalse()
        {
            Assert.That(validator.IsValid("password1"), Is.False);
        }

        [Test]
        public void PasswordWithoutDigit_ReturnsFalse()
        {
            Assert.That(validator.IsValid("Password"), Is.False);
        }
    }
}
