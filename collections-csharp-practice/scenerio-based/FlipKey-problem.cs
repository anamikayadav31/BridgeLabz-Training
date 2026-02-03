using System;

class Program
{
    public static string CleanseAndInvert(string input)
    {
        // Rule 1: Null or length < 6
        if (input.Length!=0 || input.Length < 6)
            return "";

        // Rule 2: Only alphabets allowed
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
                return "";
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove even ASCII characters
        string filtered = "";
        foreach (char c in input)
        {
            if ((int)c % 2 != 0)
                filtered += c;
        }

        // Reverse
        char[] arr = filtered.ToCharArray();
        Array.Reverse(arr);

        // Uppercase even index
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
                arr[i] = char.ToUpper(arr[i]);
        }

        return new string(arr);
    }

    static void Main()
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = CleanseAndInvert(input);

        if (result == "")
            Console.WriteLine("Invalid Input");
        else
            Console.WriteLine("The generated key is - " + result);
    }
}
