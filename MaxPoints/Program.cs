namespace MaxPoints
{
    internal class Program
    {
        /*
        Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.

        Input: points = [[1,1],[2,2],[3,3]]
        Output: 3
        Example 2:

        Input: points = [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
        Output: 4 
         
         */
        static void Main(string[] args)
        {
            Console.WriteLine(MaxPoints(new int[][] { new int[] { 1, 1 }, new int[] { 3, 2 }, new int[] { 5, 3 }, new int[] { 4, 1 }, new int[] { 2, 3 }, new int[] { 1, 4 } }));
            Console.WriteLine(MaxPoints(new int[][] { new int[] { -6, -1 }, new int[] { 3, 1 }, new int[] { 12, 3 } }));
            Console.WriteLine(MaxPoints(new int[][] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 3, 3 } }));
            Console.WriteLine(MaxPoints(new int[][] { new int[] { 1, 1 }, new int[] { 4, 2 } }));
            Console.WriteLine(MaxPoints(new int[][] { new int[] { 0, 0 }, new int[] { 4, 5 }, new int[] { 7, 8 }, new int[] { 8, 9 }, new int[] { 5, 6 }, new int[] { 3, 4 }, new int[] { 1, 1 } }));
            Console.ReadLine();
        }

        public static int MaxPoints(int[][] points)
        {
            if (points.Length < 3)
            {
                return points.Length;
            }

            int max = 0;
            var map = new Dictionary<long, int>();

            for (int i = 0; i < points.Length; i++)
            {
                map.Clear();
                int dup = 1;

                for (int j = i + 1; j < points.Length; j++)
                {
                    int dx = points[j][0] - points[i][0];
                    int dy = points[j][1] - points[i][1];

                    if (dx == 0 && dy == 0)
                    {
                        dup++;
                    }
                    else
                    {
                        int gcd = getGcd(dx, dy);
                        long slope = ((long)(dy / gcd) << 32) + (dx / gcd);

                        if (!map.ContainsKey(slope))
                        {
                            map.Add(slope, 0);
                        }

                        map[slope]++;
                    }
                }

                max = Math.Max(max, dup);

                foreach (var val in map.Values)
                {
                    max = Math.Max(max, val + dup);
                }
            }

            return max;
        }

        private static int getGcd(int a, int b)
        {
            return b == 0 ? a : getGcd(b, a % b);
        }
    }
}