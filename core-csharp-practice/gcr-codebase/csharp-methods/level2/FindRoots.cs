using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level2
{
    internal class FindRoots
    {
 

            public static void Main(string[] args)
            {
                Console.WriteLine("Enter coefficient a:");
                double a = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter coefficient b:");
                double b = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter coefficient c:");
                double c = double.Parse(Console.ReadLine());

                // find roots
                double[] roots = FindRoot(a, b, c);

                // print results
                if (roots.Length == 0)
                {
                    Console.WriteLine("The equation has no real roots.");
                }
                else if (roots.Length == 1)
                {
                    Console.WriteLine("The equation has one real root: x = " + roots[0].ToString("0.00"));
                }
                else
                {
                    Console.WriteLine("The equation has two real roots: x1 = " + roots[0].ToString("0.00") +
                                      ", x2 = " + roots[1].ToString("0.00"));
                }
            }

            // create method to find roots of a quadratic equation
            public static double[] FindRoot(double a, double b, double c)
            {
                double delta = Math.Pow(b, 2) - 4 * a * c;

                if (delta < 0)
                {
                    // No real roots
                    return new double[0];
                }
                else if (delta == 0)
                {
                    // One real root
                    double root = -b / (2 * a);
                    return new double[] { root };
                }
                else
                {
                    // Two real roots
                    double sqrtDelta = Math.Sqrt(delta);
                    double root1 = (-b + sqrtDelta) / (2 * a);
                    double root2 = (-b - sqrtDelta) / (2 * a);
                    return new double[] { root1, root2 };
                }
            }
        
    }
}
