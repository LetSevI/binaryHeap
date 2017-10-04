using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryHeapLib;

namespace BinaryHeap.Test
{
    [TestClass]
    public class BinaryHeapTest
    {
        [TestMethod]
        public void AddingItems()
        {
            BinaryHeap<int> binaryHeap = new MaxBinaryHeap<int>();
            binaryHeap.Add(1);
            binaryHeap.Add(4);
            binaryHeap.Add(0);

            Assert.AreEqual(3, binaryHeap.Count);
        }

        [TestMethod]
        public void AddingItemsByConstructor()
        {
            BinaryHeap<int> binaryHeap = new MaxBinaryHeap<int>(new[] { 1, 9, 10, 3, -1, -10 });

            Assert.AreEqual(6, binaryHeap.Count);
        }

        [TestMethod]
        public void ContainsItem()
        {
            BinaryHeap<int> binaryHeap = new MaxBinaryHeap<int>(new[] { 1, 9, 10, 3, -1, -10 });

            Assert.AreEqual(true, binaryHeap.Contains(-1));
            Assert.AreEqual(false, binaryHeap.Contains(100));
        }

        [TestMethod]
        public void GetTopElementFromMaxHeap()
        {
            BinaryHeap<int> binaryHeap = new MaxBinaryHeap<int>(new[] { 1, 9, 10, 3, -1, -10 });

            Assert.AreEqual(10, binaryHeap.GetTopElement());
        } 

        [TestMethod]
        public void GetTopElementFromMinHeap()
        {
            BinaryHeap<int> binaryHeap = new MinBinaryHeap<int>(new[] { 1, 9, 10, 3, -1, -10 });

            Assert.AreEqual(-10, binaryHeap.GetTopElement());
        }

        [TestMethod]
        public void DeleteTopElement()
        {
            BinaryHeap<int> binaryHeap = new MaxBinaryHeap<int>(new[] { 1, 2, 5, 0, 10, 4, 9 });

            binaryHeap.DeleteTopElement();

            Assert.AreEqual(6, binaryHeap.Count);
            Assert.AreEqual(9, binaryHeap.GetTopElement());
        }

        [TestMethod]
        public void ClearHeap()
        {
            BinaryHeap<int> binaryHeap = new MaxBinaryHeap<int>(new[] { 1, 2, 5, 0, 10, 4, 9 });
            binaryHeap.Clear();

            Assert.AreEqual(0, binaryHeap.Count);
        }
    }
}