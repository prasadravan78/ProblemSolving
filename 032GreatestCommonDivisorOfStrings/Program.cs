namespace _032GreatestCommonDivisorOfStrings
{
    /*
    For two strings s and t, we say "t divides s" if and only if s = t + ... + t (i.e., t is concatenated with itself one or more times).
    Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.
    
    Example 1:
    Input: str1 = "ABCABC", str2 = "ABC"
    Output: "ABC"

    Example 2:
    Input: str1 = "ABABAB", str2 = "ABAB"
    Output: "AB"

    Example 3:
    Input: str1 = "LEET", str2 = "CODE"
    Output: ""  
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GcdOfStrings("ABCABC", "ABC"));
            Console.ReadLine();
        }

        public static string GcdOfStrings(string str1, string str2)
        {
            int l1 = str1.Length, l2 = str2.Length;

            if (l2 > l1)
            {
                (str1, str2) = (str2, str1);
            }

            for (int i = str2.Length; i > 0; i--)
            {
                string max = str2.Substring(0, i);
                string t1 = str1.Replace(max, "");
                string t2 = str2.Replace(max, "");

                if (string.IsNullOrEmpty(t1) && string.IsNullOrEmpty(t2))
                {
                    return max;
                }
            }

            return string.Empty;
        }
    }
}