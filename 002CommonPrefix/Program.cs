using System.Text;

namespace CommonPrefix
{
    /*
    Write a function to find the longest common prefix string amongst an array of strings.
    If there is no common prefix, return an empty string "". 

    Example 1:

    Input: strs = ["flower","flow","flight"]
    Output: "fl"
    Example 2:

    Input: strs = ["dog","racecar","car"]
    Output: ""
    Explanation: There is no common prefix among the input strings.

    Constraints:

    1 <= strs.length <= 200
    0 <= strs[i].length <= 200
    strs[i] consists of only lowercase English letters.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            Console.ReadLine();
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            var longestPrefix = new StringBuilder();
            var shortestString = strs.OrderBy(k => k.Length).FirstOrDefault();
            var i = 0;

            if (!string.IsNullOrEmpty(shortestString))
            {
                foreach (char ch in shortestString)
                {
                    if (strs.Any(k => k[i] != ch))
                    {
                        break;
                    }

                    longestPrefix.Append(ch);
                    i++;
                }
            }

            return longestPrefix.ToString();
        }
    }
}