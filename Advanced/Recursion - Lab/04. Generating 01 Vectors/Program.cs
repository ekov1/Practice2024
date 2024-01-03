using System;
using System.Linq;
namespace _04._Generating_01_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Vector(arr,0);

        }

        public static void Vector(int[]arr, int index)
        {
            if(index == arr.Length)
            {
                Console.WriteLine(string.Concat(arr));
                return;
            }
            for (int i = 0; i <= 1; i++)
            {
                arr[index] = i;
                Vector(arr,index+1);
            }
        }
    }
}