namespace _077DesignBrowserHistory
{
    /*
    You have a browser of one tab where you start on the homepage and you can visit another url, get back in the history number of steps or move 
    forward in the history number of steps.
    Implement the BrowserHistory class:
    BrowserHistory(string homepage) Initializes the object with the homepage of the browser.
    void visit(string url) Visits url from the current page. It clears up all the forward history.
    string back(int steps) Move steps back in history. If you can only return x steps in the history and steps > x, you will return only x steps. 
    Return the current url after moving back in history at most steps.
    string forward(int steps) Move steps forward in history. If you can only forward x steps in the history and steps > x, you will forward only x steps. 
    Return the current url after forwarding in history at most steps. 

    Example:
    Input:
    ["BrowserHistory","visit","visit","visit","back","back","forward","visit","forward","back","back"]
    [["leetcode.com"],["google.com"],["facebook.com"],["youtube.com"],[1],[1],[1],["linkedin.com"],[2],[2],[7]]
    Output:
    [null,null,null,null,"facebook.com","google.com","facebook.com",null,"linkedin.com","google.com","leetcode.com"]

    Explanation:
    BrowserHistory browserHistory = new BrowserHistory("leetcode.com");
    browserHistory.visit("google.com");       // You are in "leetcode.com". Visit "google.com"
    browserHistory.visit("facebook.com");     // You are in "google.com". Visit "facebook.com"
    browserHistory.visit("youtube.com");      // You are in "facebook.com". Visit "youtube.com"
    browserHistory.back(1);                   // You are in "youtube.com", move back to "facebook.com" return "facebook.com"
    browserHistory.back(1);                   // You are in "facebook.com", move back to "google.com" return "google.com"
    browserHistory.forward(1);                // You are in "google.com", move forward to "facebook.com" return "facebook.com"
    browserHistory.visit("linkedin.com");     // You are in "facebook.com". Visit "linkedin.com"
    browserHistory.forward(2);                // You are in "linkedin.com", you cannot move forward any steps.
    browserHistory.back(2);                   // You are in "linkedin.com", move back two steps to "facebook.com" then to "google.com". return "google.com"
    browserHistory.back(7);                   // You are in "google.com", you can move back only one step to "leetcode.com". return "leetcode.com" 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class BrowserHistory
    {

        List<string> history = new();
        int curr = 0; //current position of user (not index in the list)

        public BrowserHistory(string homepage)
        {
            history.Add(homepage);
            ++curr;
        }

        public void Visit(string url)
        {
            if (history.Count > curr)
                history.RemoveRange((curr), (history.Count - curr));//startIndex, count of elements. Remove rest of the pages
            history.Add(url);
            ++curr;
        }

        public string Back(int steps)
        {
            if ((curr - steps) < 1)
            {
                curr = 1;
                return history.First();
            }
            curr -= steps;
            return history[curr - 1];
        }

        public string Forward(int steps)
        {
            if (steps + curr >= history.Count)
            {
                curr = history.Count;
                return history.Last();
            }
            curr += steps;
            return history[curr - 1];
        }
    }
}