using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{





    internal class ExceptionsAcrossMethods
    {
        static void Method1()
        {
            int y = 0;
            int x = 10 / y;   // ArithmeticException at RUNTIME
        }
        static void Method2()
        {
            Method1();
        }

        static void Main(string[] args)
        {
            try
            {
                Method2();
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Handled exception in Main");
            }

            Console.ReadLine();
        }
    }
}
