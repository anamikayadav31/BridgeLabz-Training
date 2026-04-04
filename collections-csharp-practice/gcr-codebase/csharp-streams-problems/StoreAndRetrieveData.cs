using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.streams
{
    internal class StoreAndRetrieveData
    {
   

        static void Main()
        {
            string filePath = "student.dat";

            try
            {
                // ---- Write data ----
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    Console.Write("Enter Roll Number: ");
                    int roll = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter GPA: ");
                    double gpa = double.Parse(Console.ReadLine());

                    writer.Write(roll);
                    writer.Write(name);
                    writer.Write(gpa);
                }

                Console.WriteLine("\nData saved successfully.\n");

                // ---- Read data ----
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    int roll = reader.ReadInt32();
                    string name = reader.ReadString();
                    double gpa = reader.ReadDouble();

                    Console.WriteLine("Student Details:");
                    Console.WriteLine($"Roll: {roll}, Name: {name}, GPA: {gpa}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}
