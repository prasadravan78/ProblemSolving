namespace _051SearchInsertPosition
{
    /*
    Given a sorted array of distinct integers and a target value, return the index if the target is found.
    If not, return the index where it would be if it were inserted in order.
    You must write an algorithm with O(log n) runtime complexity.

    Example 1:
    Input: nums = [1, 3, 5, 6], target = 5
    Output: 2
    
    Example 2:
    Input: nums = [1, 3, 5, 6], target = 2
    Output: 1
    
    Example 3:
    Input: nums = [1, 3, 5, 6], target = 7
    Output: 4
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SearchInsert(new int[] { 1, 3, 5, 6 }, 5));
            Console.ReadLine();
        }

        public static int SearchInsert(int[] nums, int target)
        {
            int minIndex = 0;
            int maxIndex = nums.Length - 1;

            while (minIndex <= maxIndex)
            {
                int midIndex = minIndex + (maxIndex - minIndex) / 2;

                if (nums[midIndex] == target)
                {
                    return midIndex;
                }
                else if (nums[midIndex] > target)
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    minIndex = midIndex + 1;
                }
            }

            return minIndex;
        }
    }
}