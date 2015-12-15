/*
 * UNIT TESTS
 * ProjectEuler.net
 * Question 8:  Largest Product in a Series
 * Description: Find the greatest product formed by 13 adjacent digits in a 1000 digit number
 * Author:      Otto Lau
 * Date:        December 14, 2015
 */

using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PE008_Largest_Product_in_a_Series;

namespace PE008_Largest_Product_in_a_Series_Test
{
    [TestClass]
    public class PE008_Largest_Product_in_a_Series_Test
    {
        /// <summary>
        /// Greatest product is formed by the digits at the beginning of the number.
        /// </summary>
        [TestMethod]
        public void Test1_Beginning()
        {
            // Setup
            BigInteger number = new BigInteger(998004891);
            int numOfDigits = PE008_Largest_Product_in_a_Series_Class.GetNumOfDigits(number);
            int numOfAdjDigits = 3;

            // Execute
            BigInteger maxProduct = PE008_Largest_Product_in_a_Series_Class.MaxProductOfAdjacentDigits(number, numOfDigits, numOfAdjDigits);

            // Check
            Assert.AreEqual(648, maxProduct);
        }


        /// <summary>
        /// Greatest product is formed by digits in the middle of the number.
        /// </summary>
        [TestMethod]
        public void Test2_Middle()
        {
            // Setup
            BigInteger number = new BigInteger(15409981);
            int numOfDigits = PE008_Largest_Product_in_a_Series_Class.GetNumOfDigits(number);
            int numOfAdjDigits = 3;

            // Execute
            BigInteger maxProduct = PE008_Largest_Product_in_a_Series_Class.MaxProductOfAdjacentDigits(number, numOfDigits, numOfAdjDigits);

            // Check
            Assert.AreEqual(648, maxProduct);
        }


        /// <summary>
        /// Greatest product is formed by the last digits of the number.
        /// </summary>
        [TestMethod]
        public void Test3_End()
        {
            // Setup
            BigInteger number = new BigInteger(154097812998);
            int numOfDigits = PE008_Largest_Product_in_a_Series_Class.GetNumOfDigits(number);
            int numOfAdjDigits = 3;

            // Execute
            BigInteger maxProduct = PE008_Largest_Product_in_a_Series_Class.MaxProductOfAdjacentDigits(number, numOfDigits, numOfAdjDigits);

            // Check
            Assert.AreEqual(648, maxProduct);
        }
    }
}
