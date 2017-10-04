using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryHeapLib;

namespace BinaryHeap.Test
{
    [TestClass]
    public class HeapSortTest
    {
        [TestMethod]
        public void Sort()
        {
            int[] input = new[] { 10, 2, 1, -1, 20, 9, 5, 6, 4, 7 };
            input.HeapSort();

            bool isRight = true;
            int prevItem = input[0];
            for(int i = 1; i < input.Length; i++)
            {
                if(prevItem > input[i])
                {
                    isRight = false;
                    break;
                }
            }

            Assert.AreEqual(true, isRight);
        }

        [TestMethod]
        public void SortByAsc()
        {
            int[] input = new[] { 10, 2, 1, -1, 20, 9, 5, 6, 4, 7 };
            input.HeapSortByAsc();

            bool isRight = true;
            int prevItem = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (prevItem < input[i])
                {
                    isRight = false;
                    break;
                }
            }

            Assert.AreEqual(true, isRight);
        }
    }
}