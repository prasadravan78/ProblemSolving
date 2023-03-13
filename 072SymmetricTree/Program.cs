namespace _072SymmetricTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public bool IsSymmetric(TreeNode root)
        {
            return root == null || IsSame(root.left, root.right);
        }

        private bool IsSame(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 != null || n1 != null && n2 == null || n1 != null && n2 != null && n1.val != n2.val)
            {
                return false;
            }

            return n1 == null && n2 == null || IsSame(n1.left, n2.right) && IsSame(n1.right, n2.left);
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