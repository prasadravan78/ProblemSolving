namespace _048MinimumDistanceBetweenBSTNodes
{
    /*
    Given the root of a Binary Search Tree (BST), return the minimum difference between the values of any two different nodes in the tree.

    Example 1:
    Input: root = [4,2,6,1,3]
    Output: 1

    Example 2:
    Input: root = [1,0,48,null,null,12,49]
    Output: 1 
    */
    internal class Program
    {
        private static int min = int.MaxValue;

        static void Main(string[] args)
        {
            Console.WriteLine(MinDiffInBST(new TreeNode { val = 2 }));
            Console.ReadLine();
        }

        public static int MinDiffInBST(TreeNode root)
        {
            if (root != null)
            {
                var node = root.left;

                while (node?.right != null)
                {
                    node = node.right;
                }

                if (node != null)
                {
                    min = Math.Min(min, Math.Abs(root.val - node.val));
                }

                node = root.right;

                while (node?.left != null)
                {
                    node = node.left;
                }

                if (node != null)
                {
                    min = Math.Min(min, Math.Abs(root.val - node.val));
                }

                MinDiffInBST(root.left);

                MinDiffInBST(root.right);
            }

            return min;
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