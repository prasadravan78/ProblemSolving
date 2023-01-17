namespace LengthOfLastWord
{
    /*
    Given a string s consisting of words and spaces, return the length of the last word in the string.
    A word is a maximal substring consisting of non-space characters only.

    Example 1:

    Input: s = "Hello World"
    Output: 5
    Explanation: The last word is "World" with length 5.
    Example 2:

    Input: s = "   fly me   to   the moon  "
    Output: 4
    Explanation: The last word is "moon" with length 4.
    Example 3:

    Input: s = "luffy is still joyboy"
    Output: 6
    Explanation: The last word is "joyboy" with length 6.     
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLastWord("   fly me   to   the moon  "));
            Console.ReadLine();
        }

        public static int LengthOfLastWord(string s)
        {
            s = s.TrimEnd();
            var count = s.Length - 1;

            while (count >= 0 && !Char.IsWhiteSpace(s[count]))
            {
                count--;
            }

            return s.Length - 1 - count;
        }
    }
}