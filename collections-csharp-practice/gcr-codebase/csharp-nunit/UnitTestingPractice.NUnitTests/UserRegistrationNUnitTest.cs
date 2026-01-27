using NUnit.Framework;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class UserRegistrationNUnitTest
    {
        private UserRegistration registration = null!;

        [SetUp]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [Test]
        public void RegisterUser_ValidInput_ReturnsTrue()
        {
            bool result = registration.RegisterUser(
                "lavan",
                "lavan@example.com",
                "Password123"
            );

            Assert.That(result, Is.True);
        }

        [Test]
        public void RegisterUser_InvalidUsername_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("", "test@mail.com", "Password123")
            );
        }

        [Test]
        public void RegisterUser_InvalidEmail_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("user", "invalidEmail", "Password123")
            );
        }

        [Test]
        public void RegisterUser_InvalidPassword_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                registration.RegisterUser("user", "test@mail.com", "123")
            );
        }
    }
}
