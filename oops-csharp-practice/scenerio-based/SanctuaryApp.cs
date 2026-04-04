using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{

    // Interface for flying birds
    interface IFlyableBird
    {
        void Fly();
    }

    // Interface for swimming birds
    interface ISwimmableBird
    {
        void Swim();
    }

    // Base class for birds
    class BirdBase
    {
        public string BirdName;
        public string BirdType;

        public BirdBase(string birdName, string birdType)
        {
            BirdName = birdName;
            BirdType = birdType;
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Bird Name: {BirdName}, Type: {BirdType}");
        }
    }

    // Eagle class
    class EagleBird : BirdBase, IFlyableBird
    {
        public EagleBird(string birdName) : base(birdName, "Eagle") { }
        public void Fly() => Console.WriteLine($"{BirdName} the Eagle is soaring high.");
    }

    // Sparrow class
    class SparrowBird : BirdBase, IFlyableBird
    {
        public SparrowBird(string birdName) : base(birdName, "Sparrow") { }
        public void Fly() => Console.WriteLine($"{BirdName} the Sparrow is flying.");
    }

    // Duck class
    class DuckBird : BirdBase, ISwimmableBird
    {
        public DuckBird(string birdName) : base(birdName, "Duck") { }
        public void Swim() => Console.WriteLine($"{BirdName} the Duck is swimming.");
    }

    // Penguin class
    class PenguinBird : BirdBase, ISwimmableBird
    {
        public PenguinBird(string birdName) : base(birdName, "Penguin") { }
        public void Swim() => Console.WriteLine($"{BirdName} the Penguin is swimming fast.");
    }

    // Seagull class
    class SeagullBird : BirdBase, IFlyableBird, ISwimmableBird
    {
        public SeagullBird(string birdName) : base(birdName, "Seagull") { }
        public void Fly() => Console.WriteLine($"{BirdName} the Seagull is flying.");
        public void Swim() => Console.WriteLine($"{BirdName} the Seagull is swimming.");
    }

    // Main program
    class SanctuaryApp
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of birds to add: ");
            int birdCount = int.Parse(Console.ReadLine());

            BirdBase[] birdCollection = new BirdBase[birdCount];

            for (int i = 0; i < birdCount; i++)
            {
                Console.WriteLine($"\nEnter details for bird #{i + 1}:");

                Console.Write("Enter bird name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Select bird type:");
                Console.WriteLine("1. Eagle (Fly)");
                Console.WriteLine("2. Sparrow (Fly)");
                Console.WriteLine("3. Duck (Swim)");
                Console.WriteLine("4. Penguin (Swim)");
                Console.WriteLine("5. Seagull (Fly & Swim)");
                Console.Write("Choice (1-5): ");
                int typeChoice = int.Parse(Console.ReadLine());

                switch (typeChoice)
                {
                    case 1: birdCollection[i] = new EagleBird(name); break;
                    case 2: birdCollection[i] = new SparrowBird(name); break;
                    case 3: birdCollection[i] = new DuckBird(name); break;
                    case 4: birdCollection[i] = new PenguinBird(name); break;
                    case 5: birdCollection[i] = new SeagullBird(name); break;
                    default:
                        Console.WriteLine("Invalid choice. Defaulting to Sparrow.");
                        birdCollection[i] = new SparrowBird(name); break;
                }
            }

            Console.WriteLine("\n--- Bird Sanctuary Report ---");

            // Iterate and call interface methods
            foreach (BirdBase bird in birdCollection)
            {
                bird.ShowDetails();

                if (bird is IFlyableBird flyingBird)
                    flyingBird.Fly();

                if (bird is ISwimmableBird swimmingBird)
                    swimmingBird.Swim();

                Console.WriteLine();
            }

            Console.WriteLine("End of report.");
            Console.ReadLine();
        }
    }
}