namespace _027ConcatenatedWords
{
    /*
    Given an array of strings words (without duplicates), return all the concatenated words in the given list of words.
    A concatenated word is defined as a string that is comprised entirely of at least two shorter words in the given array.

    Example 1:
    Input: words = ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]
    Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]
    Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
    "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
    "ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
    
    Example 2:
    Input: words = ["cat","dog","catdog"]
    Output: ["catdog"] 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            FindAllConcatenatedWordsInADict(new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" })
                .ToList()
                .ForEach(k=> Console.WriteLine(k));

            Console.ReadLine();
        }

        public static IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var dictionary = new HashSet<string>(words);
            var answer = new List<string>();

            foreach (string word in words)
            {
                int length = word.Length;
                bool[] visited = new bool[length];

                if (DFS(word, 0, visited, dictionary))
                {
                    answer.Add(word);
                }
            }

            return answer;
        }

        private static bool DFS(string word, int length, bool[] visited, HashSet<string> dictionary)
        {
            if (length == word.Length)
            {
                return true;
            }

            if (visited[length])
            {
                return false;
            }

            visited[length] = true;

            for (int i = word.Length - (length == 0 ? 1 : 0); i > length; --i)
            {
                if (dictionary.Contains(word.Substring(length, i - length)) && DFS(word, i, visited, dictionary))
                {
                    return true;
                }

            }

            return false;
        }
    }
}