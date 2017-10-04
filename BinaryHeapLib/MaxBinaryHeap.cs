using System;
using System.Collections.Generic;

namespace BinaryHeapLib
{
    public class MaxBinaryHeap<T> : BinaryHeap<T> where T : IComparable
    {
        public MaxBinaryHeap() : base()
        { }

        public MaxBinaryHeap(IEnumerable<T> collection) : base(collection)
        { }

        protected override int Compare(T first, T second)
        {
            return first.CompareTo(second);
        }
    }
}