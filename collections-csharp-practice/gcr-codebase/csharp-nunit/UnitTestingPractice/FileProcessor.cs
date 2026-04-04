using System.IO;

namespace UnitTestingPractice
{
    public class FileProcessor
    {
        public void WriteToFile(string filename, string content)
        {
            File.WriteAllText(filename, content);
        }

        public string ReadFromFile(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}
