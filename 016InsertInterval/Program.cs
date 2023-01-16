namespace _016InsertInterval
{
    /*
    You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval 
    and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.
    Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping 
    intervals (merge overlapping intervals if necessary).
    Return intervals after the insertion.

    Example 1:
    Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
    Output: [[1,5],[6,9]]
    
    Example 2:
    Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
    Output: [[1,2],[3,10],[12,16]]
    Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Insert(new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } }, new int[] { 2, 5 }).ToList().ForEach(k => Console.WriteLine(k[0] + " " + k[1]));
            Console.ReadLine();
        }

        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var updatedIntervals = new List<int[]>();
            var count = 0;

            for (; count < intervals.Length && intervals[count][1] < newInterval[0]; count++)
            {
                updatedIntervals.Add(intervals[count]);
            }

            for (; count < intervals.Length && newInterval[0] <= intervals[count][1] && newInterval[1] >= intervals[count][0]; count++)
            {
                newInterval = new int[] { Math.Min(newInterval[0], intervals[count][0]), Math.Max(newInterval[1], intervals[count][1]) };
            }

            updatedIntervals.Add(newInterval);

            for (; count < intervals.Length; count++)
            {
                updatedIntervals.Add(intervals[count]);
            }

            return updatedIntervals.ToArray();
        }
    }
}