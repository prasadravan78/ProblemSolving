namespace _059DuplicateSubTree
{
    /*
    Given the root of a binary tree, return all duplicate subtrees.
    For each kind of duplicate subtrees, you only need to return the root node of any one of them.
    Two trees are duplicate if they have the same structure with the same node values. 

    Example 1:
    Input: root = [1,2,3,4,null,2,4,null,null,4]
    Output: [[2,4],[4]]

    Example 2:
    Input: root = [2,1,1]
    Output: [[1]]

    Example 3:
    Input: root = [2,2,2,3,null,3,null]
    Output: [[2,3],[3]] 
    */
    internal class Program
    {
        private IList<TreeNode> res = new List<TreeNode>();
        private Dictionary<string, int> dict = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            if (root == null)
            {
                return res;
            }

            DFS(root);

            return res;
        }

        private string DFS(TreeNode node)
        {
            if (node == null)
            {
                return "-";
            }

            string val = node.val.ToString() + "-" + DFS(node.left) + DFS(node.right);

            if (dict.ContainsKey(val))
            {
                dict[val]++;
            }
            else
            {
                dict.Add(val, 1);
            }

            if (dict[val] == 2)
            {
                res.Add(node);
            }

            return val;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}