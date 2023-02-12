namespace _043MinimumFuelCostCapital
{
    /*
    There is a tree (i.e., a connected, undirected graph with no cycles) structure country network consisting of n cities numbered from 0 to n - 1 and exactly n - 1 roads.
    The capital city is city 0. You are given a 2D integer array roads where roads[i] = [ai, bi] denotes that there exists a bidirectional road connecting cities ai and bi.
    There is a meeting for the representatives of each city. The meeting is in the capital city.
    There is a car in each city. You are given an integer seats that indicates the number of seats in each car.
    A representative can use the car in their city to travel or change the car and ride with another representative. 
    The cost of traveling between two cities is one liter of fuel.
    Return the minimum number of liters of fuel to reach the capital city.

    Example 1:
    Input: roads = [[0,1],[0,2],[0,3]], seats = 5
    Output: 3
    Explanation: 
    - Representative1 goes directly to the capital with 1 liter of fuel.
    - Representative2 goes directly to the capital with 1 liter of fuel.
    - Representative3 goes directly to the capital with 1 liter of fuel.
    It costs 3 liters of fuel at minimum. 
    It can be proven that 3 is the minimum number of liters of fuel needed.
    
    Example 2:
    Input: roads = [[3,1],[3,2],[1,0],[0,4],[0,5],[4,6]], seats = 2
    Output: 7
    Explanation: 
    - Representative2 goes directly to city 3 with 1 liter of fuel.
    - Representative2 and representative3 go together to city 1 with 1 liter of fuel.
    - Representative2 and representative3 go together to the capital with 1 liter of fuel.
    - Representative1 goes directly to the capital with 1 liter of fuel.
    - Representative5 goes directly to the capital with 1 liter of fuel.
    - Representative6 goes directly to city 4 with 1 liter of fuel.
    - Representative4 and representative6 go together to the capital with 1 liter of fuel.
    It costs 7 liters of fuel at minimum. 
    It can be proven that 7 is the minimum number of liters of fuel needed.
    
    Example 3:
    Input: roads = [], seats = 1
    Output: 0
    Explanation: No representatives need to travel to the capital city. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinimumFuelCost(new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 0, 3 } }, 5));
            Console.ReadLine();
        }

        public static long MinimumFuelCost(int[][] roads, int seats)
        {
            var n = roads.Length + 1;
            var graph = new List<int>[n];
            long res = 0;

            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var road in roads)
            {
                graph[road[0]].Add(road[1]);
                graph[road[1]].Add(road[0]);
            }

            DFS(graph, 0, seats, new HashSet<int> { 0 }, ref res);

            return res;
        }

        public static int DFS(List<int>[] graph, int cur, int seats, HashSet<int> visited, ref long res)
        {
            var count = 1;

            foreach (var next in graph[cur])
            {
                if (!visited.Add(next))
                {
                    continue;
                }

                count += DFS(graph, next, seats, visited, ref res);
            }

            if (cur == 0)
            {
                return count;
            }

            res += count % seats == 0 ? count / seats : count / seats + 1;

            return count;
        }
    }
}