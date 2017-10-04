using System;
using System.Collections.Generic;

namespace BinaryHeapLib
{
    public class MinBinaryHeap<T> : BinaryHeap<T> where T : IComparable
    {
        public MinBinaryHeap() : base()
        { }

        public MinBinaryHeap(IEnumerable<T> collection) : base(collection)
        { }

        protected override int Compare(T first, T second)
        {
            return second.CompareTo(first);
        }
    }
}