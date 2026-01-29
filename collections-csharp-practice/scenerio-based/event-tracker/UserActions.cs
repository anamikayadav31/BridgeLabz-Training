namespace EventTrackerApp
{
    public class UserActions
    {
        [AuditTrail("UserLogin", "User logged into system")] // Log login action
        public void Login()
        {
            Console.WriteLine("Login successful"); // Show login message
        }

        [AuditTrail("FileUpload", "User uploaded a file")] // Log file upload
        public void UploadFile()
        {
            Console.WriteLine("File uploaded"); // Show upload message
        }

        [AuditTrail("DeleteFile", "User deleted a file")] // Log file deletion
        public void DeleteFile()
        {
            Console.WriteLine("File deleted"); // Show delete message
        }
    }
}
