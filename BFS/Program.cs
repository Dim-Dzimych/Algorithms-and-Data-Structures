using System;
using System.Collections;
using System.Collections.Generic;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            // set "Start" and "End" position as you wish
            var start = 0;
            var end = 5;
            var peak = 7;
            var route = 10;

            int[,] matrix = new int[peak, peak];
            
            FillArray(matrix);
            // "minway" is array which keep only the shortest way from start to the peak (index of array can match with distance to the peak)
            int[] minWay = new int[peak];
            for (var i = 0; i < minWay.Length; i++)
            {
                // put 0 only in start point
                if (i == start)
                {
                    minWay[i] = 0;
                    continue;
                }
                minWay[i] = int.MaxValue;
            }
            // "Queue" helps save tops which were used for changing way in the "minWay"
            Queue<int> checkNumbers = new Queue<int>();
            checkNumbers.Enqueue(start);
            
            // if queue is empty means we unable to find shorter way, its enough
            while (checkNumbers.Count != 0)
            {
                // put off from list of queue for check this line number
                var numberLine = checkNumbers.Dequeue();
                for (var a = 0; a < peak; a++)
                {
                    // MUST check only cells more than 0, otherwise all cells in "minway" would be = 0
                    if (matrix[numberLine, a] > 0)
                    {
                        // need to add the shortest way to some point and from this to "start'
                        if (matrix[numberLine, a] + minWay[numberLine] < minWay[a])
                        {
                            minWay[a] = matrix[numberLine, a] + minWay[numberLine];
                            // if you find new "minway" route, we'll add to queue new number for checking this line
                            checkNumbers.Enqueue(a);
                        }
                    }
                }
            }

            for (var b = 0; b < minWay.Length; b++)
            {
                Console.WriteLine($"The shortest way from {start} to " + b + " - " + minWay[b]);
            }
            Console.WriteLine(" Answer is - " + minWay[end]);
        }

        public static void FillArray(int[,] matrix)
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


// BFS Uses queue and it means recheck peaks that you've checked ( - )
// Works with negative values ( + )
// Works slower than Dijkstra
