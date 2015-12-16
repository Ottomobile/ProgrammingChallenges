/*
 * ProjectEuler.net
 * Question 11: Largest Product in a Grid
 * Description: Find the greatest product of 4 adjacent numbers in a 20x20 grid
 * Author:      Otto Lau
 * Date:        December 15, 2015
 */

using System;

namespace PE011_Largest_Product_in_a_Grid
{
    class PE011_Largest_Product_in_a_Grid
    {
        public const int ROW_DIM = 0;
        public const int COL_DIM = 1;

        static void Main(string[] args)
        {
            int[,] array = new int[,] {
                {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48},
            };

            GreatestProduct(array);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Finds the greatest product of 4 adjacent numbers in a grid.  The numbers may be adjacent
        ///     horizontally, vertically, or diagonally.
        /// </summary>
        /// <param name="array">A square grid containing positive integers.</param>
        /// <returns>The greatest product of 4 adjacent numbers in the grid.</returns>
        /// 
        public static int GreatestProduct(int[,] array)
        {
            int[] startIndexOfMax = new int[2];
            Direction directionOfMax = Direction.None;
            int maxProduct = 0;

            // Check the horizontal direction of the array
            for (int i = 0; i < array.GetLength(ROW_DIM); i++)
            {
                for (int j = 0; j <= array.GetLength(COL_DIM) - 4; j++)
                {
                    int currentProduct = array[i, j] * array[i, j + 1] * array[i, j + 2] * array[i, j + 3];
                    if (currentProduct > maxProduct)
                    {
                        startIndexOfMax[ROW_DIM] = i;
                        startIndexOfMax[COL_DIM] = j;
                        directionOfMax = Direction.Horizontal;
                        maxProduct = currentProduct;
                    }
                }
            }

            // Check the vertical direction of the array
            for (int i = 0; i < array.GetLength(ROW_DIM) - 4; i++)
            {
                for (int j = 0; j < array.GetLength(COL_DIM); j++)
                {
                    int currentProduct = array[i, j] * array[i + 1, j] * array[i + 2, j] * array[i + 3, j];
                    if (currentProduct > maxProduct)
                    {
                        startIndexOfMax[ROW_DIM] = i;
                        startIndexOfMax[COL_DIM] = j;
                        directionOfMax = Direction.Vertical;
                        maxProduct = currentProduct;
                    }
                }
            }

            // Check the top-left to bottom-right direction of the array
            for (int i = 0; i <= array.GetLength(ROW_DIM) - 4; i++)
            {
                for (int j = 0; j <= array.GetLength(COL_DIM) - 4; j++)
                {
                    int currentProduct = array[i, j] * array[i + 1, j + 1] * array[i + 2, j + 2] * array[i + 3, j + 3];
                    if (currentProduct > maxProduct)
                    {
                        startIndexOfMax[ROW_DIM] = i;
                        startIndexOfMax[COL_DIM] = j;
                        directionOfMax = Direction.LTopRBottom;
                        maxProduct = currentProduct;
                    }
                }
            }

            // Check the top-right to bottom-left direction of the array
            for (int i = 0; i <= array.GetLength(ROW_DIM) - 4; i++)
            {
                for (int j = 3; j < array.GetLength(COL_DIM); j++)
                {
                    int currentProduct = array[i, j] * array[i + 1, j - 1] * array[i + 2, j - 2] * array[i + 3, j - 3];
                    if (currentProduct > maxProduct)
                    {
                        startIndexOfMax[ROW_DIM] = i;
                        startIndexOfMax[COL_DIM] = j;
                        directionOfMax = Direction.RTopLBottom;
                        maxProduct = currentProduct;
                    }
                }
            }

            switch (directionOfMax)
            {
                case Direction.Horizontal:
                    Console.WriteLine("The greatest product is in the horizontal direction.");
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM], array[startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM]]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM] + 1, array[startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM] + 1]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM] + 2, array[startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM] + 2]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM] + 3, array[startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM] + 3]);
                    Console.WriteLine("Greatest product of four adjacent numbers in the grid is: {0}", maxProduct);
                    break;
                case Direction.Vertical:
                    Console.WriteLine("The greatest product is in the vertical direction.");
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM], array[startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM]]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 1, startIndexOfMax[COL_DIM], array[startIndexOfMax[ROW_DIM] + 1, startIndexOfMax[COL_DIM]]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 2, startIndexOfMax[COL_DIM], array[startIndexOfMax[ROW_DIM] + 2, startIndexOfMax[COL_DIM]]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 3, startIndexOfMax[COL_DIM], array[startIndexOfMax[ROW_DIM] + 3, startIndexOfMax[COL_DIM]]);
                    Console.WriteLine("Greatest product of four adjacent numbers in the grid is: {0}", maxProduct);
                    break;
                case Direction.LTopRBottom:
                    Console.WriteLine("The greatest product is in the top-left to bottom-right direction.");
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM], array[startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM]]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 1, startIndexOfMax[COL_DIM] + 1, array[startIndexOfMax[ROW_DIM] + 1, startIndexOfMax[COL_DIM] + 1]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 2, startIndexOfMax[COL_DIM] + 2, array[startIndexOfMax[ROW_DIM] + 2, startIndexOfMax[COL_DIM] + 2]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 2, startIndexOfMax[COL_DIM] + 3, array[startIndexOfMax[ROW_DIM] + 3, startIndexOfMax[COL_DIM] + 3]);
                    Console.WriteLine("Greatest product of four adjacent numbers in the grid is: {0}", maxProduct);
                    break;
                case Direction.RTopLBottom:
                    Console.WriteLine("The greatest product is in the top-right to bottom-left direction.");
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM], array[startIndexOfMax[ROW_DIM], startIndexOfMax[COL_DIM]]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 1, startIndexOfMax[COL_DIM] - 1, array[startIndexOfMax[ROW_DIM] + 1, startIndexOfMax[COL_DIM] - 1]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 2, startIndexOfMax[COL_DIM] - 2, array[startIndexOfMax[ROW_DIM] + 2, startIndexOfMax[COL_DIM] - 2]);
                    Console.WriteLine("Index {0},{1}:\t{2}", startIndexOfMax[ROW_DIM] + 3, startIndexOfMax[COL_DIM] - 3, array[startIndexOfMax[ROW_DIM] + 3, startIndexOfMax[COL_DIM] - 3]);
                    Console.WriteLine("Greatest product of four adjacent numbers in the grid is: {0}", maxProduct);
                    break;
                default:
                    break;
            }

            return maxProduct;
        }
    }

    /// <summary>
    /// Used to indicate the direction of the greatest product in the array.
    /// </summary>
    public enum Direction : short
    {
        Horizontal,
        Vertical,
        LTopRBottom,
        RTopLBottom,
        None
    }
}
