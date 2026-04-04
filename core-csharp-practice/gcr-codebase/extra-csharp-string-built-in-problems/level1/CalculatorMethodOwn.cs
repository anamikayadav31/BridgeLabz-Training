using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.extraStringBuiltIn.level1
{
    internal class CalculatorMethodOwn
    {
       

        public static void Main(string[] args)
        {
            // Ask user for two numbers
            Console.Write("Enter first number ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number ");
            double num2 = double.Parse(Console.ReadLine());

            // Ask user for operation
            Console.WriteLine("Choose operation: +  -  *  /");
            string op = Console.ReadLine();

            // Perform operation 
            double result;

            switch (op)
            {
                case "+":
                    result = Add(num1, num2);
                    break;
                case "-":
                    result = Subtract(num1, num2);
                    break;
                case "*":
                    result = Multiply(num1, num2);
                    break;
                case "/":
                    result = Divide(num1, num2);
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    return;
            }

            // print result
            Console.WriteLine("Result: " + result);
        }

        // create a function to add two numbers
        static double Add(double a, double b)
        {
            return a + b;
        }

        // craete a function to subtract two numbers
        static double Subtract(double a, double b)
        {
            return a - b;
        }

        // create a function to multiply two numbers
        static double Multiply(double a, double b)
        {
            return a * b;
        }

        // create a function to divide two numbers
        static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Error: Division by zero!");
                return 0;
            }
            return a / b;
        }
    }

}
