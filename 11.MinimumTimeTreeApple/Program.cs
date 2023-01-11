namespace _11.MinimumTimeTreeApple
{
    internal class Program
    {
        /*
        Given an undirected tree consisting of n vertices numbered from 0 to n-1, which has some apples in their vertices. 
        You spend 1 second to walk over one edge of the tree. Return the minimum time in seconds you have to spend to collect all apples in the tree, 
        starting at vertex 0 and coming back to this vertex.

        The edges of the undirected tree are given in the array edges, where edges[i] = [ai, bi] means that exists an edge connecting the vertices ai and bi. 
        Additionally, there is a boolean array hasApple, where hasApple[i] = true means that vertex i has an apple; otherwise, it does not have any apple.

        Example 1:
        Input: n = 7, edges = [[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]], hasApple = [false,false,true,false,true,true,false]
        Output: 8 
        Explanation: The figure above represents the given tree where red vertices have an apple. One optimal path to collect all apples is shown by the green arrows.  
        
        Example 2:
        Input: n = 7, edges = [[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]], hasApple = [false,false,true,false,false,true,false]
        Output: 6
        Explanation: The figure above represents the given tree where red vertices have an apple. One optimal path to collect all apples is shown by the green arrows.  
        
        Example 3:
        Input: n = 7, edges = [[0,1],[0,2],[1,4],[1,5],[2,3],[2,6]], hasApple = [false,false,false,false,false,false,false]
        Output: 0 
        */
        static void Main(string[] args)
        {
            Console.WriteLine(MinTime(4,
                new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 0, 3 } },
                new bool[] { true, true, false, true }));
            Console.ReadLine();
        }

        public static int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            var adjcentNodes = new List<int>[n];
            var timeForNode = new int[n];
            var queue = new Queue<int>();
            var count = 0;

            for (var i = 0; i < n; i++)
            {
                adjcentNodes[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adjcentNodes[edge[0]].Add(edge[1]);
                adjcentNodes[edge[1]].Add(edge[0]);
                timeForNode[edge[0]]++;
                timeForNode[edge[1]]++;
            }

            for (var i = 1; i < n; i++)
            {
                if (timeForNode[i] == 1)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var v = queue.Dequeue();

                if (hasApple[v])
                {
                    count += 2;
                }

                foreach (var u in adjcentNodes[v])
                {
                    timeForNode[u]--;

                    if (hasApple[v])
                    {
                        hasApple[u] = true;
                    }

                    if (u != 0 && timeForNode[u] == 1)
                    {
                        queue.Enqueue(u);
                    }
                }
            }

            return count;
        }
    }
}