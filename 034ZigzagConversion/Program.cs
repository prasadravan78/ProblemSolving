namespace _034ZigzagConversion
{
    /*
    The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font 
    for better legibility)

    P   A   H   N
    A P L S I I G
    Y   I   R
    And then read line by line: "PAHNAPLSIIGYIR"
    Write the code that will take a string and make this conversion given a number of rows:
    string convert(string s, int numRows); 

    Example 1:
    Input: s = "PAYPALISHIRING", numRows = 3
    Output: "PAHNAPLSIIGYIR"

    Example 2:
    Input: s = "PAYPALISHIRING", numRows = 4
    Output: "PINALSIGYAHRPI"
    Explanation:
    P     I    N
    A   L S  I G
    Y A   H R
    P     I

    Example 3:
    Input: s = "A", numRows = 1
    Output: "A"
   */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert("PAYPALISHIRING",4));
        }

        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            char[] res = new char[s.Length];
            int i = 0, groupLen = numRows * 2 - 2;

            for (int j = 0; j < numRows; j++)
            {
                int k = (numRows - j - 1) * 2, l = j;

                while (l < s.Length)
                {
                    res[i++] = s[l];

                    if (j != 0 && j != numRows - 1 && l + k < s.Length)
                    {
                        res[i++] = s[l + k];
                    }

                    l += groupLen;
                }
            }

            return new string(res);
        }
    }
}