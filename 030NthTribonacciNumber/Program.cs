namespace _030NthTribonacciNumber
{
    /*
    The Tribonacci sequence Tn is defined as follows: 
    T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.
    Given n, return the value of Tn.

    Example 1:
    Input: n = 4
    Output: 4
    Explanation:
    T_3 = 0 + 1 + 1 = 2
    T_4 = 1 + 1 + 2 = 4

    Example 2:
    Input: n = 25
    Output: 1389537 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Tribonacci(5));
            Console.ReadLine();
        }

        public static int Tribonacci(int n)
        {
            int[] array = { 0, 1, 1 };

            for (int i = 3; i <= n; i++)
            {
                array[i % 3] = array[0] + array[1] + array[2];
            }

            return array[n % 3];
        }
    }
}