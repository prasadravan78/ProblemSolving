namespace _069LinkedListRandomNode
{
    /*
    Given a singly linked list, return a random node's value from the linked list. Each node must have the same probability of being chosen.
    Implement the Solution class:
    Solution(ListNode head) Initializes the object with the head of the singly-linked list head.
    int getRandom() Chooses a node randomly from the list and returns its value. All the nodes of the list should be equally likely to be chosen.
 
    Example 1:
    Input
    ["Solution", "getRandom", "getRandom", "getRandom", "getRandom", "getRandom"]
    [[[1, 2, 3]], [], [], [], [], []]
    Output
    [null, 1, 3, 2, 2, 3]

    Explanation
    Solution solution = new Solution([1, 2, 3]);
    solution.getRandom(); // return 1
    solution.getRandom(); // return 3
    solution.getRandom(); // return 2
    solution.getRandom(); // return 2
    solution.getRandom(); // return 3
    // getRandom() should return either 1, 2, or 3 randomly. Each element should have equal probability of returning. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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

    public class Solution
    {
        Random r = new();
        int count = 0;
        List<int> list = new();

        public Solution(ListNode head)
        {
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }
            count = list.Count;
        }

        public int GetRandom()
        {
            return list[r.Next(0, count)];
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(head);
     * int param_1 = obj.GetRandom();
     */
}