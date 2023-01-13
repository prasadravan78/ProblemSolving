namespace _013LongestPath
{
    /*
    You are given a tree (i.e. a connected, undirected graph that has no cycles) rooted at node 0 consisting of n nodes numbered from 0 to n - 1. 
    The tree is represented by a 0-indexed array parent of size n, where parent[i] is the parent of node i. Since node 0 is the root, parent[0] == -1.
    You are also given a string s of length n, where s[i] is the character assigned to node i.
    Return the length of the longest path in the tree such that no pair of adjacent nodes on the path have the same character assigned to them.

    Example 1:
    Input: parent = [-1,0,0,1,1,2], s = "abacbe"
    Output: 3
    Explanation: The longest path where each two adjacent nodes have different characters in the tree is the path: 0 -> 1 -> 3. 
    The length of this path is 3, so 3 is returned.
    It can be proven that there is no longer path that satisfies the conditions. 

    Example 2:
    Input: parent = [-1,0,0,0], s = "aabc"

    Output: 3
    Explanation: The longest path where each two adjacent nodes have different characters is the path: 2 -> 0 -> 3. The length of this path is 3, so 3 is returned.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPath(new int[] { -1, 0, 0, 0 }, "aabc"));
            Console.ReadLine();
        }

        public static int LongestPath(int[] parent, string s)
        {
            var response = 1;
            Dictionary<int, List<int>> verticies = new();

            for (int i = 0; i < parent.Length; i++)
            {
                verticies.Add(i, new List<int>());
            }

            for (int i = 0; i < parent.Length; i++)
            {
                if (verticies.ContainsKey(parent[i]))
                {
                    verticies[parent[i]].Add(i);
                }
            }

            DFS(0, ref response, verticies, s);

            return response;
        }

        private static int DFS(int current, ref int response, Dictionary<int, List<int>> verticies, string s)
        {
            if (verticies[current].Count == 0)
            {
                return 1;
            }

            var longest1 = 0;
            var longest2 = 0;

            foreach (var child in verticies[current])
            {
                var childLongest = DFS(child, ref response, verticies, s);

                if (s[child] == s[current])
                {
                    continue;
                }

                if (childLongest > longest1)
                {
                    longest2 = longest1;
                    longest1 = childLongest;
                }
                else if (childLongest > longest2)
                {
                    longest2 = childLongest;
                }
            }

            response = Math.Max(response, 1 + longest1 + longest2);

            return 1 + longest1;
        }
    }
}