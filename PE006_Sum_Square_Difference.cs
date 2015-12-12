/*
 * ProjectEuler.net
 * Question 6:  Sum Square Difference
 * Description: Find the difference between the square of sum and sum of squares for the first n natural numbers.
 * Author:      Otto Lau
 * Date:        December 12, 2015
 */

using System;

namespace PE006_Sum_Square_Difference
{
    class PE006_Sum_Square_Difference
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a natural number:");
            int number = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Difference between the square of sum and sum of squares for the first {0} natural numbers is {1}.", number, difference(number));

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Finds the difference between the square of sum and sum of squares for the first
        ///     n natural numbers.
        /// </summary>
        /// <param name="maxNum">The first n natural numbers to consider.</param>
        /// <returns>The difference between the square of sum and the sum of squares.</returns>
        /// 
        public static int difference(int maxNum)
        {
            int sumOfSquares = 0;
            int squareOfSum = 0;
            for (int i = 1; i <= maxNum; i++)
            {
                sumOfSquares += (int)Math.Pow(i, 2);
                squareOfSum += i;
            }
            return (int)Math.Pow(squareOfSum, 2) - sumOfSquares;
        }
    }
}
