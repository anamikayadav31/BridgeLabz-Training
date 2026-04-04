using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.atmDispenser

{
    internal class AtmDispenserMain
    {
        public static void Main(string[] args)
        {
            AtmDispenser dispenser = new AtmDispenser();
            Fallback fallback = new Fallback();

            Console.Write("Enter amount to withdraw: ");
            int amount = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose Scenario");
            Console.WriteLine("1. 500 available");
            Console.WriteLine("2. 500 removed");
            Console.WriteLine("3. Exact change not possible");
            int choice = int.Parse(Console.ReadLine());

            int[] notes;

            if (choice == 1)
            {
                notes = new int[] { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            }
            else if (choice == 2)
            {
                notes = new int[] { 200, 100, 50, 20, 10, 5, 2, 1 };
            }
            else
            {
                notes = new int[] { 100, 50, 20 };
            }

            NoteHandler handler = new NoteHandler(notes);

            int[] result = dispenser.Dispense(amount, handler.Notes);

            if (result == null)
            {
                fallback.ShowFallback(amount);
            }
            else
            {
                Console.WriteLine("Cash Dispensed:");
                for (int i = 0; i < handler.Notes.Length; i++)
                {
                    if (result[i] > 0)
                    {
                        Console.WriteLine(handler.Notes[i] + " x " + result[i]);
                    }
                }
            }
        }
    }

}




