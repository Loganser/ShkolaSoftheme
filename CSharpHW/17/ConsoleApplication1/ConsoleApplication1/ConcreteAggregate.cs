using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class ConcreteAggregate<T> : Aggregate<T> where T: class
    {
        private readonly List<T> _items = new List<T>();

        public override Iterator<T> CreateIterator()
        {
            return new ConcreteIterator<T>(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }


        public T this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
}