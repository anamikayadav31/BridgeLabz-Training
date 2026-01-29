using System;
using System.Text;

class EncryptDecrypt
{
    static void Main()
    {
        Console.Write("Enter Salary: ");
        string salary = Console.ReadLine();

        // Encrypt
        string encrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes(salary));
        Console.WriteLine("Encrypted: " + encrypted);

        // Decrypt
        string decrypted = Encoding.UTF8.GetString(Convert.FromBase64String(encrypted));
        Console.WriteLine("Decrypted: " + decrypted);
    }
}
