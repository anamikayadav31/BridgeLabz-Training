using NUnit.Framework;
using NUnit.Framework.Legacy;
using UnitTestingPractice;
namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class CalculatorNUnitTest
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void Add_Test()
        {
            ClassicAssert.AreEqual(10, calc.Add(5, 5));
        }

        [Test]
        public void Subtract_Test()
        {
            ClassicAssert.AreEqual(5, calc.Subtract(10, 5));
        }

        [Test]
        public void Multiply_Test()
        {
            ClassicAssert.AreEqual(20, calc.Multiply(4, 5));
        }

        [Test]
        public void Divide_Test()
        {
            ClassicAssert.AreEqual(2, calc.Divide(10, 5));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }
    }
}
