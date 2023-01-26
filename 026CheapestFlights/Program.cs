namespace _026CheapestFlights
{
    /*
    There are n cities connected by some number of flights. You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that there is a 
    flight from city fromi to city toi with cost pricing.
    You are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops. If there is no such route, return -1. 

    Example 1:
    Input: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], src = 0, dst = 3, k = 1
    Output: 700
    Explanation:
    The graph is shown above.
    The optimal path with at most 1 stop from city 0 to 3 is marked in red and has cost 100 + 600 = 700.
    Note that the path through cities [0,1,2,3] is cheaper but is invalid because it uses 2 stops.
    
    Example 2:
    Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 1
    Output: 200
    Explanation:
    The graph is shown above.
    The optimal path with at most 1 stop from city 0 to 2 is marked in red and has cost 100 + 100 = 200.
    
    Example 3:
    Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k = 0
    Output: 500
    Explanation:
    The graph is shown above.
    The optimal path with no stops from city 0 to 2 is marked in red and has cost 500. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindCheapestPrice(3, new int[][] { new int[] { 0, 1, 100 }, new int[] { 1, 2, 100 }, new int[] { 0, 2, 500 }, }, 0, 2, 0));
        }

        public static int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            Dictionary<int, List<int[]>> g = new Dictionary<int, List<int[]>>();
            int[] stops = new int[n];
            SortedSet<City> queue = new SortedSet<City>();

            for (int i = 0; i < n; i++)
            {
                g.Add(i, new List<int[]>());
            }

            foreach (int[] flight in flights)
            {
                g[flight[0]].Add(new int[] { flight[1], flight[2] });
            }

            for (int i = 0; i < n; i++)
            {
                stops[i] = int.MaxValue;
            }

            queue.Add(new City(src, 0, -1));

            while (queue.Count > 0)
            {
                City curr = queue.Min;
                queue.Remove(curr);

                if (curr.stops <= k && curr.stops < stops[curr.id])
                {
                    if (curr.id == dst)
                    {
                        return curr.cost;
                    }

                    stops[curr.id] = curr.stops;

                    foreach (int[] next in g[curr.id])
                    {
                        queue.Add(new City(next[0], curr.cost + next[1], curr.stops + 1));
                    }
                }
            }

            return -1;
        }
    }

    public class City : IComparable<City>
    {
        public int id;
        public int cost;
        public int stops;

        public City(int id, int cost, int stops)
        {
            this.id = id;
            this.cost = cost;
            this.stops = stops;
        }

        public int CompareTo(City other)
        {
            if (this.cost != other.cost)
            {
                return this.cost.CompareTo(other.cost);
            }
            else
            {
                return this.id.CompareTo(other.id);
            }
        }
    }
}