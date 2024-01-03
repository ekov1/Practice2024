namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int currentElement = arr[0];
            int count = 0;
            int bestElement = arr[0];
            int bestCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == currentElement)
                {
                    count++;
                }
                else
                {
                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestElement = currentElement;
                    }

                    currentElement = arr[i];
                    count = 1;
                }
            }
            if (count > bestCount)
            {
                bestCount = count;
                bestElement = currentElement;
            }
            var result = "";
            for (int i = 0; i < bestCount; i++)
            {
                result += bestElement + " ";
            }
            Console.WriteLine(result.TrimEnd());
        }
    }
}