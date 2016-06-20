using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Please enter N");
            string input = Console.ReadLine();
            n =  Convert.ToInt32(input);

            Console.WriteLine("Triangle:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= i+1; j++)
                {
                        Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Square:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Romb:");
            int l = 2 * n - 1;
            int el = -1, pad = n, mid = n;
            bool up = true;
            for (int i = 0; i < l; i++)
            {
                if (up && (el+1)/2 < mid)
                {
                    el += 2;
                    --pad;
                }
                else
                {
                    up = false;
                    el -= 2;
                    ++pad;
                }

                for (int j = 0; j < pad; j++)
                {
                    Console.Write("  ");
                }
                for (int j = 0; j < el; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
