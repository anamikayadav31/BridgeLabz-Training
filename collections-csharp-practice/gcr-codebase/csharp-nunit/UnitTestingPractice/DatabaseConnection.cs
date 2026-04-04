namespace UnitTestingPractice
{
    public class DatabaseConnection
    {
        public bool IsConnected { get; private set; }

        // Simulate opening DB connection
        public void Connect()
        {
            IsConnected = true;
        }

        // Simulate closing DB connection
        public void Disconnect()
        {
            IsConnected = false;
        }
    }
}
