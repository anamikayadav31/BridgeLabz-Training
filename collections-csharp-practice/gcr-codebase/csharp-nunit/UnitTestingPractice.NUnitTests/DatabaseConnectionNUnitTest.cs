using NUnit.Framework;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class DatabaseConnectionNUnitTest
    {
        private DatabaseConnection db;

        [SetUp]
        public void Setup()
        {
            db = new DatabaseConnection();
            db.Connect();
        }

        [TearDown]
        public void TearDown()
        {
            db.Disconnect();
        }

        [Test]
        public void Connection_ShouldBeOpen_AfterSetup()
        {
            Assert.That(db.IsConnected, Is.True);
        }

        [Test]
        public void Connection_ShouldBeClosed_AfterDisconnect()
        {
            db.Disconnect();
            Assert.That(db.IsConnected, Is.False);
        }
    }
}
