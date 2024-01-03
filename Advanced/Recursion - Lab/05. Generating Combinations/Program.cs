using System;

class Program
{
    static void rec(int[] arr, int index, int N, int num)
    {
        if (arr.Length == index)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = num; i < N + 1; i++)
            {
                arr[index] = i;
                num++;
                rec(arr, index + 1, N, num);
            }
        }
    }

    static void Main(string[] args)
    {
        int N = 5;
        int K = 2;
        int[] myArr = new int[K];

        rec(myArr, 0, N, 1);
    }
}

//namespace _05._Generating_Combinations
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
//            int n = int.Parse(Console.ReadLine());
//            int[] combination = new int[n];

//            Combinations(arr, combination,0, 0);
//        }

//        public static void Combinations(int[]arr, int[] combination,int start, int index)
//        {
//            if(index == combination.Length)
//            {
//                Console.WriteLine(string.Concat(combination));
//                return;
//            }

//            for (int i = start; i < arr.Length; i++)
//            {
//                combination[index] = arr[i];
//                Combinations(arr,combination,start+1,index+1);
//            }
//        }
//    }
//}