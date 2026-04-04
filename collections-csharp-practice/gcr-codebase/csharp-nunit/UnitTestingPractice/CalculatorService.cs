using System;

namespace UnitTestingPractice
{
    public class CalculatorService
    {
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArithmeticException("Cannot divide by zero");
            }

            return a / b;
        }
    }
}
