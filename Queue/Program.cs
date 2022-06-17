using System;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
        }
    }
    public class Queue
    {
        private int _countElements = 4;
        private int _nextIndex;
        private int _headIndex;
        private int[] _elements;
    
        public Queue()
        {
            _elements = new int[_countElements];
        }
        
        public void Enqueue(int value)
        {
            // if head and tail match, means that array is full
            if (_nextIndex - _headIndex >= _elements.Length)
            {
                ExtendQueue();
            }
            // if it's not full add number
            var currentIndex = _nextIndex % _elements.Length;
            _elements[currentIndex] = value;
            ++_nextIndex;
        }
    
        private void ExtendQueue()
        {
            // make new array with X2 capacity;
            var newArray = new int[_elements.Length * 2];
            for (var i = 0; i < _elements.Length; i++)
            { // add to new array numbers from head
                newArray[i] = _elements[(_headIndex + i) % _elements.Length];
            }
            // new array - new head
            _headIndex = 0;
            _nextIndex = _elements.Length;
            // link to new arrary
            _elements = newArray;
        }
    
        public int Dequeue()
        {
            // head = tail
            if (_headIndex == _nextIndex)
            {
                throw new IndexOutOfRangeException();
            }
            // take first index (HEAD) and shift head 
            var result = _elements[_headIndex % _elements.Length];
            ++_headIndex;
            return result;
        }
    
        public int Peak()
        {
            if (_headIndex == _nextIndex)
            {
                throw new IndexOutOfRangeException();
            }
            // as dequeue take element 
            return _elements[_headIndex % _elements.Length];
        }
    }
}