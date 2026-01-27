using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class MathUtilsMSTest
    {
        private MathUtils math = null!;

        [TestInitialize]
        public void Setup()
        {
            math = new MathUtils();
        }

        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(6, true)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        public void IsEven_ShouldReturnCorrectResult(int number, bool expected)
        {
            // Act
            bool result = math.IsEven(number);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
