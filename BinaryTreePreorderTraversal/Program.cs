namespace BinaryTreePreorderTraversal
{
    /*
     
    Given the root of a binary tree, return the preorder traversal of its nodes' values.
    Example 1:
    Input: root = [1,null,2,3]
    Output: [1,2,3]
    Example 2:

    Input: root = []
    Output: []
    Example 3:

    Input: root = [1]
    Output: [1]
 
    */
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

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static IList<int> PreorderTraversal(TreeNode root)
        {
            var preOrder = new List<int>();
            var stackNodes = new Stack<TreeNode>();

            if (root == null)
            {
                return preOrder;
            }

            stackNodes.Push(root);

            while (stackNodes.Any())
            {
                var currentNode = stackNodes.Pop();
                preOrder.Add(currentNode.val);

                if (currentNode.right != null)
                {
                    stackNodes.Push(currentNode.right);
                }

                if (currentNode.left != null)
                {
                    stackNodes.Push(currentNode.left);
                }
            }

            return preOrder;
        }
    }
}