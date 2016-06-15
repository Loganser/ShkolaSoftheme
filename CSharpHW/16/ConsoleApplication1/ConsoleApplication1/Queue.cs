namespace ConsoleApplication1
{
    class Queue <T>
    {
        Stack<T> s_in;
        Stack<T> s_out;
        public Queue()
        {
            s_in = new Stack<T>();
            s_out = new Stack<T>();
        }
        public void Enqueue(T data)
        {
            s_in.push(data);
        }
        public T Dequeue()
        {
            if (s_out.Count()==0)
            {
                if (s_in.Count()==0) return default(T) ;
                while (s_in.Count() != 0) s_out.push(s_in.Pop());
            }
            return s_out.Pop();
        }
        public T Peek()
        {
            if (s_out.Count() == 0)
            {
                if (s_in.Count() == 0) return default(T);
                while (s_in.Count() != 0) s_out.push(s_in.Pop());
            }
            return s_out.Peek();
        }

        public int Count()
        {
            return s_in.Count() + s_out.Count();
        }

    }
}
