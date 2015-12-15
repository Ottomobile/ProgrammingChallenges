/*
 * ProjectEuler.net
 * Question 9:  Special Pythagorean Triplet
 * Description: Find the product of the Pythagorian triplet for which a + b + c = 1000
 * Author:      Otto Lau
 * Date:        December 14, 2015
 */

using System;

namespace PE009_Special_Pythagorian_Triplet
{
    class PE009_Special_Pythagorian_Triplet
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sum of the Pythagorian triplet:");
            int number = Int32.Parse(Console.ReadLine());

            productOfTripet(number);

            // Wait for user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Finds the product of the Pythagorian triplet that sum up to the input number.
        /// </summary>
        /// <param name="number">Sum of the three natural numbers that form the Pythagorian triplet.</param>
        /// <returns>The product of the Pythogorian triplet that sum up to the input number.
        ///     Returns null if the Pythagorian triplet does not exist.</returns>
        ///     
        public static int? productOfTripet(int number)
        {
            int b = 1;
            int c;
            while (b < number)
            {
                int a = 1;
                while (a < b)
                {
                    c = number - a - b;
                    double temp = Math.Sqrt(a * a + b * b);
                    if (temp == c)
                    {
                        Console.WriteLine("{0} * {1} * {2} = {3}", a, b, c, a * b * c);
                        return a * b * c;
                    }
                    a++;
                }
                b++;
            }
            return null;
        }
    }
}
