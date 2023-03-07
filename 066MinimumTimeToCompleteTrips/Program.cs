namespace _066MinimumTimeToCompleteTrips
{
    /*
    You are given an array time where time[i] denotes the time taken by the ith bus to complete one trip.
    Each bus can make multiple trips successively; that is, the next trip can start immediately after completing the current trip. 
    Also, each bus operates independently; that is, the trips of one bus do not influence the trips of any other bus.
    You are also given an integer totalTrips, which denotes the number of trips all buses should make in total. 
    Return the minimum time required for all buses to complete at least totalTrips trips.

    Example 1:
    Input: time = [1,2,3], totalTrips = 5
    Output: 3
    Explanation:
    - At time t = 1, the number of trips completed by each bus are [1,0,0]. 
      The total number of trips completed is 1 + 0 + 0 = 1.
    - At time t = 2, the number of trips completed by each bus are [2,1,0]. 
      The total number of trips completed is 2 + 1 + 0 = 3.
    - At time t = 3, the number of trips completed by each bus are [3,1,1]. 
      The total number of trips completed is 3 + 1 + 1 = 5.
    So the minimum time needed for all buses to complete at least 5 trips is 3.

    Example 2:
    Input: time = [2], totalTrips = 1
    Output: 2
    Explanation:
    There is only one bus, and it will complete its first trip at t = 2.
    So the minimum time needed to complete 1 trip is 2. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinimumTime(new int[] { 1, 2, 3 }, 5));
            Console.ReadLine();
        }

        public static long MinimumTime(int[] time, int totalTrips)
        {
            if (time.Length == 1)
            {
                return ((long)time[0] * totalTrips);
            }

            long startTime = time.Min();
            long result = ((long)startTime * totalTrips);
            long endTime = result;

            while (startTime <= endTime)
            {
                long timeTaken = startTime + (endTime - startTime + 1) / 2;

                if (time.Sum(x => timeTaken / x) >= totalTrips)
                {
                    result = Math.Min(result, timeTaken);
                    endTime = timeTaken - 1;
                }
                else
                {
                    startTime = timeTaken + 1;
                }
            }

            return result;
        }
    }
}