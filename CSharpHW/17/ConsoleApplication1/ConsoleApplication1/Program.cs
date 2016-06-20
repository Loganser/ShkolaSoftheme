using System;

namespace ConsoleApplication1
{
    class MainApp
    {
        static void Main()
        {

            ConcreteAggregate<string> CA = new ConcreteAggregate<string>();
            CA[0] = "0"; CA[1] = "1";
            CA[2] = "2"; CA[3] = "3";
            ConcreteIterator<string> iter = new ConcreteIterator<string>(CA);
            var item = iter.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = iter.Next();
            }
            Console.ReadLine();
        }
    }
}