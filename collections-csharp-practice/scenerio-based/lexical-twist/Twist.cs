using System;
using System.Collections.Generic;   

class Twist
{
    public static void Main(string[] args)
    {
        // Ask user for first word
        Console.WriteLine("Enter the first word");
        string firstWord = Console.ReadLine();

        // Validation: check if it contains space
        if (firstWord.Contains(" "))
        {
            Console.WriteLine(firstWord + " is an invalid word");
            return; // Stop program
        }

        // Ask user for second word
        Console.WriteLine("Enter the second word");
        string secondWord = Console.ReadLine();

        // Validation for second word
        if (secondWord.Contains(" "))
        {
            Console.WriteLine(secondWord + " is an invalid word");
            return;
        }

        // Convert first word to char array and reverse it
        char[] arr = firstWord.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);  // Convert array back to string

        // Check if second word is reverse of first word 
        if (reversed.Equals(secondWord, StringComparison.OrdinalIgnoreCase))
        {
            // Convert reversed word to lowercase
            string lower = reversed.ToLower();
            string result = "";

            // Replace vowels with '@'
            foreach (char c in lower)
            {
                if ("aeiou".Contains(c))
                    result += "@";
                else
                    result += c;
            }

            // Print transformed word
            Console.WriteLine(result);
        }
        else
        {
            // Combine words and convert to uppercase
            string combined = (firstWord + secondWord).ToUpper();

            int vowelCount = 0, consonantCount = 0;

            // Count vowels and consonants
            foreach (char c in combined)
            {
                if ("AEIOU".Contains(c))
                    vowelCount++;
                else if (char.IsLetter(c))
                    consonantCount++;
            }

            // If more vowels
            if (vowelCount > consonantCount)
            {
                List<char> vowelsList = new List<char>(); // Store unique vowels

                foreach (char c in combined)
                {
                    if ("AEIOU".Contains(c) && !vowelsList.Contains(c))
                    {
                        vowelsList.Add(c);
                        if (vowelsList.Count == 2)
                            break; // Stop after 2 vowels
                    }
                }

                // Print result
                foreach (char c in vowelsList)
                    Console.Write(c);
            }
            // If more consonants
            else if (consonantCount > vowelCount)
            {
                List<char> consList = new List<char>(); // Store unique consonants

                foreach (char c in combined)
                {
                    if (!"AEIOU".Contains(c) && char.IsLetter(c) && !consList.Contains(c))
                    {
                        consList.Add(c);
                        if (consList.Count == 2)
                            break; // Stop after 2 consonants
                    }
                }

                // Print result
                foreach (char c in consList)
                    Console.Write(c);
            }
            else
            {
                // If counts are equal
                Console.WriteLine("Vowels and consonants are equal");
            }
        }
    }
}