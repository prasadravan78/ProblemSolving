namespace _037ShuffleTheArray
{
    /*
    Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
    Return the array in the form [x1,y1,x2,y2,...,xn,yn]. 

    Example 1:
    Input: nums = [2,5,1,3,4,7], n = 3
    Output: [2,3,5,4,1,7] 
    Explanation: Since x1=2, x2=5, x3=1, y1=3, y2=4, y3=7 then the answer is [2,3,5,4,1,7].

    Example 2:
    Input: nums = [1,2,3,4,4,3,2,1], n = 4
    Output: [1,4,2,3,3,2,4,1]

    Example 3:
    Input: nums = [1,1,2,2], n = 2
    Output: [1,2,1,2] 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Shuffle(new int[] { 2, 5, 1, 3, 4, 7 }, 3).ToList().ForEach(k => Console.Write(k + " "));
            Console.ReadLine();
        }

        public static int[] Shuffle(int[] nums, int n)
        {
            var response = new int[nums.Length];
            var j = 0;
            var i = 0;

            while (i < nums.Length)
            {
                response[i] = nums[j];
                response[i + 1] = nums[n + j];
                i += 2;
                j++;
            }

            return response;
        }
    }
}