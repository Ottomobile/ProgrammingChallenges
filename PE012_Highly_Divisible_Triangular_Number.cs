/*
 * ProjectEuler.net
 * Question 12: Highly Divisible Triangular Number
 * Description: Find the first triangular number that has over 500 divisors
 * Author:      Otto Lau
 * Date:        December 16, 2015
 */

using System;

namespace PE012_Highly_Divisible_Triangular_Number
{
    class PE012_Highly_Divisible_Triangular_Number
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the minimum number of divisors the triangular number should have:");
            int numOfDivisors = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Method 2: The triangular number with at least {0} divisors is {1}.", numOfDivisors, FindTriNum2(numOfDivisors));
            Console.WriteLine("Method 1: The triangular number with at least {0} divisors is {1}.", numOfDivisors, FindTriNum1(numOfDivisors));

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Finds the triangular number that contains at least the specified number of divisors.
        /// Method 2: Use the fact that divisors are symmetric around the square root of a number 
        ///     to determine the number of divisors of the current triangular number.
        /// </summary>
        /// <param name="numOfDivisors">Minimum number of divisors the triangular number should possess.</param>
        /// <returns>The triangular number with at least the specified number of divisors.</returns>
        /// 
        public static int FindTriNum2(int numOfDivisors)
        {
            int currentTriNum = 1;
            int currentIncreaseNum = 2;

            while (true)
            {
                int countDivisors = 0;
                for (int i = 1; i < Math.Sqrt(currentTriNum); i++)
                {
                    if (currentTriNum % i == 0)
                    {
                        countDivisors++;
                        if (countDivisors * 2 > numOfDivisors)
                            return currentTriNum;
                    }
                }
                // Check if the triangular number is a perfect square (has one extra factor)
                if (currentTriNum % Math.Sqrt(currentTriNum) == 0 && countDivisors == numOfDivisors)
                {
                    return currentTriNum;
                }
                currentTriNum += currentIncreaseNum;
                currentIncreaseNum++;
            }
        }


        /// <summary>
        /// Finds the triangular number that contains at least the specified number of divisors.
        /// Method 1: Determine divisors by iterating up to and including the current triangular number.
        /// </summary>
        /// <param name="numOfDivisors">Minimum number of divisors the triangular number should possess.</param>
        /// <returns>The triangular number with at least the specified number of divisors.</returns>
        /// 
        public static int FindTriNum1(int numOfDivisors)
        {
            int currentTriNum = 1;
            int currentIncreaseNum = 2;

            while (true)
            {
                int countDivisors = 0;
                for (int i = 1; i <= currentTriNum; i++)
                {
                    if (currentTriNum % i == 0)
                    {
                        countDivisors++;
                        if (countDivisors > numOfDivisors)
                            return currentTriNum;
                    }
                }
                currentTriNum += currentIncreaseNum;
                currentIncreaseNum++;
            }
        }
    }
}
