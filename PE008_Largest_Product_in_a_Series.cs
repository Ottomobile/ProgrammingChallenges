/*
 * ProjectEuler.net
 * Question 8:  Largest Product in a Series
 * Description: Find the greatest product formed by 13 adjacent digits in a 1000 digit number
 * Author:      Otto Lau
 * Date:        December 14, 2015
 */

using System;
using System.Numerics;
using System.Text;

namespace PE008_Largest_Product_in_a_Series
{
    public class PE008_Largest_Product_in_a_Series_Class
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter in a positive integer:");
            //BigInteger number = BigInteger.Parse(Console.ReadLine());
            
            // 1000-digit number to examine
            StringBuilder target = new StringBuilder();
            target.Append("73167176531330624919225119674426574742355349194934");
            target.Append("96983520312774506326239578318016984801869478851843");
            target.Append("85861560789112949495459501737958331952853208805511");
            target.Append("12540698747158523863050715693290963295227443043557");
            target.Append("66896648950445244523161731856403098711121722383113");
            target.Append("62229893423380308135336276614282806444486645238749");
            target.Append("30358907296290491560440772390713810515859307960866");
            target.Append("70172427121883998797908792274921901699720888093776");
            target.Append("65727333001053367881220235421809751254540594752243");
            target.Append("52584907711670556013604839586446706324415722155397");
            target.Append("53697817977846174064955149290862569321978468622482");
            target.Append("83972241375657056057490261407972968652414535100474");
            target.Append("82166370484403199890008895243450658541227588666881");
            target.Append("16427171479924442928230863465674813919123162824586");
            target.Append("17866458359124566529476545682848912883142607690042");
            target.Append("24219022671055626321111109370544217506941658960408");
            target.Append("07198403850962455444362981230987879927244284909188");
            target.Append("84580156166097919133875499200524063689912560717606");
            target.Append("05886116467109405077541002256983155200055935729725");
            target.Append("71636269561882670428252483600823257530420752963450");
            BigInteger number = BigInteger.Parse(target.ToString());

            Console.WriteLine("Enter the number of adjacent digits that should form the maximum product:");
            int numOfAdjDigits = Int32.Parse(Console.ReadLine());

            BigInteger maxProduct = MaxProductOfAdjacentDigits(number, GetNumOfDigits(number), numOfAdjDigits);
            Console.WriteLine("The greatest product of {0} adjacent digits in the number {1} is {2}.", numOfAdjDigits, number, maxProduct);
            
            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Get the number of digits of a given number.
        /// </summary>
        /// <param name="number">The positive integer to examine.</param>
        /// <returns>The number of digits possessed by the positive integer.</returns>
        /// 
        public static int GetNumOfDigits(BigInteger number)
        {
            int numOfDigits = 0;
            while (number > 0)
            {
                number /= 10;
                numOfDigits++;
            }
            return numOfDigits;
        }


        /// <summary>
        /// Find the greatest product of x adjacent digits in a given number.
        /// </summary>
        /// <param name="number">The positive integer where the digits will be examined.</param>
        /// <param name="numOfDigits">The number of digits possessed by the positive integer under analysis.</param>
        /// <param name="numOfAdjDigits">The number of adjacent digits that will be used to form the product.</param>
        /// <returns>The greatest product formed by x adjacent digits in the given number.</returns>
        /// 
        public static BigInteger MaxProductOfAdjacentDigits(BigInteger number, int numOfDigits, int numOfAdjDigits)
        {
            BigInteger maxProduct = 0;
            int digitIndex = numOfDigits;
            while (digitIndex >= numOfAdjDigits)
            {
                int index = 1;
                BigInteger currentProduct = 1;
                BigInteger clone = number;
                while (index <= numOfAdjDigits)
                {
                    int currentDigit = (int)(clone % 10);
                    if (currentDigit == 0)
                    {
                        // Skip current set of adjacent digits and go to the digit following 0
                        // Add one because digitIndex will be decremented outside of this loop
                        digitIndex = digitIndex - index + 1;
                        currentProduct = 0;
                        number = clone;
                        break;
                    }
                    else
                    {
                        clone /= 10;
                        currentProduct *= currentDigit;
                        index++;
                    }
                }
                if (currentProduct > maxProduct)
                {
                    maxProduct = currentProduct;
                }
                number /= 10;
                digitIndex--;
            }
            return maxProduct;
        }
    }
}
