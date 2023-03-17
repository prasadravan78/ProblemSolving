namespace _075ContructBinaryTree
{
    /*
    Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree and postorder is the postorder 
    traversal of the same tree, construct and return the binary tree. 

    Example 1:
    Input: inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
    Output: [3,9,20,null,null,15,7]

    Example 2:
    Input: inorder = [-1], postorder = [-1]
    Output: [-1] 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BuildTree(new int[] { 9, 3, 15, 20, 7}, new int[] { 9, 15, 7, 20, 3 }).val);
        }

        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0 || postorder == null || postorder.Length == 0)
            {
                return null;
            }

            return BuildTree(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }

        private static TreeNode BuildTree(int[] inorder, int i, int j, int[] postorder, int k, int l)
        {
            if (i > j || k > l)
            {
                return null;
            }

            TreeNode node = new TreeNode(postorder[l]);

            if (k != l)
            {
                int m = 0;

                for (; m < inorder.Length; m++)
                {
                    if (inorder[m] == postorder[l])
                    {
                        break;
                    }
                }

                node.left = BuildTree(inorder, i, m - 1, postorder, k, k + m - i - 1);
                node.right = BuildTree(inorder, m + 1, j, postorder, k + m - i, l - 1);
            }

            return node;
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