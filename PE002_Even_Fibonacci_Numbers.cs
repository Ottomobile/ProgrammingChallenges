/*
 * ProjectEuler.net
 * Question 2:  Even Fibonacci Numbers
 * Description: Determine the sum of even Fibonacci Numbers under 4,000,000
 * Author:      Otto Lau
 * Date:        December 3, 2015
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace PE002_Even_Fibonacci_Numbers
{
    class PE002_Even_Fibonacci_Numbers
    {
        static void Main(string[] args)
        {
            int firstNum = 1;
            int secondNum = 2;

            Console.WriteLine("Enter the maximum number that the Fibonacci sequence should not exceed:");
            int maxNum = Int32.Parse(Console.ReadLine());

            // Method 1
            List<int> fibonacciNumbers1 = GenerateFibonacciNumbers(firstNum, secondNum, maxNum);
            int sum1 = fibonacciNumbers1.Where(num => num % 2 == 0).Sum();
            Console.WriteLine("Method 1: Sum of the even Fibonacci numbers under {0}: {1}", maxNum, sum1);

            // Method 2 Recursion
            List<int> fibonacciNumbers2 = new List<int>();
            fibonacciNumbers2.Add(firstNum);
            GenerateFibonacciNumbersRecursive(firstNum, secondNum, maxNum, fibonacciNumbers2);
            int sum2 = fibonacciNumbers2.Where(num => num % 2 == 0).Sum();
            Console.WriteLine("Method 2: Sum of the even Fibonacci numbers under {0}: {1}", maxNum, sum2);

            // Wait for user to acknowledge results
            Console.ReadLine();
        }


        /// <summary>
        /// Generates a list of Fibonacci numbers under the specified maximum value
        /// </summary>
        /// <param name="firstNum">First number of Fibonacci sequence</param>
        /// <param name="secondNum">Second number of Fibonacci sequence</param>
        /// <param name="maxNum">Maximum number that the sequence should not exceed</param>
        /// <returns>List of Fibonacci numbers under the specified maximum value</returns>
        /// 
        public static List<int> GenerateFibonacciNumbers(int firstNum, int secondNum, int maxNum)
        {
            List<int> fibonacciNumbers = new List<int>();
            fibonacciNumbers.Add(firstNum);

            int temp;
            while (secondNum < maxNum)
            {
                fibonacciNumbers.Add(secondNum);
                temp = firstNum;
                firstNum = secondNum;
                secondNum += temp;
            }

            return fibonacciNumbers;
        }


        /// <summary>
        /// Recursive approach of generating Fibonacci numbers under a specified maximum value
        /// </summary>
        /// <param name="firstNum">The previous Fibonacci number</param>
        /// <param name="secondNum">The current Fibonacci number</param>
        /// <param name="maxNum">Maximum number that the sequence should not exceed</param>
        /// <param name="fibNums">List of Fibonacci numbers under the specified maximum value</param>
        /// 
        public static void GenerateFibonacciNumbersRecursive(int firstNum, int secondNum, int maxNum, List<int> fibNums)
        {
            if (secondNum > maxNum)
                return;

            fibNums.Add(secondNum);
            GenerateFibonacciNumbersRecursive(secondNum, firstNum + secondNum, maxNum, fibNums);
        }
    }
}
