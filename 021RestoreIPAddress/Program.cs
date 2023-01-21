namespace _021RestoreIPAddress
{
    /*
    A valid IP address consists of exactly four integers separated by single dots. Each integer is between 0 and 255 (inclusive) and cannot have leading zeros.
    For example, "0.1.2.201" and "192.168.1.1" are valid IP addresses, but "0.011.255.245", "192.168.1.312" and "192.168@1.1" are invalid IP addresses.
    Given a string s containing only digits, return all possible valid IP addresses that can be formed by inserting dots into s. 
    You are not allowed to reorder or remove any digits in s. You may return the valid IP addresses in any order.

    Example 1:
    Input: s = "25525511135"
    Output: ["255.255.11.135","255.255.111.35"]

    Example 2:
    Input: s = "0000"
    Output: ["0.0.0.0"]
    
    Example 3:
    Input: s = "101023"
    Output: ["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"] 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            RestoreIpAddresses("25525511135").ToList().ForEach(k => Console.WriteLine(k));
            Console.ReadLine();
        }

        public static IList<string> RestoreIpAddresses(string s)
        {
            List<string> res = new List<string>();
            List<string> ips = new List<string>();

            Backtrack(res, ips, s, 0);
            return res;
        }

        private static void Backtrack(IList<string> res, IList<string> ips, string s, int start)
        {
            if (ips.Count == 4 && start == s.Length)
            {
                res.Add(string.Join(".", ips));
                return;
            }

            if (s.Length - start > (4 - ips.Count) * 3) // pruning if right side contains more characters than needed
            {
                return;
            }

            for (int i = start; i < start + 4 && i < s.Length; i++)
            {
                string ip = s.Substring(start, i - start + 1);
                if (int.Parse(ip) > 255 || int.Parse(ip).ToString() != ip) // prevent digit larger or starts with 0
                {
                    return;
                }

                ips.Add(ip);
                Backtrack(res, ips, s, i + 1);
                ips.RemoveAt(ips.Count - 1);
            }
        }
    }
}