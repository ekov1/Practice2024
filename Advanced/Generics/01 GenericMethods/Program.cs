namespace _01_GenericMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print("string input");
            Print(7);

            ObjectPrint("string input");
            ObjectPrint(7);
        }

        public static T Print<T>(T input)
        {
            Console.WriteLine(typeof(T));
            Console.WriteLine(input);

            return input;
        }

        public static object ObjectPrint(object input)
        {
            Console.WriteLine(input.GetType());
            Console.WriteLine(input);

            return input;
        }
    }
}