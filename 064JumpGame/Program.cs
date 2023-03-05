namespace _064JumpGame
{
    /*
    Given an array of integers arr, you are initially positioned at the first index of the array.
    In one step you can jump from index i to index:

    i + 1 where: i + 1 < arr.length.
    i - 1 where: i - 1 >= 0.
    j where: arr[i] == arr[j] and i != j.
    Return the minimum number of steps to reach the last index of the array.

    Notice that you can not jump outside of the array at any time. 

    Example 1:
    Input: arr = [100,-23,-23,404,100,23,23,23,3,404]
    Output: 3
    Explanation: You need three jumps from index 0 --> 4 --> 3 --> 9. Note that index 9 is the last index of the array.

    Example 2:
    Input: arr = [7]
    Output: 0
    Explanation: Start index is the last index. You do not need to jump.

    Example 3:
    Input: arr = [7,6,9,6,9,6,9,7]
    Output: 1
    Explanation: You can jump directly from index 0 to index 7 which is last index of the array. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinJumps(new int[] { 100, -23, -23, 404, 100, 23, 23, 23, 3, 404 }));
            Console.ReadLine();
        }

        public static int MinJumps(int[] arr)
        {
            IDictionary<int, IList<int>> dic = new Dictionary<int, IList<int>>();

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int x = arr[i];

                if (!dic.ContainsKey(x))
                {
                    dic.Add(x, new List<int>());
                }

                dic[x].Add(i);
            }

            bool[] visit = new bool[arr.Length];
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            int depth = 0;

            while (q.Count > 0)
            {
                int count = q.Count;

                for (int i = 0; i < count; i++)
                {
                    int cur = q.Dequeue();

                    if (cur == arr.Length - 1)
                    {
                        return depth;
                    }

                    if (visit[cur])
                    {
                        continue;
                    }

                    visit[cur] = true;
                    var next = dic[arr[cur]];

                    if (cur - 1 >= 0)
                    {
                        next.Add(cur - 1);
                    }

                    if (cur + 1 < arr.Length)
                    {
                        next.Add(cur + 1);
                    }

                    foreach (int x in dic[arr[cur]])
                    {
                        q.Enqueue(x);
                    }

                    next.Clear();
                }

                depth++;
            }

            return arr.Length - 1;
        }
    }
}