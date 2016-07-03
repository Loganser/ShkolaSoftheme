using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Heap
    {
        List<int> heap = new List<int>();

        public void HeapSort(int[] input)
        {
            int heapSize = input.Length;
            heap = input.ToList();

            for (int i = (heapSize-1) / 2; i >= 0; i--)
                MaxHeapify(i);

            for (int i = input.Length - 1; i >= 0; i--)
            {
                input[i] = getMax();
            }
        }

        public int getMax()
        {
            int result = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            MaxHeapify(0);
            return result;
        }

        private void MaxHeapify(int i)
        {
            //Console.WriteLine("Heapify index: {0}", i);
            int leftChild, rightChild, largestChild;
            int heapSize = heap.Count;
            while(true)
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < heapSize && heap[leftChild] > heap[largestChild])
                {
                    largestChild = leftChild;
                }

                if (rightChild < heapSize && heap[rightChild] > heap[largestChild])
                {
                    largestChild = rightChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                heap[i] ^= heap[largestChild];
                heap[largestChild] ^= heap[i];
                heap[i] ^= heap[largestChild];

                i = largestChild;
            }

        }

        public void Add(int value)
        {
            heap.Add(value);
            int i = heap.Count - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && heap[parent] < heap[i])
            {
                heap[i] ^= heap[parent];
                heap[parent] ^= heap[i];
                heap[i] ^= heap[parent];

                i = parent;
                parent = (i - 1) / 2;
            }
        }

    }
}
