namespace _039JumpGame
{
    /*
    You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].
    Each element nums[i] represents the maximum length of a forward jump from index i. In other words, 
    if you are at nums[i], you can jump to any nums[i + j] where: 0 <= j <= nums[i] and i + j < n
    Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].

    Example 1:
    Input: nums = [2,3,1,1,4]
    Output: 2
    Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
    
    Example 2:
    Input: nums = [2,3,0,1,4]
    Output: 2 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Jump(new int[] { 2, 3, 0, 1, 4 }));
            Console.ReadLine();
        }

        public static int Jump(int[] nums)
        {
            int count = 0;
            int max = 0;
            int current = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                max = Math.Max(max, i + nums[i]);

                if (i == current)
                {
                    count++;
                    current = max;
                }
            }

            return count;
        }
    }
}