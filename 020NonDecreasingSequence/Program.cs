namespace _020NonDecreasingSequence
{
    /*
    Given an integer array nums, return all the different possible non-decreasing subsequences of the given array with at least two elements. 
    You may return the answer in any order. 

    Example 1:
    Input: nums = [4,6,7,7]
    Output: [[4,6],[4,6,7],[4,6,7,7],[4,7],[4,7,7],[6,7],[6,7,7],[7,7]]

    Example 2:
    Input: nums = [4,4,3,2,1]
    Output: [[4,4]]
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            FindSubsequences(new int[] { 4, 6, 7, 7 }).ToList().ForEach(k => k.ToList().ForEach(j => Console.WriteLine(j)));
            Console.ReadLine();
        }

        public static IList<IList<int>> FindSubsequences(int[] nums)
        {
            var response = new List<IList<int>>();

            DFS(nums, 0, new List<int>(), response);

            return response;
        }

        private static void DFS(int[] nums, int startIndex, List<int> oneResult, List<IList<int>> response)
        {
            var isVisited = new HashSet<int>();
            var n = nums.Length;

            if (oneResult.Count > 1)
            {
                response.Add(new List<int>(oneResult));
            }

            for (int i = startIndex; i < n; i++)
            {
                var cur = nums[i];

                if (isVisited.Contains(cur))
                {
                    continue;
                }

                if (!oneResult.Any() || oneResult.Last() <= cur)
                {
                    isVisited.Add(cur);
                    oneResult.Add(cur);
                    DFS(nums, i + 1, oneResult, response);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }
    }
}