using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.passwordCracker
{
    internal class Program
    {       
        public static void Main(string[] args)
        {
            Console.Write("Enter the vault password: ");
            string password = Console.ReadLine();

            Console.Write("Enter password length: ");
            int length = int.Parse(Console.ReadLine());

            Vault vault = new Vault(password);
            PasswordCracker cracker = new PasswordCracker(vault);

            cracker.StartCracking(length);

            ComplexityVisualizer.Show();
        }
    }

}

