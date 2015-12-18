/*
 * ProjectEuler.net
 * Question 14: Longest Collatz Sequence
 * Description: Find the starting number under one million that gives the longest sequence
 * Author:      Otto Lau
 * Date:        December 17, 2015
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace PE014_Longest_Collatz_Sequence
{
    class PE014_Longest_Collatz_Sequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number the starting number in the sequence should not exceed:");
            int maxStartingNum = Int32.Parse(Console.ReadLine());

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            BigInteger longestStartingNum2 = FindStartNum2(maxStartingNum);
            Console.WriteLine("For numbers under {0}, {1} as the starting number gives the longest sequence.", maxStartingNum, longestStartingNum2);
            stopWatch.Stop();
            Console.WriteLine("\tElapsed milliseconds: {0}", stopWatch.ElapsedMilliseconds);

            stopWatch.Reset();
            stopWatch.Start();
            BigInteger longestStartingNum1 = FindStartNum1(maxStartingNum);
            Console.WriteLine("For numbers under {0}, {1} as the starting number gives the longest sequence.", maxStartingNum, longestStartingNum1);
            stopWatch.Stop();
            Console.WriteLine("\tElapsed milliseconds: {0}", stopWatch.ElapsedMilliseconds);
            
            // Wait for the user to acknowledge the results
            Console.ReadLine();
        }

        
        /// <summary>
        /// Find the starting number under a given number that gives the longest Collatz sequence.
        /// Method 2: Use a dictionary to avoid repeated calculations of sequence numbers.
        /// </summary>
        /// <param name="maxStartingNum">A positive integer that the starting number should not exceed.</param>
        /// <returns>The starting number that gives the longest Collatz sequence.</returns>
        /// 
        public static BigInteger FindStartNum2(int maxStartingNum)
        {
            Dictionary<BigInteger, int> visitedNumbers = new Dictionary<BigInteger, int>();
            visitedNumbers.Add(1, 1);

            long startingNum = 1;
            while (startingNum < maxStartingNum)
            {
                if (!visitedNumbers.ContainsKey(startingNum))
                {
                    Stack<BigInteger> unvisitedNumbers = new Stack<BigInteger>();
                    unvisitedNumbers.Push(startingNum);
                    long numInSequence = startingNum;
                    int sequenceLength = 1;

                    // Generate the sequence of numbers until sequence meets a number already visited
                    while (numInSequence != 1 && !visitedNumbers.ContainsKey(numInSequence))
                    {
                        if (numInSequence % 2 == 0)
                            numInSequence /= 2;
                        else
                            numInSequence = 3 * numInSequence + 1;
                        sequenceLength++;
                        unvisitedNumbers.Push(numInSequence);
                    }

                    // When the sequence encounters an already visited number, get the sequence length of that
                    //  already visited number and use it to calculate the sequence lengths of the numbers
                    //  encountered in the current sequence
                    unvisitedNumbers.Pop();
                    int visitedSeqLength = visitedNumbers[numInSequence];
                    while (unvisitedNumbers.Count > 0)
                    {
                        BigInteger visitedNum = unvisitedNumbers.Pop();
                        visitedSeqLength++;
                        visitedNumbers.Add(visitedNum, visitedSeqLength);
                    }
                }
                startingNum++;
            }

            // Determine the starting number that has the longest sequence
            BigInteger longestStartingNum = 0;
            int longestStartNumSequenceLength = 0;
            foreach (BigInteger startingNumber in visitedNumbers.Keys)
            {
                if (startingNumber < maxStartingNum && visitedNumbers[startingNumber] > longestStartNumSequenceLength)
                {
                    longestStartingNum = startingNumber;
                    longestStartNumSequenceLength = visitedNumbers[startingNumber];
                }
            }
               
            return longestStartingNum;
        }


        /// <summary>
        /// Find the starting number under a given number that gives the longest Collatz sequence.
        /// Method 1: Iterate through each number and generate the sequence for each number.
        /// </summary>
        /// <param name="maxStartingNum">A positive integer that the starting number should not exceed.</param>
        /// <returns>The starting number that gives the longest Collatz sequence.</returns>
        /// 
        public static BigInteger FindStartNum1(int maxStartingNum)
        {
            int longestSequencelength = 1;
            int longestStartingNum = 1;
            int startingNum = 1;
            while (startingNum < maxStartingNum)
            {
                int sequenceLength = 1;
                BigInteger numInSequence = startingNum;
                //Console.Write(startingNum + ", ");
                while (numInSequence != 1)
                {
                    if (numInSequence % 2 == 0)
                    {
                        numInSequence /= 2;
                        //Console.Write(numInSequence + ", ");
                    }
                    else
                    {
                        numInSequence = 3 * numInSequence + 1;
                        //Console.Write(numInSequence + ", ");
                    }
                    sequenceLength++;
                }
                if (sequenceLength > longestSequencelength)
                {
                    longestSequencelength = sequenceLength;
                    longestStartingNum = startingNum;
                }
                //Console.WriteLine("Starting Number: {0}\tSequence Length: {1}", startingNum, sequenceLength);
                startingNum++;
            }
            return longestStartingNum;
        }
    }
}
