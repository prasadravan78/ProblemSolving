namespace _031BestTeamScore
{
    /*
    You are the manager of a basketball team. For the upcoming tournament, you want to choose the team with the highest overall score. 
    The score of the team is the sum of scores of all the players in the team.
    However, the basketball team is not allowed to have conflicts. A conflict exists if a younger player has a strictly higher score than an older player. 
    A conflict does not occur between players of the same age.
    Given two lists, scores and ages, where each scores[i] and ages[i] represents the score and age of the ith player, respectively, 
    return the highest overall score of all possible basketball teams.

    Example 1:
    Input: scores = [1,3,5,10,15], ages = [1,2,3,4,5]
    Output: 34
    Explanation: You can choose all the players.

    Example 2:
    Input: scores = [4,5,6,5], ages = [2,1,2,1]
    Output: 16
    Explanation: It is best to choose the last 3 players. Notice that you are allowed to choose multiple people of the same age.

    Example 3:
    Input: scores = [1,2,3,5], ages = [8,9,10,1]
    Output: 6
    Explanation: It is best to choose the first 3 players. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BestTeamScore(new int[] { 1, 3, 5, 10, 15 }, new int[] { 1, 2, 3, 4, 5 }));
            Console.ReadLine();
        }

        public static int BestTeamScore(int[] scores, int[] ages)
        {
            var dp = new int[scores.Length];

            scores = Enumerable.Range(0, scores.Length)
              .Select(i => (i, score: scores[i], age: ages[i]))
              .OrderByDescending(a => a.age)
              .ThenByDescending(a => a.score)
              .Select(c => c.score)
              .ToArray();

            for (var i = 0; i < scores.Length; i++)
            {
                var value = scores[i];

                for (var j = i - 1; j >= 0; j--)
                    if (scores[j] >= scores[i])
                        value = Math.Max(value, dp[j] + scores[i]);

                dp[i] = value;
            }

            return dp.Max();
        }
    }
}