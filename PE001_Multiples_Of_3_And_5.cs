/*
 * ProjectEuler.net
 * Question 1:  Multiples of 3 and 5
 * Description: Find the sum of all the multiples of 3 or 5 below 1000.
 * Author:      Otto Lau
 * Date:        October 3, 2015
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace PE001_Multiples_Of_3_And_5
{
    class PE001_Multiples_Of_3_And_5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number to find multiples of:");
            int multiple1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number to find multiples of:");
            int multiple2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter maximum number that multiples should not exceed");
            int maxThreshold = Int32.Parse(Console.ReadLine());
            
            long sumOfMultiples = ComputeSumOfMultiples(multiple1, multiple2, maxThreshold);
            Console.WriteLine("Sum of multiples: {0}", sumOfMultiples);

            // Wait for user to acknowledge results
            Console.ReadLine();
        }

        /// <summary>
        /// Takes two numbers and finds the sum of their multiples up to a specified number.
        /// </summary>
        /// <param name="multiple1">A positive integer to find the multiples of.</param>
        /// <param name="multiple2">A positive integer to find the multiples of.</param>
        /// <param name="maxThreshold">Maximum number that multiples should not exceed.</param>
        /// <returns>Sum of the multiples that go up to the specified maximum value</returns>
        /// 
        public static long ComputeSumOfMultiples(int multiple1, int multiple2, int maxThreshold)
        {
            HashSet<int> multiples = new HashSet<int>();
            for (int i = multiple1; i < maxThreshold; i += multiple1)
                multiples.Add(i);

            int commonMultiple = multiple1 * multiple2;
            for (int i = commonMultiple; i < maxThreshold; i += commonMultiple)
                multiples.Remove(i);

            for (int i = multiple2; i < maxThreshold; i += multiple2)
                multiples.Add(i);

            return multiples.ToList<int>().Sum();
        }
    }
}
