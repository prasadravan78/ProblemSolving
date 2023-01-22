namespace _022PalindromePartitioning
{
    /*
    Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.

    Example 1:
    Input: s = "aab"
    Output: [["a","a","b"],["aa","b"]]

    Example 2:
    Input: s = "a"
    Output: [["a"]]
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Partition("aab").ToList().ForEach(k => k.ToList().ForEach(j => Console.Write(j)));
            Console.ReadLine();
        }

        public static IList<IList<string>> Partition(string s)
        {
            var response = new List<IList<string>>();

            for (var i = 1; i < s.Length; i++)
            {
                var s1 = s.Substring(0, i);

                if (IsPalindrome(s1))
                {
                    var s2 = s.Substring(i, s.Length - i);
                    response.AddRange(Partition(s2).Select(p => new[] { s1 }.Concat(p).ToList()));
                }
            }

            if (IsPalindrome(s))
            {
                response.Add(new List<string> { s });
            }

            return response;
        }

        private static bool IsPalindrome(string s)
        {
            for (var i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}