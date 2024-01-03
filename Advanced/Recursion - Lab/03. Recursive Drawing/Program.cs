using System;
using System.Linq;
namespace _03._Recursive_Drawing
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            DraeFigure(n);
        }

        public static void DraeFigure(int n)
        {
            if(n ==0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            DraeFigure(n - 1);

            Console.WriteLine(new string('#', n));
        }


        //static void Main(string[] args)
        //{
        //    int n = int.Parse(Console.ReadLine());

        //    DrawTop(n);
        //    DrawBottom(n, 1);
        //}

        //static public void DrawTop(int n)
        //{
        //    if (n == 1)
        //    {
        //        Console.WriteLine("*");
        //    }
        //    else
        //    {
        //        Console.WriteLine(new string('*', n));
        //        DrawTop(n - 1);
        //    }
        //}

        //public static void DrawBottom(int n, int count)
        //{
        //    if (count == n)
        //    {
        //        Console.WriteLine(new string('#', n));
        //    }
        //    else
        //    {
        //        Console.WriteLine(new string('#', count));
        //        DrawBottom(n, count+1);
        //    }
        //}
    }
}