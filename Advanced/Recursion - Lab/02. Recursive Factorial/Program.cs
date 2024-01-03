using System;
using System.Linq;
namespace _02._Recursive_Factorial
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        public static int Factorial(int x)
        {
            if (x == 1)
            {
                return x;
            }

            return x * Factorial(x - 1);
        }
    }
}