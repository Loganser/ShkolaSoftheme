namespace ConsoleApplication1
{
    class Dictionary<K, D>
    {
        ArrayWrapper<K> dict_k; //assume all keys are unique
        ArrayWrapper<D> dict_d;
        public Dictionary()
        {
            dict_k = new ArrayWrapper<K>(); 
            dict_d = new ArrayWrapper<D>();
        }
        public void Add(K key, D data)
        {
            dict_k.Add(key);
            dict_d.Add(data);
        }
        public D GetData(K key)
        {
            int i = 0;
            while (i < dict_k.last && !dict_k.array[i].Equals(key)) ++i;
            if (i == dict_d.last) return default(D);
            return dict_d.array[i];
        }
        public int Count()
        {
            return dict_k.last;
        }
        public void DeleteByKey(K key)
        {
            int i = 0;
            while (i < dict_k.last && !dict_k.array[i].Equals(key)) ++i;
            dict_k.DeleteAndShift(i);
            dict_d.DeleteAndShift(i);
        }
        public bool ContainsKey(K key)
        {
            int i = 0;
            while (i < dict_k.last && !dict_k.array[i].Equals(key)) ++i;
            if (i < dict_k.last) return true;
            return false;
        }
    }
}
