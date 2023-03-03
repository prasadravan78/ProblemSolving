namespace _062FirstOccurrenceInString
{
    /*
    Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

    Example 1:
    Input: haystack = "sadbutsad", needle = "sad"
    Output: 0
    Explanation: "sad" occurs at index 0 and 6.
    The first occurrence is at index 0, so we return 0.

    Example 2:
    Input: haystack = "leetcode", needle = "leeto"
    Output: -1
    Explanation: "leeto" did not occur in "leetcode", so we return -1. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StrStr("sadbutsad", "sad"));
            Console.ReadLine();
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }

            if (haystack.Contains(needle))
            {
                for (int i = 0; i < haystack.Length; i++)
                {
                    if (needle.Equals(haystack.Substring(i, needle.Length)))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}