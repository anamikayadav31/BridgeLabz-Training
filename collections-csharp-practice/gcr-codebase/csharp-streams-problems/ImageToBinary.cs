using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class ImageToBinary
    {
   

        static void Main()
        {
            Console.Write("Enter source image path: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Enter destination image path: ");
            string destPath = Console.ReadLine();

            try
            {
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine("Source image does not exist.");
                    return;
                }

                byte[] imageBytes;

                // Read image into byte array
                using (FileStream fs = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    imageBytes = ms.ToArray();
                }

                // Write byte array back to image file
                using (FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(imageBytes, 0, imageBytes.Length);
                }

                // Verify by comparing file sizes
                long originalSize = new FileInfo(sourcePath).Length;
                long newSize = new FileInfo(destPath).Length;

                Console.WriteLine(originalSize == newSize
                    ? "Image copied successfully. Files are identical."
                    : "Files are not identical.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
        }
    }

}
