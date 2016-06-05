using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Helper
    {
        public static void PrintAll(this Program.Printer pr, params string[] s)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------");
            foreach (string s_i in s)
                Console.WriteLine(s_i);
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
        }

        public static void PrintAll(this Program.ColourPrinter pr, ConsoleColor color, params string[] s)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("--------------------------------");
            foreach (string s_i in s)
                Console.WriteLine(s_i);
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
        }

        public static void PrintAll(this Program.PhotoPrinter pr, params string[] s)
        {
            if (s.Length % 2 == 1) Console.WriteLine("Error");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < s.Length; i+=2)
            {
                Console.WriteLine("Photo is ready: ");
                Console.WriteLine(s[i]+" "+s[i+1]);
            }
            Console.WriteLine("--------------------------------");
            Console.ResetColor();
        }

    }
}
