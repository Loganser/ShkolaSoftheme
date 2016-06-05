using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static int findUnique(int []a)
        {
            int res = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                res ^= a[i];   // b ^ b = 0
            }
            return res;
        }

        static void Main(string[] args)
        {
            int[] a = { 5, 5, 100, 432, 9, 432, 100 };
            Console.WriteLine(findUnique(a));


            Console.ReadLine();
        }
    }
}
