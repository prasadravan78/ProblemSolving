namespace _074CompletenessBinaryTree
{
    /*
    Given the root of a binary tree, determine if it is a complete binary tree.
    In a complete binary tree, every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. 
    It can have between 1 and 2h nodes inclusive at the last level h. 

    Example 1:
    Input: root = [1,2,3,4,5,6]
    Output: true
    Explanation: Every level before the last is full (ie. levels with node-values {1} and {2, 3}), and all nodes in the last level ({4, 5, 6}) are as far left as possible.
    
    Example 2:
    Input: root = [1,2,3,4,5,null,7]
    Output: false
    Explanation: The node with value 7 isn't as far left as possible. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public bool IsCompleteTree(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            bool isEnd = false;

            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode cur = q.Dequeue();

                if (isEnd && cur != null)
                {
                    return false;
                }

                if (cur == null)
                {
                    isEnd = true;
                }

                if (cur != null)
                {
                    q.Enqueue(cur.left);
                    q.Enqueue(cur.right);
                }
            }

            return true;
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