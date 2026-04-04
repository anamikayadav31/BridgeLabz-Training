using NUnit.Framework;
using System.IO;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class FileProcessorNUnitTest
    {
        private FileProcessor processor = null!;
        private string testFile = "test_nunit.txt";

        // Runs BEFORE each test
        [SetUp]
        public void Setup()
        {
            processor = new FileProcessor();

            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }

        [Test]
        public void WriteAndRead_File_Content_ShouldMatch()
        {
            // Arrange
            string content = "Hello NUnit";

            // Act
            processor.WriteToFile(testFile, content);
            string result = processor.ReadFromFile(testFile);

            // Assert
            Assert.That(result, Is.EqualTo(content));
        }

        [Test]
        public void WriteToFile_FileShouldExist()
        {
            // Act
            processor.WriteToFile(testFile, "Test");

            // Assert
            Assert.That(File.Exists(testFile), Is.True);
        }

        [Test]
        public void ReadFromFile_FileNotExist_ThrowsException()
        {
            // Act + Assert
            Assert.Throws<FileNotFoundException>(() =>
                processor.ReadFromFile("non_existing.txt")
            );
        }

        // Runs AFTER each test
        [TearDown]
        public void TearDown()
        {
            if (File.Exists(testFile))
            {
                File.Delete(testFile);
            }
        }
    }
}
