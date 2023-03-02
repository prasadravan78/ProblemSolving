namespace _061StringCompression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Compress(new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' }));
            Console.ReadLine();
        }

        public static int Compress(char[] chars)
        {
            int response = 0, cnt = 0;
            char current = chars[0];

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == current)
                {
                    cnt++;
                }
                else
                {
                    chars[response++] = current;

                    if (cnt > 1)
                    {
                        foreach (var d in cnt.ToString())
                        {
                            chars[response++] = d;
                        }
                    }

                    current = chars[i];
                    cnt = 1;
                }
            }

            chars[response++] = current;

            if (cnt > 1)
            {
                foreach (var d in cnt.ToString())
                {
                    chars[response++] = d;
                }
            }

            return response;
        }
    }
}