using System;
using System.Collections.Generic;
using System.Linq;

//Merge sort bottom-up
class Program
{
    public static void MergeSort(int[] a, int[] tmp)
    {
        int width;
        for (width = 1; width < a.Length; width *= 2)
        {
            int i;

            for (i = 0; i < a.Length; i = i + 2 * width)
            {
                int left, middle, right;
                left = i;
                middle = i + width;
                middle = System.Math.Min(i + width, a.Length);
                right = System.Math.Min(i + 2 * width, a.Length);
                //right = i + 2 * width;
                Merge(a, left, middle, right, tmp);
            }
            for (int j = 0; j < a.Length; j++)
                a[j] = tmp[j];
        }
        if (a.Length == 1) tmp[0] = a[0];

    }

    public static void Merge(int[] a, int iLeft, int iMiddle, int iRight, int[] tmp)
    {
        int i, j, k;
        i = iLeft;
        j = iMiddle;
        k = iLeft;
        while (i < iMiddle || j < iRight)
        {
            if (i < iMiddle && j < iRight)
            {
                if (a[i] < a[j])
                {
                    tmp[k++] = a[i++];
                }
                else
                {
                    tmp[k++] = a[j++];
                } 
            }
            else if (i == iMiddle)
            {
                tmp[k++] = a[j++];
            } 
            else if (j == iRight)
            {
                tmp[k++] = a[i++];
            }
        }

    }

    static void Main()
    {
        int[] a = new int[] { 5, 2, 6, 4, 7, 10, 1, 9, 3, 8 };
        int[] sorted_a = new int[a.Length];
        MergeSort(a, sorted_a);
        for (int i = 0; i < sorted_a.Length; i++)
        {
            Console.WriteLine("array[{0}] = {1}", i, sorted_a[i]);
        }
        Console.ReadLine();
    }
}