namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;

                // go left
                for (int j = i-1; j >= 0; j--)
                {
                    sumLeft += arr[j];
                }

                // go right
                for (int j = i+1; j < arr.Length; j++)
                {
                    sumRight += arr[j];
                }

                if ( sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    found = true;
                    break;
                }
            }

            if (!found) { Console.WriteLine("no"); }
        }
    }
}