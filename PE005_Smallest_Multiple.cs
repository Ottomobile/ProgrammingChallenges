/*
 * ProjectEuler.net
 * Question 5:  Smallest Multiple
 * Description: Find the smallest positive number that is divisible by all the numbers within a given range
 * Author:      Otto Lau
 * Date:        2015-12-07
 */

using System;
using System.Collections.Generic;

namespace PE005_Smallest_Multiple
{
    class PE005_Smallest_Multiple
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the smallest number the multiple is divisible by:");
            int minNum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the largest number the multiple is divisible by:");
            int maxNum = Int32.Parse(Console.ReadLine());

            int smallestMultiple = FindSmallestMultiple(minNum, maxNum);
            Console.WriteLine("The smallest common multiple of the consecutive numbers from {0} to {1} is: {2}", minNum, maxNum, smallestMultiple);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Finds the smallest multiple that is divisible by all the integers between two given numbers.
        /// </summary>
        /// <param name="minNum">A positive number - smallest value the multiple should be divisible by.</param>
        /// <param name="maxNum">A positive number - largest value the multiple should be divisible by.</param>
        /// <returns>The smallest multiple that is divisible by all the numbers within the specified range.</returns>
        /// 
        public static int FindSmallestMultiple(int minNum, int maxNum)
        {
            Dictionary<int, int> primeFactors = new Dictionary<int, int>();
            for (int i = minNum; i <= maxNum; i++)
            {
                Dictionary<int, int> primesOfCurrentNum = PrimeFactorize(i);
                foreach (int primeFactor in primesOfCurrentNum.Keys)
                {
                    if (!primeFactors.ContainsKey(primeFactor))
                    {
                        primeFactors.Add(primeFactor, primesOfCurrentNum[primeFactor]);
                    }
                    else
                    {
                        if (primesOfCurrentNum[primeFactor] > primeFactors[primeFactor])
                        {
                            primeFactors[primeFactor] = primesOfCurrentNum[primeFactor];
                        }
                    }
                }
            }

            int smallestMutliple = 1;
            Console.WriteLine("Prime factors of the smallest common multiple and their frequency:");
            foreach (int primeFactor in primeFactors.Keys)
            {
                Console.WriteLine("{0}: {1}", primeFactor, primeFactors[primeFactor]);
                smallestMutliple *= (int)Math.Pow(primeFactor, primeFactors[primeFactor]);
            }

            return smallestMutliple;
        }


        /// <summary>
        /// Prime factorize a number.
        /// </summary>
        /// <param name="number">A positive number.</param>
        /// <returns>A dictionary where the keys are prime factors and the 
        ///     values are their frequencies.</returns>
        ///             
        public static Dictionary<int, int> PrimeFactorize(int number)
        {
            Dictionary<int, int> primeFactors = new Dictionary<int, int>();

            int temp = number;
            int currentNumber = 2;
            while(currentNumber <= number)
            {
                if (isPrime(currentNumber))
                {
                    while (temp % currentNumber == 0)
                    {
                        temp /= currentNumber;
                        if (!primeFactors.ContainsKey(currentNumber))
                            primeFactors.Add(currentNumber, 1);
                        else
                            primeFactors[currentNumber] += 1;
                    }
                }
                currentNumber++;
            }
            return primeFactors;
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
