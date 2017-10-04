using System;

namespace BinaryHeapLib
{
    public static class HeapExtensions
    {
        public static void HeapSort<T>(this T[] target) where T : IComparable
        {
            new MaxBinaryHeap<T>().HeapSort(target);
        }

        public static void HeapSortByAsc<T>(this T[] target) where T : IComparable
        {
            new MinBinaryHeap<T>().HeapSort(target);
        }
    }
}