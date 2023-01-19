namespace _019SubarraySums
{
    /*
    Given an integer array nums and an integer k, return the number of non-empty subarrays that have a sum divisible by k.
    A subarray is a contiguous part of an array.

    Example 1:
    Input: nums = [4,5,0,-2,-3,1], k = 5
    Output: 7
    Explanation: There are 7 subarrays with a sum divisible by k = 5:
    [4, 5, 0, -2, -3, 1], [5], [5, 0], [5, 0, -2, -3], [0], [0, -2, -3], [-2, -3]

    Example 2:
    Input: nums = [5], k = 9
    Output: 0 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SubarraysDivByK(new int[] { 4, 5, 0, -2, -3, 1 }, 5));
            Console.ReadLine();
        }

        public static int SubarraysDivByK(int[] nums, int k)
        {
            var dictionary = new Dictionary<int, int>();
            var sum = 0;

            foreach (var num in nums)
            {
                sum += num;
                var reminder = sum % k;

                if (reminder < 0)
                {
                    reminder = k + reminder;
                }

                dictionary[reminder] = dictionary.ContainsKey(reminder) ? dictionary[reminder] + 1 : 1;
            }

            var response = dictionary.ContainsKey(0) ? dictionary[0] : 0;

            foreach (var count in dictionary.Values)
            {
                response += count * (count - 1) >> 1;
            }

            return response;
        }
    }
}