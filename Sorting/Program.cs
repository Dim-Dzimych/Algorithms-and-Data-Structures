using System;
using System.Collections.Specialized;

namespace Sorting
{
    class Program
    {
        private static int[] numbers = new int[7];
        private static Random randomNumbers = new Random();
        static void Main(string[] args)
        {
            // use all sorting methods with "numbers" for checking 
            //QuickSort(0,numbers.Length - 1);
        }

        private static int[] SelectionSort(int[] randomNumbers)
        {
            // 1) Selection sort, the most slowest method. Complexity - O(n2).
            // Make it once and other operation would be - (O log n)

            for (var a = 0; a < randomNumbers.Length - 1; a++)
            {
                var min = a;
                for (var b = a + 1; b < randomNumbers.Length; b++)
                {
                    if (randomNumbers[b] < randomNumbers[min])
                    {
                        min = b;
                    }
                }
                
                (randomNumbers[a], randomNumbers[min]) = (randomNumbers[min], randomNumbers[a]);
            }
            return randomNumbers;
        }

        private static int[] BubbleSort(int[] randomNumbers)
        {
            // Complexity - (On2). 
            // QuickSort created by Bubble sort
            
            for (var a = 0; a < randomNumbers.Length - 1; a++)
            {
                for (var b = 0; b < randomNumbers.Length - 1; b++)
                {
                    if (randomNumbers[b] > randomNumbers[b + 1])
                    {
                        (randomNumbers[b], randomNumbers[b + 1]) = (randomNumbers[b + 1], randomNumbers[b]);
                    }
                }
            }

            return randomNumbers;
        }
        
        private static int[] InsertionSort(int[] randomNumbers)
        {
            //Works much faster with Binary Search
            // The fastest than other with a little bit sorted array
            
            int number = 0;
            int index = 0;
            for (var i = 0; i < randomNumbers.Length; i++)
            {
                number = randomNumbers[i];
                index = i;
                while (index > 0 && randomNumbers[index - 1] > number)
                {
                    (randomNumbers[index - 1], randomNumbers[index]) = (randomNumbers[index], randomNumbers[index - 1]);
                    index -= 1;
                }
                randomNumbers[index] = number;
            }
            return randomNumbers;
        }
        private static void QuickSort(int start, int end)
        {
            // Complexity - (O n * logn) but with bad elements would be - (On2)
            if (start >= end)
            {
                return;
            }
            var reference = Section(start,end);
            QuickSort(start,reference - 1);
            QuickSort(reference + 1, end);

            int Section(int start, int end)
            {
                int temp;
                int marker = start;
                for (var i = start; i < end; i++)
                {
                    // need to determine element from which would we follow, here is "end". Better to use Random 
                    if (numbers[i] < numbers[end])
                    {
                        temp = numbers[marker];
                        numbers[marker] = numbers[i];
                        numbers[i] = temp;
                        
                        marker += 1;
                    }
                }

                temp = numbers[marker];
                numbers[marker] = numbers[end];
                numbers[end] = temp;

                return marker;
            }
        }
    }
}