namespace _04._Array_Rotation
{
    internal class Program
    {
       public static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                int first = arr[0];

                for (int j = 0; j < arr.Length-1; j++)
                {
                    arr[j] = arr[j + 1];
                }

                arr[arr.Length-1]=first;
            }

            Console.WriteLine(string.Join(' ', arr));


        }

    }
}