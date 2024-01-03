namespace _05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                bool addToREsult = true;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] >= arr[i])
                    {
                        addToREsult = false;
                        break;
                    }
                }

                if (addToREsult)
                {
                    result += arr[i] + " ";
                }
            }

            Console.WriteLine(result.TrimEnd());
        }
    }
}