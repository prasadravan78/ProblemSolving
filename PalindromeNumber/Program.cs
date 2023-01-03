namespace PalindromeNumber
{
    /*
    Given an integer x, return true if x is a palindrome, and false otherwise.

    Example 1:

    Input: x = 121
    Output: true
    Explanation: 121 reads as 121 from left to right and from right to left.
    Example 2:

    Input: x = -121
    Output: false
    Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
    Example 3:

    Input: x = 10
    Output: false
    Explanation: Reads 01 from right to left. Therefore it is not a palindrome. 

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            if (IsPalindrome(-121))
            {
                Console.WriteLine("Number is a Palindrome");
            }
            else
            {
                Console.WriteLine("Number is not a Palindrome");
            }

            Console.ReadLine();
        }

        public static bool IsPalindrome(int x)
        {
            var reversedNumber = 0;
            var parameter = x;

            while (parameter > 0)
            {
                reversedNumber = reversedNumber * 10 +(parameter % 10);
                parameter = parameter / 10;
            }

            if (x == reversedNumber)
            {
                return true;
            }

            return false;
        }
    }
}