using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.inheritance
{
    internal class AnimalHierarchy
    {


        // Fields to store animal details
        public string animalName;
        public int animalAge;

        // Constructor to initialize values
        public AnimalHierarchy(string animalName, int animalAge)
        {
            this.animalName = animalName;
            this.animalAge = animalAge;
        }

        // Virtual method (will be overridden by child classes)
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    // Child class Dog
    class Dog : AnimalHierarchy
    {
        public Dog(string animalName, int animalAge)
            : base(animalName, animalAge) { }

        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    // Child class Cat
    class Cat : AnimalHierarchy
    {
        public Cat(string animalName, int animalAge)
            : base(animalName, animalAge) { }

        public override void MakeSound()
        {
            Console.WriteLine("Cat meows");
        }
    }

    // Child class Bird
    class Bird : AnimalHierarchy
    {
        public Bird(string animalName, int animalAge)
            : base(animalName, animalAge) { }

        public override void MakeSound()
        {
            Console.WriteLine("Bird chirps");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Ask user to choose animal type
            Console.WriteLine("Choose Animal Type (Dog / Cat / Bird):");
            string animalType = Console.ReadLine();

            // Get animal name
            Console.WriteLine("Enter Animal Name:");
            string inputName = Console.ReadLine();

            // Get animal age
            Console.WriteLine("Enter Animal Age:");
            int inputAge = int.Parse(Console.ReadLine());

            // Parent class reference
            AnimalHierarchy selectedAnimal;

            // Create object based on user choice
            if (animalType.Equals("Dog", StringComparison.OrdinalIgnoreCase))
            {
                selectedAnimal = new Dog(inputName, inputAge);
            }
            else if (animalType.Equals("Cat", StringComparison.OrdinalIgnoreCase))
            {
                selectedAnimal = new Cat(inputName, inputAge);
            }
            else if (animalType.Equals("Bird", StringComparison.OrdinalIgnoreCase))
            {
                selectedAnimal = new Bird(inputName, inputAge);
            }
            else
            {
                Console.WriteLine("Invalid animal type");
                return;
            }

            // Display animal details (Polymorphism)
            Console.WriteLine("\nAnimal Details:");
            Console.WriteLine("Name: " + selectedAnimal.animalName);
            Console.WriteLine("Age: " + selectedAnimal.animalAge);
            selectedAnimal.MakeSound();
        }
    }
}