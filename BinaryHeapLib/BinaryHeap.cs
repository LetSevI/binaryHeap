using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryHeapLib
{
    public abstract class BinaryHeap<T> where T : IComparable
    {
        private T[] _items;

        public int Count => _items?.Length ?? 0;

        public BinaryHeap()
        { }

        public BinaryHeap(IEnumerable<T> collection)
        {
            BuildHeap(collection.ToArray());
        }

        public void BuildHeap(T[] target)
        {
            int heapSize = target.Length;

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                Heapify(target, heapSize, i);
            }

            _items = target;
        }

        public void Add(T item)
        {
            if (_items == null)
            {
                _items = new[] { item };
                return;
            }

            T[] temp = _items;
            _items = new T[_items.Length + 1];
            Array.Copy(temp, _items, temp.Length);
            _items[temp.Length] = item;
            HeapIncreaseKey(temp.Length);
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public T GetTopElement()
        {
            if (_items.Length == 0)
            {
                throw new Exception("Heap is empty");
            }

            return _items[0];
        }

        public void DeleteTopElement()
        {
            T[] tempArr = _items;
            _items = new T[tempArr.Length - 1];
            for (int i = 0; i < tempArr.Length - 1; i++)
            {
                _items[i] = tempArr[i + 1];
            }

            Heapify(_items, _items.Length, 0);
        }

        public void Clear()
        {
            _items = new T[0];
        }

        public void HeapSort(T[] target)
        {
            int heapSize = target.Length;
            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                Heapify(target, heapSize, i);
            }

            for (int i = heapSize - 1; i >= 1; i--)
            {
                target.Swap(i, 0);
                heapSize--;
                Heapify(target, heapSize, 0);
            }
        }

        private void Heapify(T[] array, int heapSize, int index)
        {
            if (GetLeftChildPosition(index) >= heapSize)
            {
                return;
            }
           
            bool leftIsLargest = GetRightChildPosition(index) >= heapSize ||
                Compare(array[GetRightChildPosition(index)], array[GetLeftChildPosition(index)]) < 0;
            int largestKidPos = (leftIsLargest)
                ? GetLeftChildPosition(index)
                : GetRightChildPosition(index);

            if (Compare(array[largestKidPos], array[index]) > 0)
            {
                array.Swap(index, largestKidPos);

                if (leftIsLargest)
                {
                    Heapify(array, heapSize, GetLeftChildPosition(index));
                }
                else
                {
                    Heapify(array, heapSize, GetRightChildPosition(index));
                }
            }

        }

        private int GetLeftChildPosition(int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        private int GetRightChildPosition(int parentPos)
        {
            return 2 * (parentPos + 1);
        }

        private void HeapIncreaseKey(int currentIndex)
        {
            while (true)
            {
                if (currentIndex == 0)
                {
                    return;
                }

                T parentItem = _items[(currentIndex - 1) / 2];
                T current = _items[currentIndex];

                if (Compare(parentItem, current) < 0)
                {
                    _items[(currentIndex - 1) / 2] = current;
                    _items[currentIndex] = parentItem;
                    currentIndex = (currentIndex - 1) / 2;
                    continue;
                }

                break;
            }
        }

        protected abstract int Compare(T first, T second);
    }
}