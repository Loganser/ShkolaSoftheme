namespace ConsoleApplication1
{
    class Stack<T>
    {
        ArrayWrapper<T> stack = new ArrayWrapper<T>();
        
        public void push(T data)
        {
            stack.Add(data);
        }
        public T Pop()
        {
            if (stack.last == 0) return default(T);
            return stack.DeleteLast();
        }
        public T Peek()
        {
            if (stack.last == 0) return default(T);
            return stack.array[stack.last-1];
        }
        public int Count()
        {
            return stack.last;
        }
    }
}
