namespace _042ShortestPathAlternatingColors
{
    /*
    You are given an integer n, the number of nodes in a directed graph where the nodes are labeled from 0 to n - 1. 
    Each edge is red or blue in this graph, and there could be self-edges and parallel edges.
    You are given two arrays redEdges and blueEdges where:
    redEdges[i] = [ai, bi] indicates that there is a directed red edge from node ai to node bi in the graph, and
    blueEdges[j] = [uj, vj] indicates that there is a directed blue edge from node uj to node vj in the graph.
    Return an array answer of length n, where each answer[x] is the length of the shortest path from node 0 to 
    node x such that the edge colors alternate along the path, or -1 if such a path does not exist. 

    Example 1:
    Input: n = 3, redEdges = [[0,1],[1,2]], blueEdges = []
    Output: [0,1,-1]

    Example 2:
    Input: n = 3, redEdges = [[0,1]], blueEdges = [[2,1]]
    Output: [0,1,-1] 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            ShortestAlternatingPaths(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } }, new int[][] { }).ToList().ForEach(k=> Console.Write(k + " "));
            Console.ReadLine();
        }

        public static int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges)
        {
            int[] result = new int[n];
            Dictionary<int, List<Tuple<int, char>>> graph = new Dictionary<int, List<Tuple<int, char>>>();
            Queue<Tuple<Tuple<int, char>, int>> queue = new Queue<Tuple<Tuple<int, char>, int>>();
            bool[] redVisited = new bool[n],
                   blueVisited = new bool[n];

            for (int i = 1; i < n; i++)
            {
                result[i] = -1;
            }

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<Tuple<int, char>>());
            }

            foreach (var item in red_edges)
            {
                graph[item[0]].Add(new Tuple<int, char>(item[1], 'R'));
            }

            foreach (var item in blue_edges)
            {
                graph[item[0]].Add(new Tuple<int, char>(item[1], 'B'));
            }

            queue.Enqueue(new Tuple<Tuple<int, char>, int>(new Tuple<int, char>(0, 'X'), 0));
            redVisited[0] = true;
            blueVisited[0] = false;

            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();

                if (result[cur.Item1.Item1] == -1)
                {
                    result[cur.Item1.Item1] = cur.Item2;
                }

                foreach (var item in graph[cur.Item1.Item1])
                {
                    if ((item.Item2 != cur.Item1.Item2 && (item.Item2 == 'R' && !redVisited[item.Item1] || item.Item2 == 'B' && !blueVisited[item.Item1]))
                        || cur.Item1.Item2 == 'X')
                    {
                        queue.Enqueue(new Tuple<Tuple<int, char>, int>(item, cur.Item2 + 1));

                        if (item.Item2 == 'R')
                        {
                            redVisited[item.Item1] = true;
                        }
                        else
                        {
                            blueVisited[item.Item1] = true;
                        }
                    }
                }
            }

            return result;
        }
    }
}