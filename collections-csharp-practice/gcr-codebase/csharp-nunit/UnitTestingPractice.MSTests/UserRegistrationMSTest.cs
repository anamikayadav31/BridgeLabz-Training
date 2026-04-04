using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class UserRegistrationMSTest
    {
        private UserRegistration registration = null!;

        [TestInitialize]
        public void Setup()
        {
            registration = new UserRegistration();
        }

        [TestMethod]
        public void RegisterUser_ValidInput_ReturnsTrue()
        {
            // Act
            bool result = registration.RegisterUser(
                "lavan",
                "lavan@example.com",
                "Password123"
            );

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RegisterUser_InvalidUsername_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                registration.RegisterUser("", "test@mail.com", "Password123")
            );
        }

        [TestMethod]
        public void RegisterUser_InvalidEmail_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                registration.RegisterUser("user", "invalidEmail", "Password123")
            );
        }

        [TestMethod]
        public void RegisterUser_InvalidPassword_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                registration.RegisterUser("user", "test@mail.com", "123")
            );
        }
    }
}
