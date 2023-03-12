namespace _071MergeSortedLists
{
    /*
    You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
    Merge all the linked-lists into one sorted linked-list and return it. 

    Example 1:
    Input: lists = [[1,4,5],[1,3,4],[2,6]]
    Output: [1,1,2,3,4,4,5,6]
    Explanation: The linked-lists are:
    [
      1->4->5,
      1->3->4,
      2->6
    ]
    merging them into one sorted list:
    1->1->2->3->4->4->5->6

    Example 2:
    Input: lists = []
    Output: []

    Example 3:
    Input: lists = [[]]
    Output: [] 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            return Merge(lists, 0, lists.Length - 1);
        }

        private static ListNode Merge(ListNode[] lists, int i, int j)
        {
            if (j == i)
            {
                return lists[i];
            }
            else
            {
                int mid = i + (j - i) / 2;

                ListNode left = Merge(lists, i, mid),
                         right = Merge(lists, mid + 1, j);

                return Merge(left, right);
            }
        }

        private static ListNode Merge(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode(0), cur = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    cur.next = list2;
                    list2 = list2.next;
                }

                cur = cur.next;
            }

            if (list1 != null)
            {
                cur.next = list1;
            }

            if (list2 != null)
            {
                cur.next = list2;
            }

            return dummy.next;
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

}