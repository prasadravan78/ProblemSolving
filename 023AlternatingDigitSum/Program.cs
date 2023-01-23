namespace _023AlternatingDigitSum
{
    /*
    You are given a positive integer n. Each digit of n has a sign according to the following rules:
    The most significant digit is assigned a positive sign.
    Each other digit has an opposite sign to its adjacent digits.
    Return the sum of all digits with their corresponding sign.

    Example 1:
    Input: n = 521
    Output: 4
    Explanation: (+5) + (-2) + (+1) = 4.

    Example 2:
    Input: n = 111
    Output: 1
    Explanation: (+1) + (-1) + (+1) = 1.

    Example 3:
    Input: n = 886996
    Output: 0
    Explanation: (+8) + (-8) + (+6) + (-9) + (+9) + (-6) = 0. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AlternateDigitSum(111));
            Console.ReadLine();
        }

        public static int AlternateDigitSum(int n)
        {
            var nums1 = 0;
            var nums2 = 0;
            var count = 0;

            while (n > 0)
            {
                if (count % 2 == 0)
                {
                    nums2 += n % 10;
                }
                else
                {
                    nums1 += n % 10;
                }

                n = n / 10;
                count++;
            }

            if (count % 2 == 0)
            {
                return nums1 - nums2;
            }
            else
            {
                return nums2 - nums1;
            }
        }
    }
}