using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class CopyAFile
    {
   

        static void Main()
        {
            Console.Write("Enter source file path: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Enter destination file path: ");
            string destPath = Console.ReadLine();

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist.");
                return;
            }

            byte[] buffer = new byte[4096]; // 4 KB buffer
            Stopwatch sw = new Stopwatch();

            try
            {
                // -------- Unbuffered FileStream --------
                sw.Start();
                using (FileStream fsRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (FileStream fsWrite = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    int bytesRead;
                    while ((bytesRead = fsRead.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsWrite.Write(buffer, 0, bytesRead);
                    }
                }
                sw.Stop();
                Console.WriteLine("Unbuffered time: " + sw.ElapsedMilliseconds + " ms");

                // -------- BufferedStream --------
                sw.Restart();
                using (FileStream fsRead = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (FileStream fsWrite = new FileStream(destPath + "_buffered", FileMode.Create, FileAccess.Write))
                using (BufferedStream bsRead = new BufferedStream(fsRead))
                using (BufferedStream bsWrite = new BufferedStream(fsWrite))
                {
                    int bytesRead;
                    while ((bytesRead = bsRead.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bsWrite.Write(buffer, 0, bytesRead);
                    }
                }
                sw.Stop();
                Console.WriteLine("Buffered time: " + sw.ElapsedMilliseconds + " ms");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
        }
    }

}
