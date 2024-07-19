namespace _081LuckyNumberMatrix
{
    /*
    Given an m x n matrix of distinct numbers, return all lucky numbers in the matrix in any order.
    A lucky number is an element of the matrix such that it is the minimum element in its row and maximum in its column. 

    Example 1:
    Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
    Output: [15]
    Explanation: 15 is the only lucky number since it is the minimum in its row and the maximum in its column.
    
    Example 2:
    Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
    Output: [12]
    Explanation: 12 is the only lucky number since it is the minimum in its row and the maximum in its column.
    
    Example 3:
    Input: matrix = [[7,8],[1,2]]
    Output: [7]
    Explanation: 7 is the only lucky number since it is the minimum in its row and the maximum in its column.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[][] { [1, 10, 4, 2], [9, 3, 8, 7], [15, 16, 17, 12] };
            Console.WriteLine(LuckyNumber(matrix).FirstOrDefault());
            Console.ReadLine();
        }

        static List<int> LuckyNumber(int[][] matrix)
        {
            var min = matrix.Select(k => k.Min()).ToList();
            var max = new List<int>();

            for (var m = 0; m < matrix[0].Length; m++)
            {
                var maxColumn = matrix[0][m];

                for (var n = 0; n < matrix.Length; n++)
                {
                    maxColumn = Math.Max(maxColumn, matrix[n][m]);
                }

                max.Add(maxColumn);
            }

            return min.Intersect(max).ToList();
        }
    }
}
