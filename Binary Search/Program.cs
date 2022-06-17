using System;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[100]; 
            Random randomNumber = new Random();
            // Add random numbers to Array
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = randomNumber.Next(70);
            }
            
            // Sort array with the QuickSort
            Array.Sort(numbers);
            
            // with sorted array we can make Binary Search (must sort it)
            int left = 0;
            int right = numbers.Length - 1;
            int middle = 0;
            int steps = 0;
            
            // make boundary with "left" and "right"
            Console.WriteLine("Enter any Number");
            var numberToGuess = Convert.ToInt32(Console.ReadLine());

            while (left != right)
            {
                steps++;
                // to prevent overshooting 32 bit of Int
                middle = left + (right - left) / 2;
                
                //each iteration change boundary with "middle"
                if (numberToGuess == numbers[middle])
                {
                    break;
                }
                else if (numberToGuess > numbers[middle])
                {
                    // here we should add 1 
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }
            
            // Complexity is - O (log N)
            if (numberToGuess == numbers[middle])
            {
                Console.WriteLine($"Number has founded, it took + {steps} steps");
            }
            else
            {
                Console.WriteLine("No this number in array");
            }

        }
    }
}