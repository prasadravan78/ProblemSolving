namespace ValidParentheses
{
    /*
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    An input string is valid if:
    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.
    Every close bracket has a corresponding open bracket of the same type.
 
    Example 1:

    Input: s = "()"
    Output: true
    Example 2:

    Input: s = "()[]{}"
    Output: true
    Example 3:

    Input: s = "(]"
    Output: false   
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            if (IsValid("]"))
            {
                Console.WriteLine("Valid Parentheses");
            }
            Console.ReadLine();
        }

        public static bool IsValid(string s)
        {
            var startBrackets = new Dictionary<char, int>();
            var endBrackets = new Dictionary<char, int>();
            var stack = new Stack<int>();

            startBrackets.Add('(', 1);
            endBrackets.Add(')', 1);
            startBrackets.Add('[', 2);
            endBrackets.Add(']', 2);
            startBrackets.Add('{', 3);
            endBrackets.Add('}', 3);

            foreach (var ch in s)
            {
                int value;

                if (startBrackets.ContainsKey(ch) && startBrackets.TryGetValue(ch, out value))
                {
                    stack.Push(value);
                }
                else if (endBrackets.ContainsKey(ch) && endBrackets.TryGetValue(ch, out value))
                {
                    int popValue = 0;

                    if (!(stack.TryPop(out popValue) && value == popValue))
                    {
                        return false;
                    }
                }
            }

            if (stack.Count() > 0)
            {
                return false;
            }

            return true;
        }
    }
}