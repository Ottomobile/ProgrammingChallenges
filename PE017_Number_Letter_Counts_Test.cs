/*
 * UNIT TESTS
 * ProjectEuler.net
 * Question 17: Number Letter Counts
 * Description: For numbers 1 to 1000 inclusive written in words, find the total number of letters used
 * Author:      Otto Lau
 * Date:        December 16, 2015
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PE017_Number_Letter_Counts;

namespace PE017_Number_Letter_Counts_Test
{
    [TestClass]
    public class PE017_Number_Letter_Counts_Test
    {
        /// <summary>
        /// Test numbers 1 to 9.
        /// </summary>
        [TestMethod]
        public void Numbers_001_to_009()
        {
            for (int number = 1; number <= 9; number++)
            {
                int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(number);
                int expectedLetterCount = PE017_Number_Letter_Counts_Class.numCharCount[number];
                Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
            }
        }


        /// <summary>
        /// Test numbers 10 to 20.
        /// </summary>
        [TestMethod]
        public void Numbers_010_to_020()
        {
            for (int number = 10; number <= 20; number++)
            {
                int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(number);
                int expectedLetterCount = PE017_Number_Letter_Counts_Class.numCharCount[number];
                Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
            }
        }


        /// <summary>
        /// Test multiples of 10 between 20 to 90 inclusive.
        /// </summary>
        [TestMethod]
        public void Numbers_0X1()
        {
            for (int number = 20; number <= 90; number += 10)
            {
                int expectedLetterCount = PE017_Number_Letter_Counts_Class.numCharCount[number] + PE017_Number_Letter_Counts_Class.numCharCount[1];
                int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(number + 1);
                Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
            }
        }


        /// <summary>
        /// Test multiples of 100 under 1000.
        /// </summary>
        [TestMethod]
        public void Numbers_X00()
        {
            for (int number = 100; number <= 900; number += 100)
            {
                int expectedLetterCount = PE017_Number_Letter_Counts_Class.numCharCount[number / 100] + PE017_Number_Letter_Counts_Class.numCharCount[100];
                int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(number);
                Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
            }
        }


        /// <summary>
        /// Test multiples of 1000 under 10000.
        /// </summary>
        [TestMethod]
        public void Numbers_X000()
        {
            for (int number = 1000; number <= 9000; number += 1000)
            {
                int expectedLetterCount = PE017_Number_Letter_Counts_Class.numCharCount[number / 1000] + PE017_Number_Letter_Counts_Class.numCharCount[1000];
                int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(number);
                Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
            }
        }


        /// <summary>
        /// Test a number in the hundreds with the last two digits being in the range of 10-20 exclusive.
        /// </summary>
        [TestMethod]
        public void Numbers_512()
        {
            int expectedLetterCount = String.Format("FiveHundredAndTwelve").Length;
            int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(512);
            Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
        }


        /// <summary>
        /// Test a number in the hundreds that has a 0 for the tens digit and a non-zero value for the ones digit.
        /// </summary>
        [TestMethod]
        public void Numbers_206()
        {
            int expectedLetterCount = String.Format("TwoHundredAndSix").Length;
            int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(206);
            Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
        }


        /// <summary>
        /// Test a random number that follows the regular naming convention.
        /// </summary>
        [TestMethod]
        public void Numbers_999()
        {
            int expectedLetterCount = String.Format("NineHundredAndNinetyNine").Length;
            int calculatedLetterCount = PE017_Number_Letter_Counts_Class.numLettersInNumber(999);
            Assert.AreEqual(expectedLetterCount, calculatedLetterCount);
        }
    }
}
