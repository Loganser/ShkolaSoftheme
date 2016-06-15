using System;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------STACK-----------");
            Stack<int> s = new Stack<int>();
            s.push(1);
            s.push(2);
            s.push(3);
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Peek());
            Console.WriteLine(s.Pop());

            Console.WriteLine("-----------QUEUE-----------");
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());

            Console.WriteLine("-----------DICTIONARY-----------");
            Dictionary<int, int> d = new Dictionary<int, int>();
            d.Add(1, 1);
            d.Add(2, 5);
            d.Add(3, 10);
            Console.WriteLine(d.ContainsKey(4));
            Console.WriteLine(d.ContainsKey(1));
            Console.WriteLine(d.GetData(2));
            d.DeleteByKey(1);
            Console.WriteLine(d.ContainsKey(1));

            Console.ReadLine();
        }
    }
}
