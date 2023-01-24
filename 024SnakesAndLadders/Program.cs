namespace _024SnakesAndLadders
{
    /*
    You are given an n x n integer matrix board where the cells are labeled from 1 to n2 in a Boustrophedon style starting from the bottom left of the board 
    (i.e. board[n - 1][0]) and alternating direction each row.
    You start on square 1 of the board. In each move, starting from square curr, do the following:
    Choose a destination square next with a label in the range [curr + 1, min(curr + 6, n2)].
    This choice simulates the result of a standard 6-sided die roll: i.e., there are always at most 6 destinations, regardless of the size of the board.
    If next has a snake or ladder, you must move to the destination of that snake or ladder. Otherwise, you move to next.
    The game ends when you reach the square n2.
    A board square on row r and column c has a snake or ladder if board[r][c] != -1. The destination of that snake or ladder is board[r][c]. 
    Squares 1 and n2 do not have a snake or ladder.
    Note that you only take a snake or ladder at most once per move. If the destination to a snake or ladder is the start of another snake or ladder, 
    you do not follow the subsequent snake or ladder.
    For example, suppose the board is [[-1,4],[-1,3]], and on the first move, your destination square is 2. You follow the ladder to square 3, but do not follow the subsequent ladder to 4.
    Return the least number of moves required to reach the square n2. If it is not possible to reach the square, return -1.

    Example 1:
    Input: board = [[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,35,-1,-1,13,-1],[-1,-1,-1,-1,-1,-1],[-1,15,-1,-1,-1,-1]]
    Output: 4
    Explanation: 
    In the beginning, you start at square 1 (at row 5, column 0).
    You decide to move to square 2 and must take the ladder to square 15.
    You then decide to move to square 17 and must take the snake to square 13.
    You then decide to move to square 14 and must take the ladder to square 35.
    You then decide to move to square 36, ending the game.
    This is the lowest possible number of moves to reach the last square, so return 4.

    Example 2:
    Input: board = [[-1,-1],[-1,3]]
    Output: 1 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SnakesAndLadders(new int[][] { new int[] { -1, -1 }, new int[] { -1, 3 } }));
            Console.ReadLine();
        }

        public static int SnakesAndLadders(int[][] board)
        {
            int n = board.Length;
            int[,] visited = new int[n, n];
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(1);
            int steps = 0;

            while (qu.Count > 0)
            {
                int cnt = qu.Count;

                for (int i = 0; i < cnt; i++)
                {
                    int cur = qu.Dequeue();

                    if (cur == n * n)
                    {
                        return steps;
                    }

                    for (int j = 1; j <= 6; j++)
                    {
                        int newVal = cur + j;
                        if (newVal > n * n)
                        {
                            break;
                        }

                        var cor = GetCoordinates(newVal, n);

                        if (visited[cor.x, cor.y] == 1)
                        {
                            continue;
                        }

                        if (board[cor.x][cor.y] == -1)
                        {
                            qu.Enqueue(newVal);
                        }
                        else
                        {
                            qu.Enqueue(board[cor.x][cor.y]);
                        }
                        visited[cor.x, cor.y] = 1;
                    }
                }

                steps++;
            }

            return -1;
        }

        private static (int x, int y) GetCoordinates(int x, int n)
        {
            int r = n - (x - 1) / n - 1;
            int c = (x - 1) % n;

            if (r % 2 == n % 2)
            {
                return (r, n - c - 1);
            }

            return (r, c);
        }
    }
}