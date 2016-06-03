using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*Help* For quitting type \"exit\"\n");
            string inp = "";
            while (true)
            {
                Console.WriteLine("x");
                inp = Console.ReadLine();
                if (inp == "exit") break;
                double x = Convert.ToDouble(inp);
                Console.WriteLine("y");
                inp = Console.ReadLine();
                if (inp == "exit") break;
                double y = Convert.ToDouble(inp);
                Console.WriteLine("// Type operation ( +   -   *   /   ) //");
                inp = Console.ReadLine();
                if (inp == "exit") break;
                string z = inp;
                switch (z)
                {
                    case "+":
                        Console.WriteLine("//.. Result ..//");
                        Console.WriteLine(x + y);
                        break;
                    case "-":
                        Console.WriteLine("//.. Result ..//");
                        Console.WriteLine(x - y);
                        break;
                    case "*":
                        Console.WriteLine("//.. Result ..//");
                        Console.WriteLine(x * y);
                        break;
                    case "/":
                        if (y == 0)
                        {
                            Console.WriteLine("Деление на 0!!!");
                        }
                        else
                        {
                            Console.WriteLine("//.. Результат ..//");
                            Console.WriteLine(x / y);
                        }
                        break;
                }
            }
        }
    }
}
