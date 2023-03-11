namespace _070SortedListToBinaryTree
{
    /*
    Given the head of a singly linked list where elements are sorted in ascending order, convert it to a height-balanced binary search tree.

    Example 1:
    Input: head = [-10,-3,0,5,9]
    Output: [0,-3,9,-10,null,5]
    Explanation: One possible answer is [0,-3,9,-10,null,5], which represents the shown height balanced BST.

    Example 2:
    Input: head = []
    Output: []
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode slow = head, fast = head, dummy = new ListNode() { next = head };

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                dummy = dummy.next;
            }

            TreeNode treenode = new TreeNode(slow.val);

            dummy.next = null;

            if (slow != head)
            {
                treenode.left = SortedListToBST(head);
            }

            treenode.right = SortedListToBST(slow.next);

            return treenode;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
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