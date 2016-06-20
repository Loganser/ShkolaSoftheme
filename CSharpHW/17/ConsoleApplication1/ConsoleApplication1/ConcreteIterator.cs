namespace ConsoleApplication1
{
    class ConcreteIterator<T> : Iterator<T> where T: class
    {
        private readonly ConcreteAggregate<T> _aggregate;
        private int _current;

        public ConcreteIterator(ConcreteAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }

        public override T First()
        {
            return _aggregate[0];
        }

        public override T Next()
        {
            T ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        public override T CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}