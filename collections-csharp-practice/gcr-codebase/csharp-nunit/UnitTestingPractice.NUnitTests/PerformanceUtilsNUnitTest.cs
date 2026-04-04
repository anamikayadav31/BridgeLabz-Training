using NUnit.Framework;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class PerformanceUtilsNUnitTest
    {
        private PerformanceUtils utils = null!;

        [SetUp]
        public void Setup()
        {
            utils = new PerformanceUtils();
        }

        [Test]
        [Timeout(2000)] // 2 seconds
        public void LongRunningTask_ShouldFinishWithin2Seconds()
        {
            int result = utils.LongRunningTask();
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
