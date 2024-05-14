using System.Collections;

namespace _079SingleNumber
{
    /*
    Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
    You must implement a solution with a linear runtime complexity and use only constant extra space. 

    Example 1:
    Input: nums = [2,2,1]
    Output: 1

    Example 2:
    Input: nums = [4,1,2,1,2]
    Output: 4

    Example 3:
    Input: nums = [1]
    Output: 1
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingleNumber(new int[] { 4, 1, 2, 1, 2 }));
            Console.ReadKey();
        }

        public static int SingleNumber(int[] nums)
        {
            var hashtable = new Hashtable();
            var response = nums[0];

            for (var i = 0; i < nums.Length; i++)
            {
                if (hashtable.ContainsKey(nums[i]))
                {
                    hashtable.Remove(nums[i]);
                }
                else
                {
                    hashtable.Add(nums[i], nums[i]);
                }
            }

            foreach (var val in hashtable.Values)
            {
                response = Convert.ToInt32(val);
            }

            return response;
        }
    }
}
