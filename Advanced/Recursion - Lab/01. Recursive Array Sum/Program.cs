using System;
using System.Linq;
namespace _01._Recursive_Array_Sum
{
    public class Program
    {
        static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
            Console.WriteLine(RecusiveSum(arr,0));
        }

        private static int RecusiveSum(int[] numbers, int index)
        {
            if (index == numbers.Length - 1)
            {
                return numbers[index];
            }
            return numbers[index] + RecusiveSum(numbers, index + 1);
        }
    }
}