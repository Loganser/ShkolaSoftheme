using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        public class Printer
        {
            public virtual void Print(string s)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Base class message: "+s);
            }
        }
        public class ColourPrinter : Printer
        {
            public override void Print(string s)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("ColourPrinter class message: " + s);
            }
            public void Print(string s, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("ColourPrinter class custom message: " + s);
            }

        }

        public class PhotoPrinter : Printer
        {
            public override void Print(string s)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PhotoPrinter class message: " + s);
            }
            public void Print(string photo, string path)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("ColourPrinter class custom message: " + "photo is ready");
            }
        }
        static void Main(string[] args)
        {
            Printer pr1 = new Printer();
            pr1.Print("Hi");
            pr1 = new ColourPrinter();
            pr1.Print("Hi");
            ColourPrinter pr2 = new ColourPrinter();
            pr2.Print("Hi", ConsoleColor.Cyan);

            pr1 = new PhotoPrinter();
            pr1.Print("Hi");
            PhotoPrinter pr3 = new PhotoPrinter();
            pr3.Print("myPhoto.jpg", "C\\:");


            pr2.PrintAll(ConsoleColor.Blue, "t1", "t2");

            pr1 = new Printer();
            pr1.PrintAll("t1", "t2");

            pr3.PrintAll("t1", "t2");

            Console.ReadLine();
        }
    }
}
