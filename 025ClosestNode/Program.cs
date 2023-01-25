namespace _025ClosestNode
{
    /*
    You are given a directed graph of n nodes numbered from 0 to n - 1, where each node has at most one outgoing edge.
    The graph is represented with a given 0-indexed array edges of size n, indicating that there is a directed edge from node i to node edges[i]. 
    If there is no outgoing edge from i, then edges[i] == -1.
    You are also given two integers node1 and node2.
    Return the index of the node that can be reached from both node1 and node2, such that the maximum between the distance from node1 to that node, 
    and from node2 to that node is minimized. If there are multiple answers, return the node with the smallest index, and if no possible answer exists, return -1.
    Note that edges may contain cycles. 

    Example 1:
    Input: edges = [2,2,3,-1], node1 = 0, node2 = 1
    Output: 2
    Explanation: The distance from node 0 to node 2 is 1, and the distance from node 1 to node 2 is 1.
    The maximum of those two distances is 1. It can be proven that we cannot get a node with a smaller maximum distance than 1, so we return node 2.
    
    Example 2:
    Input: edges = [1,2,-1], node1 = 0, node2 = 2
    Output: 2
    Explanation: The distance from node 0 to node 2 is 2, and the distance from node 2 to itself is 0.
    The maximum of those two distances is 2. It can be proven that we cannot get a node with a smaller maximum distance than 2, so we return node 2.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ClosestMeetingNode(new int[] { 1, 2, -1 }, 0, 2));
            Console.ReadLine();
        }

        public static int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            HashSet<int> v1 = new(), v2 = new();
            Queue<int> q1 = new(new[] { node1 }), q2 = new(new[] { node2 });
            int closest = int.MaxValue;
            while ((q1.Count > 0 || q2.Count > 0) && closest == int.MaxValue)
            {
                for (int count = q1.Count; count > 0; count--)
                {
                    int node = q1.Dequeue();
                    if (v1.Add(node))
                    {
                        if (v2.Contains(node))
                        {
                            closest = Math.Min(closest, node);
                        }
                        else if (edges[node] != -1)
                        {
                            q1.Enqueue(edges[node]);
                        }
                    }
                }
                for (int count = q2.Count; count > 0; count--)
                {
                    int node = q2.Dequeue();
                    if (v2.Add(node))
                    {
                        if (v1.Contains(node))
                        {
                            closest = Math.Min(closest, node);
                        }
                        else if (edges[node] != -1)
                        {
                            q2.Enqueue(edges[node]);
                        }
                    }
                }
            }
            return closest == int.MaxValue ? -1 : closest;

        }
    }
}