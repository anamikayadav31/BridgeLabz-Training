using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class FileProcessorMSTest
    {
        private FileProcessor processor = null!;
        private string testFile = "test_mstest.txt";

        [TestInitialize]
        public void Setup()
        {
            processor = new FileProcessor();

            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        [TestMethod]
        public void WriteAndRead_File_Content_ShouldMatch()
        {
            string content = "Hello MSTest";

            processor.WriteToFile(testFile, content);
            string result = processor.ReadFromFile(testFile);

            Assert.AreEqual(content, result);
        }

        [TestMethod]
        public void WriteToFile_FileShouldExist()
        {
            processor.WriteToFile(testFile, "Test");

            Assert.IsTrue(File.Exists(testFile));
        }

        [TestMethod]
        public void ReadFromFile_FileNotExist_ThrowsException()
        {
            Assert.ThrowsException<FileNotFoundException>(() =>
                processor.ReadFromFile("non_existing.txt")
            );
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }
    }
}
