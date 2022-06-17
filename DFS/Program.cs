using System;

namespace DFS
{
    class Program
    {
        // Set Your Numbers
        private static int _start = 1;
        private static int _end = 4;
        private static int _peak = 7;
        private static bool result;
        private static bool[] _usedWay = new bool[_peak];
        private  static int[,] _matrix;
        private static int[] _shortWay = new int[_peak];
        
        static void Main(string[] args)
        {
            //set "Start" and "End" position as you wish
            _matrix = new int[_peak, _peak];
            FillArray(_matrix);
            
            for (var a = 0; a < _shortWay.Length; a++)
            {
                if (a == _start)
                {
                    // put 0 only in start point
                    _shortWay[a] = 0;
                    continue;
                }
                _shortWay[a] = int.MaxValue;
            }
            DFS(_start);
            string answer = result == false ? "No way" : "There is a way"; // call answer!
        }

        private static void DFS(int top)
        {
            // means that we were here
            if (_usedWay[top])
            {
                return;
            }

            _usedWay[top] = true;
            // Congratulate you! found it
            if (top == _end)
            {
                result = true;
                return;
            }

            // Try to check every peak 
            for (var a = 0; a < _peak; a++)
            { // recursively call method (you may use "Queue")
                if (_matrix[top,a] > 0)
                {
                    DFS(a);
                }
            }
        }
        private static void FillArray(int[,] matrix)
        {
            // May fill cells via "Readline" but save your time, don't mention it;
            matrix[0, 3] = 25; matrix[3, 0] = 25;
            matrix[0, 5] = 23; matrix[5, 0] = 23;
            matrix[0, 6] = 27; matrix[6, 0] = 27;
            matrix[1, 4] = 29; matrix[4, 1] = 29;
            matrix[1, 3] = 22; matrix[3, 1] = 22;
            matrix[2, 4] = 24; matrix[4, 2] = 24;
            matrix[2, 6] = 23; matrix[6, 2] = 23;
            matrix[3, 4] = 54; matrix[3, 4] = 54;
            matrix[4, 5] = 59; matrix[5, 4] = 59;
            matrix[4, 6] = 49; matrix[6, 4] = 49;
        }
    }
}

// Helps find there is or not way to peak ( + )
// Way may not be the shortest ( - )