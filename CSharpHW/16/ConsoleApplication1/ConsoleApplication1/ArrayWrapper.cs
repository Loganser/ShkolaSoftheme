using System.Linq;

namespace ConsoleApplication1
{
    class ArrayWrapper<T>
    {
        public T[] array {get; private set;}
        public int last { get; private set; }
        double coef = 1.5;
        public ArrayWrapper(int n)
        {
            array = new T[n];
            last = 0;
        }
        public ArrayWrapper()
        {
            array = new T[10];
            last = 0;
        }

        public void DeleteAndShift(int i)
        {
            for (int j = i; j < last-1; ++j)
            {
                array[j] = array[j + 1];
            }
            --last;
        }

        public T DeleteLast()
        {
            if (array.Count() == 0) return default(T);
            --last;
            return array[last];
        }

        public void deepCopy()
        {
            T[] new_array = new T[(int)(array.Length * coef + 1)];
            for (int i = 0; i < array.Length; ++i)
            {
                new_array[i] = array[i];
            }
            array = new_array;
        }
        public void Add(T n)
        {
            if (last == array.Length) deepCopy();
            array[last++] = n;
        }
        public bool Contains(T n)
        {
            for (int i = 0; i < array.Length; ++i)
                if (n.Equals(array[i])) return true;
            return false;
        }

        public T GetByIndex(int i)
        {
            if (i < 0 || i >= last) return default(T); //error
            return array[i];
        }

    }
}
