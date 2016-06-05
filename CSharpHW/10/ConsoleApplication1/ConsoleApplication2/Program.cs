using System;
using System.Collections.Generic;
using System.Linq;

//Merge sort top-down
class Program
{
    public static int[] MergeSort(int[] a)
    {
        if (a.Length <= 1) return a;
        int m = (a.Length) / 2;
        int[] left = new int[m];
        int[] right = new int[a.Length - m];
        Array.Copy(a, left, m);
        Array.Copy(a, m, right, 0, right.Length);
        left = MergeSort(left);
        right = MergeSort(right);
        return Merge(left, right);
    }

    public static int[] Merge(int[] left, int[] right)
    {
        int[] res = new int[left.Length + right.Length];
        int i1 = 0, i2 = 0, cur = 0;
        while (i1 < left.Length || i2 < right.Length)
        {
            if (i1 < left.Length && i2 < right.Length)
            {
                if (left[i1] < right[i2])
                {
                    res[cur++] = left[i1++];
                }
                else
                {
                    res[cur++] = right[i2++];
                }
            }
            else
            {
                while (i1 < left.Length)
                {
                    res[cur++] = left[i1++];
                }
                while (i2 < right.Length)
                {
                    res[cur++] = right[i2++];
                }
            }
        }
        return res;
    }

    static void Main()
    {
        int[] a = new int[] { 5, 2, 6, 4, 7, 10, 1, 9, 3, 8 };
        a = MergeSort(a);
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine("array[{0}] = {1}", i, a[i]);
        }
        Console.ReadLine();
    }
}