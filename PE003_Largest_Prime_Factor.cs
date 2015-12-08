/*
 * ProjectEuler.net
 * Question 3:  Largest Prime Factor
 * Description: Determine the largest prime factor of a given number
 * Author:      Otto Lau
 * Date:        December 6, 2015
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace PE003_Largest_Prime_Factor
{
    class PE003_Largest_Prime_Factor
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a positive integer:");
            long number = Int64.Parse(Console.ReadLine());

            // Method 1: Use prime factorization
            Console.WriteLine("Method 1: Greatest prime factor of {0} is {1}.", number, findLargestPrime1(number));

            // Method 2: Iterate through half of numbers sqrt(<number>)-<number>,
            //  then divide by those numbers to get the remaining factors
            Console.WriteLine("Method 2: Greatest prime factor of {0} is {1}.", number, findLargestPrime2(number));

            // Method 3: Iterate through all numbers 1-<number>
            Console.WriteLine("Method 3: Greatest prime factor of {0} is {1}.", number, findLargestPrime3(number));

            // Wait for user to acknowledge the output
            Console.ReadLine();
        }


        /// <summary>
        /// Find the greatest prime factor of a given number.
        /// Method 3: Use prime factorization.
        /// </summary>
        /// <param name="number">A positive integer.</param>
        /// <returns>Greatest prime factor of the input number.
        ///     Returns null if greatest prime factor cannot be found.</returns>
        /// 
        public static long? findLargestPrime1(long number)
        {
            List<long> primeFactors = new List<long>();
            for(int i = 2; i <= number; i++)
            {
                if (isPrime(i))
                {
                    while (number % i == 0)
                    {
                        number /= i;
                        if (!primeFactors.Contains(i))
                            primeFactors.Add(i);
                    }
                }
            }

            if (primeFactors.Count > 0)
                return primeFactors.Max();
            else
                return null;
        }


        /// <summary>
        /// Find the greatest prime factor of a given number.
        /// Method 2: Use symmetry to find factors of the numbers.
        /// </summary>
        /// <param name="number">A positive integer.</param>
        /// <returns>Greatest prime number of the input number.
        ///     Returns null if greatest prime factor cannot be found.</returns>
        /// 
        public static long? findLargestPrime2(long number)
        {
            List<long> factors = new List<long>();

            // If number is a perfect square, add its square root to the list of factors
            double root = Math.Sqrt(number);
            long integerPart = (long)root;
            double decimalPart = root - integerPart;
            bool rootIsPrime = false;

            if (decimalPart == 0)
            {
                if (isPrime((long)integerPart))
                    rootIsPrime = true;
            }

            // Iterate through numbers sqrt(number) to number to find factors
            for (long i = number; i >= integerPart + 1; i--)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                    if (isPrime(i))
                        return i;
                }
            }

            if (rootIsPrime)
                return integerPart;

            // Divide number by the greater factors to find their corresponding lower factors
            //  In the factors list, smaller factors will be at the back of the array and so
            //  iterate factors list from the back to get the corresponding lower factors in
            //  descending order
            for (int i = factors.Count - 1; i >= 0; i--)
            {
                long correspondingFactor = number / factors[i];
                if (isPrime(correspondingFactor))
                    return correspondingFactor;
            }

            // Return null if greatest prime factor not found
            return null;
        }


        /// <summary>
        /// Find the greatest prime factor of a given number.
        /// Method 3: Iterates through all the numbers to find factors.
        /// </summary>
        /// <param name="number">A positive integer.</param>
        /// <returns>Greatest prime factor of the input number.
        ///     Returns null if greatest prime factor cannot be found.</returns>
        /// 
        public static long? findLargestPrime3(long number)
        {
            // Get all the factors of the given number
            long currentNumber = number;
            while (currentNumber >= 2)
            {
                if (number % currentNumber == 0)
                {
                    if (isPrime(currentNumber))
                        return currentNumber;
                }
                currentNumber--;
            }
            
            // Cannot find the greatest prime factor
            return null;
        }


        /// <summary>
        /// Determine if a number is prime.
        /// </summary>
        /// <param name="factor">A positive integer.</param>
        /// <returns>True if the number is prime, false otherwise.</returns>
        /// 
        public static bool isPrime(long number)
        {
            if (number == 1)
                return false;
            if (number == 2)
                return true;

            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
