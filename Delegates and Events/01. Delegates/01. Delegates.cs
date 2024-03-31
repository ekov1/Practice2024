namespace _01._Delegates
{
    ///
    /// What is a delegate
    /// 
    /// A delegate is a type safe function pointer. That is,
    /// it holds a reference(Pointer) to a function.
    /// 
    /// The signature of the delegate must mach the signature of the function,
    /// the delegate points to, otherwise you will get a compiler error.
    /// This is the reason why delegates are called as type safe function pointers.
    /// A Delegate is similar to a class. You can create an instance of it,
    /// and when you do so, you pass in the function name as a parameter to the delagate constructor,
    /// and it is this function the delegate will point to.
    ///
    internal class Delegates
    {
        public delegate void HelloFunctionDelegate(string message);
        public static void Main()
        {
            // A delegate is a type safe function pointer
            var funcDelegate = new HelloFunctionDelegate(Hello);
            funcDelegate("Hello from delegate!");
        }

        public static void Hello(string message)
        {
            Console.WriteLine(message);
        }
    }
}