namespace _023FindTownJudge
{
    /*
    In a town, there are n people labeled from 1 to n. There is a rumor that one of these people is secretly the town judge.
    If the town judge exists, then:
    The town judge trusts nobody.
    Everybody (except for the town judge) trusts the town judge.
    There is exactly one person that satisfies properties 1 and 2.
    You are given an array trust where trust[i] = [ai, bi] representing that the person labeled ai trusts the person labeled bi.
    Return the label of the town judge if the town judge exists and can be identified, or return -1 otherwise.

    Example 1:
    Input: n = 2, trust = [[1,2]]
    Output: 2

    Example 2:
    Input: n = 3, trust = [[1,3],[2,3]]
    Output: 3

    Example 3:
    Input: n = 3, trust = [[1,3],[2,3],[3,1]]
    Output: -1 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindJudge(4, new int[][] { new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 4, 3 } }));
            Console.ReadLine();
        }

        public static int FindJudge(int n, int[][] trust)
        {
            if (trust.Length == 0)
            {
                if (n == 1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            var judges = trust.Select(k => k[1]).GroupBy(k => k).OrderByDescending(k => k.Count()).ToList();
            var people = trust.Select(k => k[0]).ToList();

            if (judges.Count > 1 && !judges.Any(k => k.Count() == n - 1))
            {
                return -1;
            }
            else
            {
                if (people.Contains(judges[0].FirstOrDefault()))
                {
                    return -1;
                }

                return judges[0].FirstOrDefault();
            }
        }
    }
}