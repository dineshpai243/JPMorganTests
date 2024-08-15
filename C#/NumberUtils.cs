using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorganTests
{
    /*
     * """
        Problem 2:

        Write a function that accept a number and returns the starting position of the longest continuous sequence of 1s in its binary format.

        Examples:
        Case 1:
        Input : 156
        Output : 4
        Explanation: 156 when converted to binary, the result will be 10011100 and the maximum continuous 1s are starting at 4th position

        Case 2:
        Input : 88
        Output : 3
        Explanation : 88’s binary representation is 1011000 and the maximum continuous 1s occur at position 3.
        """

        """
        ASSUMPTIONS:
        Number is a Positive integer.

        Approach:
        The number is parsed from the least bit to the right, till the number is 0. The start index is adjusted with the bitLength
        to provide the right index with the first prominent bit as index 1 as stated in the requirements
        """
     */
    public class NumberUtils
    {
        public static int GetPositionOfMaxOnes(int number)
        {
            if (number <= 0) return 0;

            int maxOnes = 0;
            int currentOnes = 0;
            int maxOnesIndex = -1;
            int currentStartIndex = 0;
            int bitLength = (int)Math.Log2(number) + 1;
            int index = 0;

            while (number > 0)
            {
                if (number%2 == 1)
                {
                    currentOnes++;
                    if (currentOnes == 1)
                    {
                        currentStartIndex = index;
                    }

                }
                else
                {
                    currentOnes = 0;
                }
                if (currentOnes >= maxOnes)
                {
                    maxOnes = currentOnes;
                    maxOnesIndex = currentStartIndex;
                }
                number = number / 2;
                index++;
            }

            // Caclulating the index from left to right
            if (maxOnesIndex != -1)
            {
                maxOnesIndex = bitLength - (maxOnesIndex + maxOnes - 1);
            }

            return maxOnesIndex;
        }
    }
}
