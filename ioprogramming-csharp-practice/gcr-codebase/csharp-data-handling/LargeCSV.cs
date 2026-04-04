using System;
using System.IO;

class LargeCSV
{
    static void Main()
    {
        int count = 0;

        using StreamReader sr = new StreamReader("large.csv");

        while (!sr.EndOfStream)
        {
            // Read 100 lines at a time
            for (int i = 0; i < 100 && !sr.EndOfStream; i++)
            {
                sr.ReadLine();
                count++;
            }

            Console.WriteLine("Records processed: " + count);
        }
    }
}
