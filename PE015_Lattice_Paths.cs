/*
 * ProjectEuler.net
 * Question 15: Lattice Paths
 * Description: Being able only to move right and down, find the number of possible paths from
 *              the top-left to bottom-right corner of a 20x20 grid
 * Author:      Otto Lau
 * Date:        December 17, 2015
 */

using System;

namespace PE015_Lattice_Paths
{
    class PE015_Lattice_Paths
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the grid:");
            int gridSize = Int32.Parse(Console.ReadLine());

            long numOfPossiblePaths = possiblePaths(gridSize);
            Console.WriteLine("For a grid of size {0}, there are {1} possible routes from the top-left corner to the bottom-right corner.", gridSize, numOfPossiblePaths);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Calculates the number of possible paths from the top-left to bottom-right corner of a n by n grid.
        /// </summary>
        /// <param name="gridSize">The length of the grid. Must be a positive integer.</param>
        /// <returns>The number of possible paths.</returns>
        /// 
        public static long possiblePaths(int gridSize)
        {
            // Array size (number of intersections) is one more than the grid length
            int arraySize = gridSize + 1;
            long[,] array = new long[arraySize, arraySize];

            // Origin
            array[0, 0] = 0;

            // Adjacent sides to the origin can be reached by only one possible path
            for (int i = 1; i < arraySize; i++)
            {
                array[i, 0] = 1;
                array[0, i] = 1;
            }

            // The number of possible paths to reach the inner intersections is the sum
            //  of the value at the intersection above and to the left of it
            for (int i = 1; i < arraySize; i++)
            {
                for (int j = 1; j < arraySize; j++)
                {
                    array[i, j] = array[i - 1, j] + array[i, j - 1];
                }
            }

            return array[arraySize - 1, arraySize - 1];
        }
    }
}
