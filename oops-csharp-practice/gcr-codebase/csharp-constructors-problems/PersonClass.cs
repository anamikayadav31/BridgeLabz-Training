 using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class PersonClass
    {
        static void Main(string[] args)
        {
            // Taking input for original person
            Console.WriteLine("Enter details for a person:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            // Create original person
            Person originalPerson = new Person(name, age);

            // Create copy using copy constructor
            Person copiedPerson = new Person(originalPerson);

            // Display original person
            Console.WriteLine("\nOriginal Person:");
            Console.WriteLine("Name: " + originalPerson.Name);
            Console.WriteLine("Age: " + originalPerson.Age);

            // Display copied person
            Console.WriteLine("\nCopied Person:");
            Console.WriteLine("Name: " + copiedPerson.Name);
            Console.WriteLine("Age: " + copiedPerson.Age);

            Console.ReadLine(); // Keep console open
        }
    }

    class Person
    {
        public string Name;
        public int Age;

        // Parameterized constructor
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Copy constructor
        public Person(Person other)
        {
            Name = other.Name;
            Age = other.Age;
        }
    }
}
    
 