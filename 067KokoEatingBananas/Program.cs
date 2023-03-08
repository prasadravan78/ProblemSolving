﻿namespace _067KokoEatingBananas
{
    /*
    Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
    Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. 
    If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.
    Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.
    Return the minimum integer k such that she can eat all the bananas within h hours.

    Example 1:
    Input: piles = [3,6,7,11], h = 8
    Output: 4

    Example 2:
    Input: piles = [30,11,23,4,20], h = 5
    Output: 30

    Example 3:
    Input: piles = [30,11,23,4,20], h = 6
    Output: 23
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinEatingSpeed(new int[] { 30, 11, 23, 4, 20 }, 6));
            Console.ReadLine();
        }

        public static int MinEatingSpeed(int[] piles, int h)
        {
            int high = piles.Max();
            int low = 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if (EatBananas(piles, mid, h))
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }

        public static bool EatBananas(int[] piles, int speed, int hour)
        {
            for (int index = 0; index < piles.Length; ++index)
            {
                int bananas = piles[index];

                int quotient = bananas / speed;
                int remainder = bananas % speed;

                hour -= quotient + (remainder == 0 ? 0 : 1);

                if (hour < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}