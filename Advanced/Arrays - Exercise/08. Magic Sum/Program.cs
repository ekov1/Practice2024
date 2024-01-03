namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x=>x).ToArray();

            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]>=n)
                {
                    break;
                }
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == n)
                    {
                        Console.WriteLine($"{arr[i]} {arr[j]}");
                    }
                }
            }
        }
    }
}