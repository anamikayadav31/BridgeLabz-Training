using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;
namespace UnitTestingPractice.MSTests

{
    [TestClass]
    public class CalculatorMSTest
    {
        private Calculator calc = null!;

        [TestInitialize]
        public void Setup()
        {
            // Arrange (common setup)
            calc = new Calculator();
        }

        [TestMethod]
        public void Add_ReturnsCorrectSum()
        {
            // Act
            int result = calc.Add(5, 5);

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Subtract_ReturnsCorrectDifference()
        {
            // Act
            int result = calc.Subtract(10, 5);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectProduct()
        {
            // Act
            int result = calc.Multiply(4, 5);

            // Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Divide_ReturnsCorrectQuotient()
        {
            // Act
            int result = calc.Divide(10, 5);

            // Assert
            Assert.AreEqual(2, result);
        }

       [TestMethod]
public void Divide_ByZero_ThrowsException()
{
    try
    {
        calc.Divide(10, 0);
        Assert.Fail("Expected DivideByZeroException was not thrown");
    }
    catch (DivideByZeroException)
    {
        // Test passed
    }
}

    }
}
