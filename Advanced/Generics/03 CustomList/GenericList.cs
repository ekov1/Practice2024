using System.Linq.Expressions;

namespace _03_CustomList
{
    public class GenericList<T>
    {
        private T[] internalArray;
        private int index = 0;

        public GenericList()
        {
            this.internalArray = new T[10];
        }

        public void Add(T element)
        {
            internalArray[index++] = element;
        }

        public T Get(int index)
        {
            return internalArray[index];
        }
    }

    public class GenericListObject
    {
        private object[] internalArray;
        private int index = 0;

        public GenericListObject()
        {
            this.internalArray = new object[10];
        }

        public void Add(object element)
        {
            internalArray[index++] = element;
        }

        public object Get(int index)
        {
            return internalArray[index];
        }
    }
}
