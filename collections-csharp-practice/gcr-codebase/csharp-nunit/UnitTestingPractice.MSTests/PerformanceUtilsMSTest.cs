using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class PerformanceUtilsMSTest
    {
        private PerformanceUtils utils = null!;

        [TestInitialize]
        public void Setup()
        {
            utils = new PerformanceUtils();
        }

        [TestMethod]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldFinishWithin2Seconds()
        {
            // Act
            int result = utils.LongRunningTask();

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
