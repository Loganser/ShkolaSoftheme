using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        class ArrayWrapper
        {
            int[] array;
            int last;
            double coef = 1.5;
            public ArrayWrapper(int n)
            {
                array = new int[n];
                last = 0;
            }
            public ArrayWrapper()
            {
                array = new int[10];
                last = 0;
            }

            public void deepCopy()
            {
                int[] new_array = new int[(int)(array.Length*coef + 1)];
                for (int i = 0; i < array.Length; ++i)
                {
                    new_array[i] = array[i];
                }
                array = new_array;
            }
            public void Add(int n)
            {
                if (last == array.Length) deepCopy();
                array[last++] = n;
            }
            public bool Contains(int n)
            {
                for (int i = 0; i < array.Length; ++i)
                    if (n == array[i]) return true;
                return false;
            }

            public int GetByIndex(int i)
            {
                if (i < 0 || i >= last) return 0; //error
                return array[i];
            }

        }
        static void Main(string[] args)
        {
            ArrayWrapper a = new ArrayWrapper(1);
            a.Add(1);
            a.Add(2);
            a.Add(5);
            a.GetByIndex(2);
            Console.WriteLine(a.Contains(1));

            Console.ReadLine();
        }
    }
}
