/*
 * ProjectEuler.net
 * Question 17: Number Letter Counts
 * Description: For numbers 1 to 1000 inclusive written in words, find the total number of letters used
 * Author:      Otto Lau
 * Date:        December 16, 2015
 */

using System;
using System.Collections.Generic;

namespace PE017_Number_Letter_Counts
{
    public class PE017_Number_Letter_Counts_Class
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the mininum value of the range:");
            int min = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the maximum value of the range:");
            int max = Int32.Parse(Console.ReadLine());

            int totalLetterCount = numLettersUsedInRange(min, max);
            Console.WriteLine("The total number of letters used in the range from {0} to {1} is {2}.", min, max, totalLetterCount);

            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }


        /// <summary>
        /// Dictionary containing numbers and their letter counts.
        /// </summary>
        public const int AND = -1;
        public static Dictionary<int, int> numCharCount = new Dictionary<int, int>{
             {1,    String.Format("One").Length},
             {2,    String.Format("Two").Length},
             {3,    String.Format("Three").Length},
             {4,    String.Format("Four").Length},
             {5,    String.Format("Five").Length},
             {6,    String.Format("Six").Length},
             {7,    String.Format("Seven").Length},
             {8,    String.Format("Eight").Length},
             {9,    String.Format("Nine").Length},
             {10,   String.Format("Ten").Length},
             {11,   String.Format("Eleven").Length},
             {12,   String.Format("Twelve").Length},
             {13,   String.Format("Thirteen").Length},
             {14,   String.Format("Fourteen").Length},
             {15,   String.Format("Fifteen").Length},
             {16,   String.Format("Sixteen").Length},
             {17,   String.Format("Seventeen").Length},
             {18,   String.Format("Eighteen").Length},
             {19,   String.Format("Nineteen").Length},
             {20,   String.Format("Twenty").Length},
             {30,   String.Format("Thirty").Length},
             {40,   String.Format("Forty").Length},
             {50,   String.Format("Fifty").Length},
             {60,   String.Format("Sixty").Length},
             {70,   String.Format("Seventy").Length},
             {80,   String.Format("Eighty").Length},
             {90,   String.Format("Ninety").Length},
             {100,  String.Format("Hundred").Length},
             {1000, String.Format("Thousand").Length},
             {AND,  String.Format("And").Length}
        };


        /// <summary>
        /// Computes the total letter count of a range of numbers written in words.
        /// </summary>
        /// <param name="min">The minimum number of the range (inclusive).  Must be a positive integer.
        ///                   Number must be within the range 1-1000.</param>
        /// <param name="max">The maximum number of the range (inclusive).  Must be a positive integer.
        ///                   Number must be within the range 1-1000.</param>
        /// <returns>The total letter count of the range of numbers written out as words.</returns>
        /// 
        public static int numLettersUsedInRange(int min, int max)
        {
            int totalLetterCount = 0;
            for (int i = min; i <= max; i++)
            {
                totalLetterCount += numLettersInNumber(i);
            }
            return totalLetterCount;
        }


        /// <summary>
        /// For a number written out as a word, compute the total letters used.
        /// </summary>
        /// <param name="number">A positive integer in the range of 1-1000 inclusive.</param>
        /// <returns>The letter count of the number's word.</returns>
        /// 
        public static int numLettersInNumber(int number)
        {
            int numLetters = 0;

            // Extract digits of the number
            int[] digitArray = new int[4];
            for (int i = 0; i < 4; i++)
            {
                digitArray[i] = number % 10;
                number /= 10;
            }

            bool tensOnesPresent = false;

            // Number is between 10 and 19 inclusive have special names
            if (digitArray[1] == 1)
            {
                int currentNum = digitArray[1] * 10 + digitArray[0];
                numLetters += numCharCount[currentNum];
                tensOnesPresent = true;
            }
            // Add the letter count of the ones digit
            else if (digitArray[0] != 0)
            {
                numLetters += numCharCount[digitArray[0]];
                tensOnesPresent = true;
            }

            // Add the letter count of the tens digit (except when tens digit is one)
            if (digitArray[1] > 1)
            {
                numLetters += numCharCount[digitArray[1] * 10];
                tensOnesPresent = true;
            }

            // Add the letter count of the hundreds digit
            if (digitArray[2] > 0)
            {
                numLetters += numCharCount[digitArray[2]] + numCharCount[100];
                if (tensOnesPresent)
                    numLetters += numCharCount[AND];
            }

            // Add the letter count of the thousands digit
            if (digitArray[3] != 0)
            {
                numLetters += numCharCount[1000] + numCharCount[digitArray[3]];
            }

            return numLetters;
        }
    }
}
