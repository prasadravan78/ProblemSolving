namespace _076ImplementTrie
{
    /*
     A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. 
    There are various applications of this data structure, such as autocomplete and spellchecker.
    Implement the Trie class:
    Trie() Initializes the trie object.
    void insert(String word) Inserts the string word into the trie.
    boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
    boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise. 

    Example 1:
    Input
    ["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
    [[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
    Output
    [null, null, true, false, true, null, true]

    Explanation
    Trie trie = new Trie();
    trie.insert("apple");
    trie.search("apple");   // return True
    trie.search("app");     // return False
    trie.startsWith("app"); // return True
    trie.insert("app");
    trie.search("app");     // return True
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }

    public class Trie
    {

        private TrieNode head = null;

        public Trie()
        {
            head = new TrieNode();
        }

        public void Insert(string word)
        {
            Insert(head, word, 0);
        }

        private void Insert(TrieNode cur, string word, int i)
        {
            if (word.Length == i)
                cur.IsEnd = true;
            else
            {
                if (!cur.ContainsChar(word[i]))
                    cur.AddChar(word[i]);

                Insert(cur[word[i]], word, i + 1);
            }
        }

        public bool Search(string word)
        {
            return Search(head, word, 0);
        }

        private bool Search(TrieNode cur, string word, int i)
        {
            if (word.Length == i)
                return cur.IsEnd;

            return cur.ContainsChar(word[i]) ? Search(cur[word[i]], word, i + 1) : false;
        }

        public bool StartsWith(string prefix)
        {
            return StartsWith(head, prefix, 0);
        }

        private bool StartsWith(TrieNode cur, string prefix, int i)
        {
            if (prefix.Length == i)
                return true;

            return cur.ContainsChar(prefix[i]) ? StartsWith(cur[prefix[i]], prefix, i + 1) : false;
        }

        public class TrieNode
        {
            private Dictionary<char, TrieNode> chars = new Dictionary<char, TrieNode>();

            public bool IsEnd { get; set; }

            public bool ContainsChar(char c)
            {
                return chars.ContainsKey(c);
            }

            public void AddChar(char c)
            {
                chars.Add(c, new TrieNode());
            }

            public TrieNode this[char c]
            {
                get => chars[c];
            }
        }

    }

}