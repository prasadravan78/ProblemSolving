namespace _065KthMissingPositiveNumber
{
    /*
    Given an array arr of positive integers sorted in a strictly increasing order, and an integer k.
    Return the kth positive integer that is missing from this array. 

    Example 1:
    Input: arr = [2,3,4,7,11], k = 5
    Output: 9
    Explanation: The missing positive integers are [1,5,6,8,9,10,12,13,...]. The 5th missing positive integer is 9.
    
    Example 2:
    Input: arr = [1,2,3,4], k = 2
    Output: 6
    Explanation: The missing positive integers are [5,6,7,...]. The 2nd missing positive integer is 6.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindKthPositive(new int[] { 2, 3, 4, 7, 11 }, 5));
            Console.ReadLine();
        }

        public static int FindKthPositive(int[] arr, int k)
        {
            var newList = new List<int>();

            if (arr.Length > 0)
            {
                var low = 1;

                while (newList.Count < k)
                {
                    if (!arr.Contains(low))
                    {
                        newList.Add(low);
                    }

                    low++;
                }


                return newList[k - 1];
            }

            return 1;
        }
    }
}