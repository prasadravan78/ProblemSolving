namespace _080MajorityElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MajorityElement(new int[] { 3,2,3}));
            Console.ReadKey();
        }

        public static int MajorityElement(int[] nums)
        {
            var dict = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num] = dict[num] + 1;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            return dict.MaxBy(k=> k.Value).Key;
        }
    }
}
