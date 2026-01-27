using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace BridgeLabzTraining.Collections.reflections
{



    class Sample
    {
        public int number;
        private string name;
        public Sample() { }

        public void Show() { }
        private void Display() { }
    }

    internal class ClassInformation
    {
        public static void Main(string[] args)
        {
            // Ask user for class name
            Console.Write("Enter class name: ");
            string className = Console.ReadLine();

            // Get type information
            Type type = Type.GetType(className);

            if (type == null)
            {
                Console.WriteLine("Class not found!");
                return;
            }

            // Display methods
            Console.WriteLine("\nMethods:");
            foreach (MethodInfo method in type.GetMethods(
                     BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(method.Name);
            }

            // Display fields
            Console.WriteLine("\nFields:");
            foreach (FieldInfo field in type.GetFields(
                     BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(field.Name);
            }

            // Display constructors
            Console.WriteLine("\nConstructors:");
            foreach (ConstructorInfo constructor in type.GetConstructors())
            {
                Console.WriteLine(constructor);
            }
        }
    }
}