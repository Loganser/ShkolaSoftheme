using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LinkedList <T>
    {
        public class node
        {
            public T data;
            public node next;
            public node prev;
            public node(T data)
            {
                this.data = data;
                next = null;
                prev = null;
            }
            public node()
            {
                next = null;
                prev = null;
            }
        }
        public node head { get; set; }
        node current;

        public void Add(T d)
        {
            if (head == null)
            {
                head = new node(d);
                current = head;
                return;
            }
            node tmp = current;
            current.next = new node(d);
            current = current.next;
            current.prev = tmp;
        }

        public int Count()
        {
            int res = 0;
            node tmp = head;
            while (tmp != null)
            {
                tmp = tmp.next;
                ++res;
            }
            return res;
        }

        public T[] ToArray()
        {
            T[] res = new T[Count()];
            int iter = 0;
            node tmp = head;
            while (tmp != null)
            {
                res[iter++] = tmp.data;
                tmp = tmp.next;
            }
            return res;
        }

        public bool Find(T d)
        {
            node tmp = head;
            while (tmp != null && !tmp.data.Equals(d)) tmp = tmp.next;
            if (tmp != null) return true;
            return false;
        }

        public void Delete(node n)
        {
            node tmp = head;
            while (tmp != null && tmp != n) tmp = tmp.next;
            if (tmp == head)
            {
                head = head.next;
                return;
            }
            tmp.prev.next = tmp.next;
        }

    }
}
