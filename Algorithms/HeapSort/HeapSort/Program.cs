using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 4, 6, 2, 3, 0, 8, 1, 9, 7, 5 };
            foreach (int i in input)
                Console.Write(i + " ");
            Console.WriteLine();

            Heap h = new Heap();

            h.HeapSort(input);

            foreach (int i in input)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
