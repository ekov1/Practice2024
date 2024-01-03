namespace _00._Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            CustomList<int> cutomListInt = new CustomList<int>();
            CustomList<string> cutomListString = new CustomList<string>();
            StreamReader streamReader = null;
        }
    }

    class CustomList<T>
    {

    }

    interface IExample { } 

    class GenericClase<T> where T : IExample
    {

    }

    class GenericNumber<T> where T : struct
    {

    }
}