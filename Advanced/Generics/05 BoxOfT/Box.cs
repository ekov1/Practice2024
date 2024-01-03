namespace _05_BoxOfT
{
    public class Box<T>
    {
        private Stack<T> _stack;

        public Box()
        {
            _stack = new Stack<T>();
        }

        public void Add(T element)
        {
            _stack.Append(element);
        }

        public T Remove(T element)
        {
            return _stack.Pop();
        }

        public int Count()
        {
            return _stack.Count;
        }
    }
}
