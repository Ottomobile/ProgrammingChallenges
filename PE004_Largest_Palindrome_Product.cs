/*
 * ProjectEuler.net
 * Question 4:  Largest Palindrome Product
 * Description: Given two x-digit numbers, find the largest product that is a palindrome
 * Author:      Otto Lau
 * Date:        December 12, 2015
 */

using System;

namespace PE004_Largest_Palindrome_Product
{
    class PE004_Largest_Palindrome_Product
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of digits of the multiplicands:");
            int numOfDigits = Int32.Parse(Console.ReadLine());

            // Find the greatest multiplicand that has the given number of digits
            char[] maxNumForDigits = new char[numOfDigits];
            for (int i = 0; i < numOfDigits; i++)
            {
                maxNumForDigits[i] = '9';
            }
            int maxNum = Int32.Parse(new string(maxNumForDigits));

            // Find the smallest multiplicand that has the given number of digits
            char[] minNumForDigits = new char[numOfDigits];
            minNumForDigits[0] = '1';
            for (int i = 1; i < numOfDigits; i++)
            {
                minNumForDigits[i] = '0';
            }
            int minNum = Int32.Parse(new string(minNumForDigits));

            // Determine the largest palindrome product from two x-digit numbers
            largestPalindromeProduct1(maxNum, minNum);
            largestPalindromeProduct2(maxNum, minNum);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Find the largest palindrome that is a product of two x-digit numbers.
        /// </summary>
        /// <param name="maxNum">Maximum value of multiplicand (natural number).</param>
        /// <param name="minNum">Minimum value of multiplicand (natural number).</param>
        /// <returns>The largest palindrome that is a product of two numbers within the ranges of
        ///             the minimum and maximum values.</returns>
        /// 
        public static int largestPalindromeProduct1(int maxNum, int minNum)
        {
            Console.WriteLine("Max Multiplicand: {0}\nMin Multiplicand: {1}", maxNum, minNum);
            int multiplicand1 = 0;
            int multiplicand2 = 0;
            int largestPalindromeProduct = 0;
            for (int j = maxNum; j >= minNum; j--)
            {
                for (int k = maxNum; k >= minNum; k--)
                {
                    int product = j * k;
                    if (isPalindrome1(product))
                    {
                        if (product > largestPalindromeProduct)
                        {
                            largestPalindromeProduct = product;
                            multiplicand1 = j;
                            multiplicand2 = k;
                        }
                    }
                }
            }
            Console.WriteLine("Largest palindrome = {0} * {1} = {2}", multiplicand1, multiplicand2, largestPalindromeProduct);
            return largestPalindromeProduct;
        }


        /// <summary>
        /// Determines if a number is a palindrome (reads the same both ways).
        /// </summary>
        /// <param name="number">Number to test if it is a palindrome.</param>
        /// <returns>True if the number is a palindrome, false if not.</returns>
        /// 
        public static bool isPalindrome1(int number)
        {
            string numberAsString = number.ToString();
            int i = 0;
            int j = numberAsString.Length - 1;

            while (i <= j && j >= i)
            {
                if (numberAsString[i] != numberAsString[j])
                    return false;

                i++;
                j--;
            }
            return true;
        }


        /// <summary>
        /// Find the largest palindrome that is a product of two x-digit numbers.
        /// </summary>
        /// <param name="maxNum">Maximum value of multiplicand (natural number).</param>
        /// <param name="minNum">Minimum value of multiplicand (natural number).</param>
        /// <returns>The largest palindrome that is a product of two numbers within the ranges of
        ///             the minimum and maximum values.</returns>
        /// 
        public static int largestPalindromeProduct2(int maxNum, int minNum)
        {
            Console.WriteLine("Max Multiplicand: {0}\nMin Multiplicand: {1}", maxNum, minNum);
            int multiplicand1 = 0;
            int multiplicand2 = 0;
            int largestPalindromeProduct = 0;
            for (int j = maxNum; j >= minNum; j--)
            {
                // Assume that one number is equal to or less than the other to avoid checking duplicates
                int k = j;
                // If the current product at the start of the inner loop is less than the largest palindromic product
                //  then the following products will be guaranteed less than the largest palindromic product and do
                //  not need to be considered
                if (j * k < largestPalindromeProduct)
                    break;
                while (k >= minNum)
                {
                    int product = j * k;
                    if (isPalindrome2(product))
                    {
                        if (product > largestPalindromeProduct)
                        {
                            largestPalindromeProduct = product;
                            multiplicand1 = j;
                            multiplicand2 = k;
                        }
                    }
                    k--;
                }
            }
            Console.WriteLine("Largest palindrome = {0} * {1} = {2}", multiplicand1, multiplicand2, largestPalindromeProduct);
            return largestPalindromeProduct;
        }


        /// <summary>
        /// Determines if a number is a palindrome (reads the same both ways).
        /// </summary>
        /// <param name="number">Number to test if it is a palindrome.</param>
        /// <returns>True if the number is a palindrome, false if not.</returns>
        /// 
        public static bool isPalindrome2(int number)
        {
            int clone = number;
            int reversedNum = 0;
            while (clone > 0)
            {
                // Shift the previous digit left and append the current digit to the end of it
                reversedNum = reversedNum * 10 + clone % 10;
                clone /= 10;
            }
            // If the number and the reversed number are same, the number is a palindrome
            if (number == reversedNum)
                return true;
            else
                return false;
        }
    }
}
