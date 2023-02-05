namespace _036AllAnagrams
{
    /*
    Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.
    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

    Example 1:
    Input: s = "cbaebabacd", p = "abc"
    Output: [0,6]
    Explanation:
    The substring with start index = 0 is "cba", which is an anagram of "abc".
    The substring with start index = 6 is "bac", which is an anagram of "abc".

    Example 2:
    Input: s = "abab", p = "ab"
    Output: [0,1,2]
    Explanation:
    The substring with start index = 0 is "ab", which is an anagram of "ab".
    The substring with start index = 1 is "ba", which is an anagram of "ab".
    The substring with start index = 2 is "ab", which is an anagram of "ab". 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindAnagrams("abab","ab"));
            Console.ReadLine();
        }

        public static IList<int> FindAnagrams(string s, string p)
        {
            int[] freq1 = new int[26], freq2 = new int[26];
            var result = new List<int>();

            foreach (var ch in p)
            {
                freq1[ch - 'a']++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                freq2[s[i] - 'a']++;

                if (i - p.Length >= 0)
                {
                    freq2[s[i - p.Length] - 'a']--;
                }

                if (i >= p.Length - 1 && IsEqual(freq1, freq2))
                {
                    result.Add(i - p.Length + 1);
                }
            }

            return result;
        }

        private static bool IsEqual(int[] freq1, int[] freq2)
        {
            for (int i = 0; i < freq1.Length; i++)
            {
                if (freq1[i] != freq2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}