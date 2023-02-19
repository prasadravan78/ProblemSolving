namespace _050BinaryTreeZigzagTraversal
{
    /*
    Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).

    Example 1:
    Input: root = [3,9,20,null,null,15,7]
    Output: [[3],[20,9],[15,7]]

    Example 2:
    Input: root = [1]
    Output: [[1]]

    Example 3:
    Input: root = []
    Output: [] 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ZigzagLevelOrder(new TreeNode(10)));
            Console.ReadLine();
        }

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> response = new List<IList<int>>();

            if (root == null)
            {
                return response;
            }

            int rowNum = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                List<int> row = new List<int>();
                int count = queue.Count;

                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    row.Add(node.val);

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                if (rowNum % 2 == 1)
                {
                    row.Reverse();
                }

                response.Add(row);

                rowNum++;
            }

            return response;
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