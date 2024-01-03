namespace GenericScale
{
    public class StartUp
    {
        public static void Main()
        {
            EqualityScale<int> equalityScale = new EqualityScale<int>(1, 1);
            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}