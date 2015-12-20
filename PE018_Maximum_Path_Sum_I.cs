/*
 * ProjectEuler.net
 * Question 18: Maximum Path Sum I
 * Description: Find the maximum total from traversing adjacent numbers from top to bottom in the triangle
 * Author:      Otto Lau
 * Date:        December 20, 2015
 */

using System;

namespace PE018_Maximum_Path_Sum_I
{
    class PE018_Maximum_Path_Sum_I
    {
        static void Main(string[] args)
        {
            //int[] triangleArray = { 
            //    3, 
            //    7, 4,
            //    2, 4, 6,
            //    8, 5, 9, 3
            //};

            int[] triangleArray = {
                75,
                95, 64,
                17, 47, 82,
                18, 35, 87, 10,
                20, 04, 82, 47, 65,
                19, 01, 23, 75, 03, 34,
                88, 02, 77, 73, 07, 63, 67,
                99, 65, 04, 28, 06, 16, 70, 92,
                41, 41, 26, 56, 83, 40, 80, 70, 33,
                41, 48, 72, 33, 47, 32, 37, 16, 94, 29,
                53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14,
                70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57,
                91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48,
                63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31,
                04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23
            };

            int[][] triangle = ConstructTriangle(triangleArray);
            int greatestPath = CalculateGreatestPath(triangle);
            Console.WriteLine("The greatest sum of the path from the top to the bottom of the triangle is {0}.", greatestPath);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Convert a 1D array of triangle's numbers into a 2D jagged array.
        /// </summary>
        /// <param name="triangleArray">1D array of positive integers.</param>
        /// <returns>A 2D jagged array represented in the triangle.</returns>
        /// 
        public static int[][] ConstructTriangle(int[] triangleArray)
        {
            // Calculate the size of the array by retrieving the length of the bottom row
            int triangleArrayLength = triangleArray.Length;
            int maxColCount = 0;
            while (triangleArrayLength > 0)
            {
                maxColCount++;
                triangleArrayLength -= maxColCount;
            }

            // Construct the triangle as a 2D array
            int[][] triangle = new int[maxColCount][];
            int rowNum = 1;
            int numIndex = 0;
            while (numIndex < triangleArray.Length)
            {
                triangle[rowNum - 1] = new int[rowNum];
                for (int i = 0; i < rowNum; i++)
                {
                    triangle[rowNum - 1][i] = triangleArray[numIndex + i];
                }
                numIndex += rowNum;
                rowNum++;
            }

            PrintTriangle(triangle);

            return triangle;
        }


        /// <summary>
        /// Calculate the greatest sum formed by traversing adjacent numbers from the top to the bottom of the triangle.
        /// </summary>
        /// <param name="originalTriangle">2D jagged array of positive integers representing the triangle.</param>
        /// <returns>The sum of the greatest path.</returns>
        /// 
        public static int CalculateGreatestPath(int[][] originalTriangle)
        {
            // Make a copy of the original triangle to prevent modifying the original
            int[][] triangle = (int[][])originalTriangle.Clone();

            for (int i = 0; i < triangle.Length; i++)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    // Retrieve the sum contained in the element above if it exists
                    // Top-most and right-most elements in the triangle do not have an element above it
                    int valueAbove = 0;
                    if (i - 1 >= 0)
                        if (j < triangle[i - 1].Length)
                            valueAbove = (int)triangle[i - 1][j];

                    // Retrieve the sum contained in the element to the top-left if it exists
                    // Left-most elements in the triangle (which includes the top element) do not have an element
                    //  that is adjacent in the top-left direction
                    int valueTopLeft = 0;
                    if (j - 1 >= 0)
                        valueTopLeft = (int)triangle[i - 1][j - 1];

                    // Compare the two path sums and add the greater path sum to the current element
                    if (valueAbove > valueTopLeft)
                        triangle[i][j] += valueAbove;
                    else
                        triangle[i][j] += valueTopLeft;
                }
            }

            PrintTriangle(triangle);

            // Examine the bottom row of the triangle and retrieve the greatest path sum
            int greatestSumPath = 0;
            for (int j = 0; j < triangle[triangle.Length - 1].Length; j++)
            {
                int currentPathValue = (int)triangle[triangle.Length - 1][j];
                if (currentPathValue > greatestSumPath)
                    greatestSumPath = currentPathValue;
            }

            return greatestSumPath;
        }


        /// <summary>
        /// Print out the contents of the triangle.
        /// </summary>
        /// <param name="triangle">2D jagged array of positive integers representing the triangle.</param>
        /// 
        public static void PrintTriangle(int[][] triangle)
        {
            for (int i = 0; i < triangle.Length; i++)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    Console.Write("{0} ", triangle[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
