using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.atmDispenser
{


    //  Contains ATM cash dispensing logic
    internal class AtmDispenser
    {
        // Method to dispense cash
        public int[] Dispense(int amount, int[] notes)
        {
            int[] noteCount = new int[notes.Length];
            int remaining = amount;

            // start from highest note
            for (int i = 0; i < notes.Length; i++)
            {
                if (remaining >= notes[i])
                {
                    noteCount[i] = remaining / notes[i];
                    remaining = remaining % notes[i];
                }
            }

            // If exact change not possible
            if (remaining != 0)
            {
                return null;
            }

            return noteCount;
        }
    }

}