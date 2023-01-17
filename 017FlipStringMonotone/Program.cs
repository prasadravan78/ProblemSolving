namespace _017FlipStringMonotone
{
    /*
    A binary string is monotone increasing if it consists of some number of 0's (possibly none), followed by some number of 1's (also possibly none).
    You are given a binary string s. You can flip s[i] changing it from 0 to 1 or from 1 to 0.
    Return the minimum number of flips to make s monotone increasing.

    Example 1:
    Input: s = "00110"
    Output: 1
    Explanation: We flip the last digit to get 00111.

    Example 2:
    Input: s = "010110"
    Output: 2
    Explanation: We flip to get 011111, or alternatively 000111.

    Example 3:
    Input: s = "00011000"
    Output: 2
    Explanation: We flip to get 00000000. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinFlipsMonoIncr("011111"));
            Console.ReadLine();
        }

        public static int MinFlipsMonoIncr(string s)
        {
            var zeroCount = s.Where(k => k == '0').Count();
            var flipCount = s.Length - zeroCount;
            var oneCount = 0;

            foreach (var ch in s)
            {
                if (ch == '0')
                {
                    zeroCount--;
                }
                else
                {
                    flipCount = Math.Min(flipCount, zeroCount + oneCount);
                    oneCount++;
                }
            }

            return flipCount;
        }
    }
}