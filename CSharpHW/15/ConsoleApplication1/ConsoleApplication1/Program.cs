using System;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        class MyClass
        {
            public int data;
            public MyClass()
            {
                data = 0;
            }
            public MyClass(int d)
            {
                data = d;
            }
        }
        static void Main(string[] args)
        {
            LinkedList<MyClass> L = new LinkedList<MyClass>();
            MyClass mc = new MyClass(1);
            L.Add(mc);
            mc = new MyClass(2);
            L.Add(mc);
            mc = new MyClass(3);
            L.Add(mc);
            Console.WriteLine(L.Count());
            Console.WriteLine(L.Find(mc));
            mc = new MyClass(4);
            Console.WriteLine(L.Find(mc));
            MyClass[] mc_array = L.ToArray();
            for (int i = 0; i < mc_array.Count(); ++i)
                Console.WriteLine(mc_array[i].data);

            Console.WriteLine();
            L.Delete(L.head);

            mc_array = L.ToArray();
            for (int i = 0; i < mc_array.Count(); ++i)
                Console.WriteLine(mc_array[i].data);

            Console.ReadLine();
        }
    }
}
