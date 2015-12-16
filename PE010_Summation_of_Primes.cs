/*
 * ProjectEuler.net
 * Question 10: Summation of Primes
 * Description: Find the sum of all primes below two million
 * Author:      Otto Lau
 * Date:        December 15, 2015
 */

using System;

namespace PE010_Summation_of_Primes
{
    class PE010_Summation_of_Primes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number that the primes should not exceed:");
            int number = Int32.Parse(Console.ReadLine());

            Console.WriteLine("The sum of primes below {0} is {1}.", number, SieveOfEratosthenes(number));

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }

        /// <summary>
        /// Use the Sieve of Eratosthenes to calculate the sum of prime numbers below a given number.
        /// </summary>
        /// <param name="number">A positive integer that the primes should not exceed.</param>
        /// <returns>The sum of the prime numbers below the given number.</returns>
        /// 
        public static long SieveOfEratosthenes(int number)
        {
            // Initialize array of numbers as all prime (true) initially
            // Subtract 2 in the array size to exclude 1 and the input number
            bool[] numbers = new bool[number - 2];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = true;

            // Mark composite numbers as false
            for (int j = 2; j <= Math.Sqrt(number); j++)
            {
                for (int k = j * j; k < number; k += j)
                {
                    numbers[k - 2] = false;
                }
            }

            // Gather and sum all primes
            // Console.WriteLine("Prime numbers below {0}:", number);
            long sum = 0;
            for (int m = 0; m < numbers.Length; m++)
            {
                if (numbers[m])
                {
                    // Console.WriteLine("{0}", m + 2);
                    sum += (m + 2);
                }
            }
            return sum;
        }
    }
}
