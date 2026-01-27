using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class CalculatorServiceMSTest
    {
        private CalculatorService calculator = null!;

        [TestInitialize]
        public void Setup()
        {
            calculator = new CalculatorService();
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            Assert.ThrowsException<ArithmeticException>(() =>
                calculator.Divide(10, 0)
            );
        }

        [TestMethod]
        public void Divide_ValidNumbers_ReturnsResult()
        {
            int result = calculator.Divide(10, 2);

            Assert.AreEqual(5, result);
        }
    }
}
