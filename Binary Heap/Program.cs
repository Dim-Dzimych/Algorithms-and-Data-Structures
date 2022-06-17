using System;
using System.Collections.Generic;

namespace Binary_Heap
{
    class Program
    {
        private static List<int> _list;
        
        static void Main(string[] args)
        { // initialize "_list" here
            _list =new List<int>();
        }
        private static void Adder(int value)
        {
            // method Add value to list and than take the last number index and get parent number index
            _list.Add(value);
            int lastNumber = HeapSize() - 1;
            int parent = (lastNumber - 1) / 2;
            // if lastnumber is greater than parent - change place
            while (lastNumber > 0 && _list[parent] < _list[lastNumber])
            {
                (_list[lastNumber], _list[parent]) = (_list[parent], _list[lastNumber]);
                // we've changed numbers and need to change there index
                lastNumber = parent;
                parent = (lastNumber - 1) / 2;
            }
        }
        private static void Heapify(int startTop)
        {
            // after each removal we must check numbers position
            int leftChild = 2 * startTop + 1;
            int rightChild = 2 * startTop + 2;
            int parent = startTop;
        
            while (true)
            {
                
                if (leftChild < HeapSize() && _list[leftChild] > _list[parent])
                {
                    parent = leftChild;
                }
        
                if (rightChild < HeapSize() && _list[rightChild] > _list[parent])
                {
                    parent = rightChild;
                }
                // if left or right child on there position, we'll not change anything, or we've changed all
                if (startTop == parent)
                {
                    break;
                }
                // if right or left bigger, must change
                (_list[startTop], _list[parent]) = (_list[parent], _list[startTop]);

                // change top of checking
                startTop = parent;
            }
        
        }
        private static void Print()
        {
            // imitate level of tree
            var a = 0;
            var b = 1;
            while (a < HeapSize())
            {
                // each times make array for printing tree's index bigger
                while ((a < b) && (a < HeapSize()))
                {
                    Console.Write(_list[a] + " ");
                    a++;
                }
                Console.WriteLine();
                b = b * 2 + 1;
            }
        }
        private static int GetMax()
        {
            // just save number, change position
            var topNumber = _list[0];
            var bottomNumber = HeapSize() - 1;
            _list[0] = _list[bottomNumber];
            _list.RemoveAt(bottomNumber);
            // make sorting method from start
            Heapify(0);
            return topNumber;
        }
        private static int HeapSize()
        {
            return _list.Count;
        }

    }
}
 // Sorting O( N * log N) add and check every number
 // Sorting O( N ) add all numbers and heapify
 // Add New O( log N)