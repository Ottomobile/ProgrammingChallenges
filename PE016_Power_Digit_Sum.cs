/*
 * ProjectEuler.net
 * Question 16: Power Digit Sum
 * Description: Find the sum of the digits of the number 2^1000
 * Author:      Otto Lau
 * Date:        December 18, 2015
 */

using System;
using System.Numerics;

namespace PE016_Power_Digit_Sum
{
    class PE016_Power_Digit_Sum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the base value:");
            int baseVal = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the exponent value:");
            int exponentVal = Int32.Parse(Console.ReadLine());

            int sumOfDigits = calculateSumOfDigits(baseVal, exponentVal);
            Console.WriteLine("The sum of digits of {0}^{1} is {2}.", baseVal, exponentVal, sumOfDigits);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Calcuates the sum of digits of the power.
        /// </summary>
        /// <param name="baseVal">Base value of the power.</param>
        /// <param name="exponentVal">Exponent value of the power.</param>
        /// <returns>The sum of the power's digits.</returns>
        /// 
        public static int calculateSumOfDigits(int baseVal, int exponentVal)
        {
            // Calculate the numeric value of the power
            BigInteger power = 1;
            for (int i = 1; i <= exponentVal; i++)
            {
                power *= baseVal;
            }

            // Sum the digits of the power
            int sumOfDigits = 0;
            while (power > 0)
            {
                sumOfDigits += (int)(power % 10);
                power /= 10;
            }

            return sumOfDigits;
        }
    }
}
