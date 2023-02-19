namespace _049InvertBinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(InvertTree(new TreeNode(20)));
            Console.ReadLine();
        }

        public static TreeNode? InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            TreeNode temp = root.right;
            root.right = root.left;
            root.left = temp;

            InvertTree(root.left);
            InvertTree(root.right);

            return root;
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