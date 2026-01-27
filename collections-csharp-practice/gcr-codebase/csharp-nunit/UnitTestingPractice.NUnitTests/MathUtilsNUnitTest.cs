using NUnit.Framework;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class MathUtilsNUnitTest
    {
        private MathUtils math = null!;

        [SetUp]
        public void Setup()
        {
            math = new MathUtils();
        }

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_ShouldReturnCorrectResult(int number, bool expected)
        {
            bool result = math.IsEven(number);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
