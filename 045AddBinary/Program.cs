using System.Text;

namespace _045AddBinary
{
    /*
    Given two binary strings a and b, return their sum as a binary string.

    Example 1:
    Input: a = "11", b = "1"
    Output: "100"

    Example 2:
    Input: a = "1010", b = "1011"
    Output: "10101" 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("1010", "1011"));
            Console.ReadLine();
        }

        public static string AddBinary(string a, string b)
        {
            StringBuilder sb = new StringBuilder();
            int i = a.Length - 1;
            int j = b.Length - 1;
            int carry = 0;

            while (i >= 0 || j >= 0)
            {
                int sum = carry;

                if (i >= 0)
                {
                    sum += a[i--] - '0';
                }

                if (j >= 0)
                {
                    sum += b[j--] - '0';
                }

                sb.Insert(0, sum % 2);
                carry = sum / 2;
            }

            if (carry != 0)
            {
                sb.Insert(0, 1);
            }

            return sb.ToString();
        }
    }
}