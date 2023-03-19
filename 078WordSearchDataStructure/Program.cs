namespace _078WordSearchDataStructure
{
    /*
    Design a data structure that supports adding new words and finding if a string matches any previously added string.
    Implement the WordDictionary class:
    WordDictionary() Initializes the object.
    void addWord(word) Adds word to the data structure, it can be matched later.
    bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. 
    word may contain dots '.' where dots can be matched with any letter. 

    Example:
    Input
    ["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
    [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
    Output
    [null,null,null,null,false,true,true,true]

    Explanation
    WordDictionary wordDictionary = new WordDictionary();
    wordDictionary.addWord("bad");
    wordDictionary.addWord("dad");
    wordDictionary.addWord("mad");
    wordDictionary.search("pad"); // return False
    wordDictionary.search("bad"); // return True
    wordDictionary.search(".ad"); // return True
    wordDictionary.search("b.."); // return True 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class WordDictionary
    {
        public class TrieNode
        {
            public TrieNode[] Children;
            public bool IsWord;

            public TrieNode()
            {
                Children = new TrieNode[26];
            }
        }

        public TrieNode root;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            root = new TrieNode();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            var curr = root;

            foreach (char c in word)
            {
                if (curr.Children[c - 'a'] == null)
                {
                    curr.Children[c - 'a'] = new TrieNode();
                }

                curr = curr.Children[c - 'a'];
            }

            curr.IsWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Search(word, 0, root);
        }

        public bool Search(string word, int index, TrieNode node)
        {
            if (node == null)
            {
                return false;
            }

            if (index == word.Length)
            {
                return node.IsWord;
            }

            if (word[index] == '.')
            {
                for (int i = 0; i < node.Children.Length; i++)
                {
                    TrieNode curr = node.Children[i];

                    if (Search(word, index + 1, curr))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (Search(word, index + 1, node.Children[word[index] - 'a']))
                {
                    return true;
                }
            }

            return false;
        }
    }
}