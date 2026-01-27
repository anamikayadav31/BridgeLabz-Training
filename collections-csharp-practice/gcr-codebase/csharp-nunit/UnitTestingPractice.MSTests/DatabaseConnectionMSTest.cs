using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class DatabaseConnectionMSTest
    {
        private DatabaseConnection db = null!;

        // Runs BEFORE EACH test
        [TestInitialize]
        public void Setup()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        // Runs AFTER EACH test
        [TestCleanup]
        public void Cleanup()
        {
            db.Disconnect();
        }

        [TestMethod]
        public void Connection_ShouldBeOpen_AfterSetup()
        {
            Assert.IsTrue(db.IsConnected);
        }

        [TestMethod]
        public void Connection_ShouldBeClosed_AfterCleanup()
        {
            db.Disconnect();
            Assert.IsFalse(db.IsConnected);
        }
    }
}
