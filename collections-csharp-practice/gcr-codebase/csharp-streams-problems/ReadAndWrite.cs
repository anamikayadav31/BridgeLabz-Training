using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class Count
    {
    

        static void Main()
        {
            Console.Write("Enter source file path: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Enter destination file path: ");
            string destPath = Console.ReadLine();

            try
            {
                // Check if source file exists
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine("Source file does not exist.");
                    return;
                }

                // Open source file for reading
                using (FileStream fsRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                // Create destination file for writing
                using (FileStream fsWrite = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024]; // 1 KB buffer
                    int bytesRead;

                    // Read and write until end of file
                    while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsWrite.Write(buffer, 0, bytesRead);
                    }
                }

                Console.WriteLine("File copied successfully.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
        }
    }

}
