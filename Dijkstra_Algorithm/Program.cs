using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Dijkstra_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //set "Start" and "End" position as you wish
                var start = 0;
                var end = 5;
                var peak = 7;
                var usesCount = 0;
                
                int[,] matrix = new int[peak, peak];
                FillArray(matrix);
                int[] shortWay = new int[peak];
                for (var a = 0; a < shortWay.Length; a++)
                {
                    if (a == start)
                    {
                        // put 0 only in start point
                        shortWay[a] = 0;
                        continue;
                    }
                    shortWay[a] = int.MaxValue;
                }
            
                bool[] usedWay = new bool[peak];
                while (usesCount < peak)
                {
                    
                    var minValue = int.MaxValue;
                    var currentIndex = 0;
                    for(var b = 0; b < peak;b++)
                    {
                        // "minValue" and "currentIndex" help us determine the lowest distance and save is peak
                        if (!usedWay[b] && shortWay[b] < minValue)
                        {
                            minValue = shortWay[b];
                            currentIndex = b;
                        }
                    }
            
                    for (var c = 0; c < peak; c++)
                    {
                        // MUST check only zero-empty cells
                        if (matrix[currentIndex, c] > 0 && !usedWay[c])
                        {
                            // if find shorter way save it
                            if (matrix[currentIndex, c] + shortWay[currentIndex] < shortWay[c])
                            {
                                shortWay[c] = matrix[currentIndex, c] + shortWay[currentIndex];
                            }
                        }
                    }
                    // use peak - forget peak
                    usedWay[currentIndex] = true;
                    usesCount++;
                }
                
                // for (var a = 0; a < peak; a++)
                // {
                //     Console.Write(shortWay[a] + " ");
                // }
                
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

// BFS makes stronger and get Dijkstra
// Works faster than BFS/DFS ( + )
// Unable to work with negative Value ( - )




 
       
        