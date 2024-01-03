using System.Security.Cryptography.X509Certificates;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            string result = string.Join(' ', arr2.Intersect(arr1));
            Console.WriteLine(result);

            //string result = "";

            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    for (int j = 0; j < arr2.Length; j++)
            //    {
            //        if (arr1[i] == arr2[j])
            //        {
            //            result += arr2[j] + " ";
            //        }
            //    }
            //}

            //Console.WriteLine(result.TrimEnd());
        }
    }
}