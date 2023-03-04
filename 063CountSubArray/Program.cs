﻿namespace _063CountSubArray
{
    /*
    You are given an integer array nums and two integers minK and maxK.
    A fixed-bound subarray of nums is a subarray that satisfies the following conditions:

    The minimum value in the subarray is equal to minK.
    The maximum value in the subarray is equal to maxK.
    Return the number of fixed-bound subarrays.
    A subarray is a contiguous part of an array.

    Example 1:
    Input: nums = [1,3,5,2,7,5], minK = 1, maxK = 5
    Output: 2
    Explanation: The fixed-bound subarrays are [1,3,5] and [1,3,5,2].

    Example 2:
    Input: nums = [1,1,1,1], minK = 1, maxK = 1
    Output: 10
    Explanation: Every subarray of nums is a fixed-bound subarray. There are 10 possible subarrays. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountSubarrays(new int[] { 1, 3, 5, 2, 7, 5 }, 1, 5));
            Console.ReadLine();
        }

        public static long CountSubarrays(int[] nums, int minK, int maxK)
        {
            int minPosition = -1, maxPosition = -1, leftBound = -1;
            long answer = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == minK) minPosition = i;
                if (nums[i] == maxK) maxPosition = i;
                if (nums[i] < minK || nums[i] > maxK) leftBound = i;
                answer += Math.Max(0, Math.Min(maxPosition, minPosition) - leftBound);
            }

            return answer;
        }
    }
}