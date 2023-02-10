namespace _041FarLand
{
    /*
    Given an n x n grid containing only values 0 and 1, where 0 represents water and 1 represents land, find a water cell such that its 
    distance to the nearest land cell is maximized, and return the distance. If no land or water exists in the grid, return -1.
    The distance used in this problem is the Manhattan distance: the distance between two cells (x0, y0) and (x1, y1) is |x0 - x1| + |y0 - y1|.

    Example 1:
    Input: grid = [[1,0,1],[0,0,0],[1,0,1]]
    Output: 2
    Explanation: The cell (1, 1) is as far as possible from all the land with distance 2.
    
    Example 2:
    Input: grid = [[1,0,0],[0,0,0],[0,0,0]]
    Output: 4
    Explanation: The cell (2, 2) is as far as possible from all the land with distance 4. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxDistance(new int[][] { new int[] { 1, 0, 1 }, new int[] { 0, 0, 0 }, new int[] { 1, 0, 1 } }));
            Console.ReadLine();
        }

        public static int MaxDistance(int[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int res = -1;
            Queue<int[]> q = new Queue<int[]>();
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int[] dx = new int[] { 0, 0, 1, -1 },
                  dy = new int[] { 1, -1, 0, 0 };

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        q.Enqueue(new int[] { i, j });
                    }
                }
            }

            while (q.Count > 0)
            {
                int cnt = q.Count;

                res++;

                while (cnt > 0)
                {
                    int[] cur = q.Dequeue();

                    for (int l = 0; l < 4; l++)
                    {
                        int newX = cur[0] + dx[l],
                            newY = cur[1] + dy[l];

                        if (newX > -1 && newX < grid.Length && newY > -1 && newY < grid[0].Length && !visited[newX, newY] && grid[newX][newY] == 0)
                        {
                            q.Enqueue(new int[] { newX, newY });
                            visited[newX, newY] = true;
                        }
                    }

                    cnt--;
                }
            }

            return res == 0 ? -1 : res;
        }
    }
}