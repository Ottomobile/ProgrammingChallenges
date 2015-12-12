/*
 * ProjectEuler.net
 * Question 7:  10001st Prime
 * Description: Find the 10001st prime number
 * Author:      Otto Lau
 * Date:        December 12, 2015
 */

using System;
using System.Diagnostics;

namespace PE007_10001st_Prime
{
    class PE007_10001st_Prime
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the nth prime to find:");
            int nthPrime = Int32.Parse(Console.ReadLine());

            // Method 1: Iterate through every number and determine if it is prime
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("Method 1: The {0}th prime is {1}.", nthPrime, FindPrime1(nthPrime));
            stopWatch.Stop();
            Console.WriteLine("\tElapsed Milliseconds: {0}", stopWatch.ElapsedMilliseconds);

            // Method 2: Iterate through numbers that are not multiples of 2 or 3
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine("Method 2: The {0}th prime is {1}.", nthPrime, FindPrime2(nthPrime));
            stopWatch.Stop();
            Console.WriteLine("\tElapsed Milliseconds: {0}", stopWatch.ElapsedMilliseconds);

            // Wait for the user to acknowledge results
            Console.ReadLine();
        }

        /// <summary>
        /// Finds the nth prime.
        /// </summary>
        /// <param name="nthPrime">The nth prime to find.</param>
        /// <returns>The prime number at the nth position of the sequence of prime numbers.</returns>
        /// 
        public static int FindPrime1(int nthPrime)
        {
            int numberOfPrimes = 0;
            int currentNumber = 0;
            while (numberOfPrimes <= nthPrime)
            {
                if (isPrime1(currentNumber))
                    numberOfPrimes++;
                currentNumber++;
            }

            return --currentNumber;
        }

        /// <summary>
        /// Determine if the given number is prime.
        /// </summary>
        /// <param name="number">A positive integer.</param>
        /// <returns>True if number is prime, false if otherwise.</returns>
        /// 
        public static bool isPrime1(int number)
        {
            if (number == 1)
                return false;

            if (number == 2)
                return true;

            for (int i = 2; i <= (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Finds the nth prime.
        /// </summary>
        /// <param name="nthPrime">The nth prime to find.</param>
        /// <returns>The prime number at the nth position of the sequence of prime numbers.</returns>
        /// 
        public static int FindPrime2(int nthPrime)
        {
            int numberOfPrimes = 0;
            int currentNumber = 0;
            while (numberOfPrimes <= nthPrime)
            {
                if (isPrime2(currentNumber))
                    numberOfPrimes++;
                currentNumber++;
            }

            return --currentNumber;
        }


        /// <summary>
        /// Determine if the given number is prime.
        /// </summary>
        /// <param name="number">A positive integer.</param>
        /// <returns>True if number is prime, false if otherwise.</returns>
        /// 
        public static bool isPrime2(int number)
        {
            if (number == 1)
                return false;

            // 2 and 3 are prime numbers
            if (number < 4)
                return true;

            // Multiples of 2 or multiples of 3 are not prime
            if(number % 2 == 0 || number % 3 == 0)
                return false;

            for (int i = 5; i <= (int)Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
