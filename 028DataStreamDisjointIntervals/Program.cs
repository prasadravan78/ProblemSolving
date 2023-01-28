namespace _028DataStreamDisjointIntervals
{
    /*
    Given a data stream input of non-negative integers a1, a2, ..., an, summarize the numbers seen so far as a list of disjoint intervals.
    Implement the SummaryRanges class:
    SummaryRanges() Initializes the object with an empty stream.
    void addNum(int value) Adds the integer value to the stream.
    int[][] getIntervals() Returns a summary of the integers in the stream currently as a list of disjoint intervals [starti, endi]. 
    The answer should be sorted by starti.

    Example 1:
    Input
    ["SummaryRanges", "addNum", "getIntervals", "addNum", "getIntervals", "addNum", "getIntervals", "addNum", "getIntervals", "addNum", "getIntervals"]
    [[], [1], [], [3], [], [7], [], [2], [], [6], []]
    Output
    [null, null, [[1, 1]], null, [[1, 1], [3, 3]], null, [[1, 1], [3, 3], [7, 7]], null, [[1, 3], [7, 7]], null, [[1, 3], [6, 7]]]

    Explanation
    SummaryRanges summaryRanges = new SummaryRanges();
    summaryRanges.addNum(1);      // arr = [1]
    summaryRanges.getIntervals(); // return [[1, 1]]
    summaryRanges.addNum(3);      // arr = [1, 3]
    summaryRanges.getIntervals(); // return [[1, 1], [3, 3]]
    summaryRanges.addNum(7);      // arr = [1, 3, 7]
    summaryRanges.getIntervals(); // return [[1, 1], [3, 3], [7, 7]]
    summaryRanges.addNum(2);      // arr = [1, 2, 3, 7]
    summaryRanges.getIntervals(); // return [[1, 3], [7, 7]]
    summaryRanges.addNum(6);      // arr = [1, 2, 3, 6, 7]
    summaryRanges.getIntervals(); // return [[1, 3], [6, 7]]  
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            SummaryRanges summaryRanges = new SummaryRanges();
            summaryRanges.AddNum(1);      // arr = [1]
            summaryRanges.GetIntervals(); // return [[1, 1]]
            summaryRanges.AddNum(3);      // arr = [1, 3]
            summaryRanges.GetIntervals(); // return [[1, 1], [3, 3]]
            summaryRanges.AddNum(7);      // arr = [1, 3, 7]
            summaryRanges.GetIntervals(); // return [[1, 1], [3, 3], [7, 7]]
            summaryRanges.AddNum(2);      // arr = [1, 2, 3, 7]
            summaryRanges.GetIntervals(); // return [[1, 3], [7, 7]]
            summaryRanges.AddNum(6);      // arr = [1, 2, 3, 6, 7]
            summaryRanges.GetIntervals(); // return [[1, 3], [6, 7]]  

            Console.ReadLine();
        }
    }
    public class SummaryRanges
    {
        List<int[]> ranges;

        public SummaryRanges()
        {
            this.ranges = new List<int[]>();
        }

        public void AddNum(int val)
        {
            int index = GetIndexToInsert(val);

            if (index == this.ranges.Count)
            {
                this.ranges.Add(new int[] { val, val });
            }
            else if (this.ranges[index][0] <= val && val <= this.ranges[index][1])
            {
                return;
            }
            else
            {
                this.ranges.Insert(index, new int[] { val, val });
            }

            if (index + 1 < this.ranges.Count && ranges[index + 1][0] == val + 1)
            {
                this.ranges[index][1] = ranges[index + 1][1];
                this.ranges.RemoveAt(index + 1);
            }

            if (index - 1 >= 0 && ranges[index - 1][1] == val - 1)
            {
                this.ranges[index][0] = ranges[index - 1][0];
                this.ranges.RemoveAt(index - 1);
            }
        }

        public int[][] GetIntervals()
        {
            return this.ranges.ToArray();
        }

        private int GetIndexToInsert(int val)
        {
            var array = this.ranges.Select(x => x[1]).ToArray();
            var index = Array.BinarySearch(array, val);

            if (index < 0)
            {
                index = ~index;
            }

            return index;
        }

        /**
         * Your SummaryRanges object will be instantiated and called as such:
         * SummaryRanges obj = new SummaryRanges();
         * obj.AddNum(value);
         * int[][] param_2 = obj.GetIntervals();
         */
    }
}