using System;

namespace Dynamic_and_Circular_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularArray<int> circularArray = new CircularArray<int>(3);
            DynamicArray dynamicArray = new DynamicArray();
            var length = 8;
            var index = 5;
            for (var a = 0; a < length; a++)
            {
                Console.WriteLine(a % index);
            }
           
            
        }
    }

    // Complexity: Find Element - O (1), Delete Element - O(1)
    public class DynamicArray
    {
        private int _coundOfElements = 5;

        private int[] _elements;
        private int _nextIndex;

        public DynamicArray()
        {
            _elements = new int[_coundOfElements];
        }

        // just return amount of Elements
        public int Count => _nextIndex;

        // each iteration add to array new element but make it larger if count of element equal to "next index" (count of Elements)
        public void Add(int value)
        {
            if (_nextIndex == _elements.Length)
            {   // via "Array" library call "Resize"
                Array.Resize(ref _elements,_elements.Length * 2);
            }

            _elements[_nextIndex] = value;
            _nextIndex++;
        }

        // return element by its index
        public int Get(int index)
        {
            return _elements[index];
        }
        
        // return total array length (empty + full)
        public int Capacity => _elements.Length;
    }

    public class CircularArray<T>
    {
        private int _nextIndex;
        private T[] _elements;

        public CircularArray(int count)
        {
            _elements = new T[count];
        }

        public void Add(T value)
        {
            var currentIndex = _nextIndex % _elements.Length;
            _elements[currentIndex] = value;

            ++_nextIndex;
        }
        public void Print()
        {
            for(var a =0; a < _elements.Length; a++)
            {
                Console.WriteLine($"Element №{a} is - " + _elements[a]);
            }
        }

        public T Get(int index)
        {
            if (_nextIndex < _elements.Length)
            {
                return _elements[index];
            }

            return _elements[(_nextIndex + index) % _elements.Length];
        }

        public int Count => _nextIndex > _elements.Length ? _elements.Length : _nextIndex;
        
    }
}