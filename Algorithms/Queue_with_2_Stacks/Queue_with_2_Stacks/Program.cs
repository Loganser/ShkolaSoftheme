using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Queue_with_2_Stacks
{
    class Program
    {
        class MyQueue
        {
            Stack<int> s_in = new Stack<int>();
            Stack<int> s_out = new Stack<int>();

            public void Enqueue(int x)
            {
                s_in.Push(x);
            }

            public int Peek()
            {
                if (s_out.Count == 0)
                {
                    while (s_in.Count > 0) s_out.Push(s_in.Pop());
                }
                if (s_out.Count == 0) return -1; //error
                return s_out.Peek();
            }

            public int Dequeue()
            {
                if (s_out.Count == 0)
                {
                    while (s_in.Count > 0) s_out.Push(s_in.Pop());
                }
                if (s_out.Count == 0) return -1; //error
                return s_out.Pop();
            }
        }
        static void Main(string[] args)
        {
            MyQueue q = new MyQueue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Peek());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Peek());

            //Queue<int> q1 = new Queue<int>();
            //q1.En
            Console.ReadLine();
        }
    }
}
