namespace _04_GenericDictionary
{
    internal class GenericDictionary<TKey, TValue>
    {
        private TKey[] keys; 
        private TValue[] values;

        public GenericDictionary()
        {
            keys = new TKey[10];
            values = new TValue[10];
        }

        public void AddKey (TKey elemnt)
        {
            keys[0] = elemnt;

        }

        public void AddValue (TValue elemnt)
        {
            values[0] = elemnt;
        }
    }
}
