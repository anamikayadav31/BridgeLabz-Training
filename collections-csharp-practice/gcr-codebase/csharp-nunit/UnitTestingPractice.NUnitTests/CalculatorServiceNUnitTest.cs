using NUnit.Framework;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class CalculatorServiceNUnitTest
    {
        private CalculatorService calculator = null!;

        [SetUp]
        public void Setup()
        {
            calculator = new CalculatorService();
        }

        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            Assert.Throws<ArithmeticException>(() =>
                calculator.Divide(10, 0)
            );
        }

        [Test]
        public void Divide_ValidNumbers_ReturnsResult()
        {
            int result = calculator.Divide(10, 2);

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
