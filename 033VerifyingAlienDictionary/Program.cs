namespace _033VerifyingAlienDictionary
{
    /*
    In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order. 
    The order of the alphabet is some permutation of lowercase letters.
    Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are
    sorted lexicographically in this alien language.

    Example 1:
    Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
    Output: true
    Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
    
    Example 2:
    Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
    Output: false
    Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
    
    Example 3:
    Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
    Output: false
    Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", 
    because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info). 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            if (IsAlienSorted(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz"))
            {
                Console.WriteLine("Sorted");
            }
            else
            {
                Console.WriteLine("Unsorted");
            }

            Console.ReadLine();
        }

        public static bool IsAlienSorted(string[] words, string order)
        {
            var dictionary = new Dictionary<char, int>();

            for (int i = 0; i < order.Length; i++)
            {
                dictionary.Add(order[i], i + 1);
            }

            for (int i = 1; i < words.Length; i++)
            {
                int j = 0;

                while (j < words[i - 1].Length && j < words[i].Length)
                {
                    if (dictionary[words[i - 1][j]] < dictionary[words[i][j]])
                    {
                        break;
                    }
                    else if (dictionary[words[i - 1][j]] > dictionary[words[i][j]])
                    {
                        return false;
                    }
                    else
                    {
                        j++;
                    }
                }

                if ((j == words[i - 1].Length - 1 || j == words[i].Length) && words[i - 1].Length > words[i].Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}