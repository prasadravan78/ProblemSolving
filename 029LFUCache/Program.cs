namespace _029LFUCache
{
    /*
    Design and implement a data structure for a Least Frequently Used (LFU) cache.
    Implement the LFUCache class:
    LFUCache(int capacity) Initializes the object with the capacity of the data structure.
    int get(int key) Gets the value of the key if the key exists in the cache. Otherwise, returns -1.
    void put(int key, int value) Update the value of the key if present, or inserts the key if not already present. 
    When the cache reaches its capacity, it should invalidate and remove the least frequently used key before inserting a new item. 
    For this problem, when there is a tie (i.e., two or more keys with the same frequency), the least recently used key would be invalidated.
    To determine the least frequently used key, a use counter is maintained for each key in the cache. 
    The key with the smallest use counter is the least frequently used key.
    When a key is first inserted into the cache, its use counter is set to 1 (due to the put operation).
    The use counter for a key in the cache is incremented either a get or put operation is called on it.
    The functions get and put must each run in O(1) average time complexity.

    Example 1:
    Input
    ["LFUCache", "put", "put", "get", "put", "get", "get", "put", "get", "get", "get"]
    [[2], [1, 1], [2, 2], [1], [3, 3], [2], [3], [4, 4], [1], [3], [4]]
    Output
    [null, null, null, 1, null, -1, 3, null, -1, 3, 4]

    Explanation
    // cnt(x) = the use counter for key x
    // cache=[] will show the last used order for tiebreakers (leftmost element is  most recent)
    LFUCache lfu = new LFUCache(2);
    lfu.put(1, 1);   // cache=[1,_], cnt(1)=1
    lfu.put(2, 2);   // cache=[2,1], cnt(2)=1, cnt(1)=1
    lfu.get(1);      // return 1
                     // cache=[1,2], cnt(2)=1, cnt(1)=2
    lfu.put(3, 3);   // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
                     // cache=[3,1], cnt(3)=1, cnt(1)=2
    lfu.get(2);      // return -1 (not found)
    lfu.get(3);      // return 3
                     // cache=[3,1], cnt(3)=2, cnt(1)=2
    lfu.put(4, 4);   // Both 1 and 3 have the same cnt, but 1 is LRU, invalidate 1.
                     // cache=[4,3], cnt(4)=1, cnt(3)=2
    lfu.get(1);      // return -1 (not found)
    lfu.get(3);      // return 3
                     // cache=[3,4], cnt(4)=1, cnt(3)=3
    lfu.get(4);      // return 4
                     // cache=[4,3], cnt(4)=2, cnt(3)=3
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}

public class LFUCache
{
    public class Cache
    {
        public int key;
        public int val;
        public int freq;
        public Cache(int k, int v, int f)
        {
            key = k;
            val = v;
            freq = f;
        }
    }

    public int size = 0;
    public int minFreq = 0;
    public Dictionary<int, LinkedListNode<Cache>> cacheDic = new Dictionary<int, LinkedListNode<Cache>>();
    public Dictionary<int, LinkedList<Cache>> freqCacheDic = new Dictionary<int, LinkedList<Cache>>();

    public LFUCache(int capacity)
    {
        size = capacity;
    }

    public int Get(int key)
    {
        if (size <= 0 || !cacheDic.ContainsKey(key))
        {
            return -1;
        }

        LinkedListNode<Cache> node = cacheDic[key];
        freqCacheDic[node.Value.freq].Remove(node);
        node.Value.freq++;

        if (!freqCacheDic.ContainsKey(node.Value.freq))
        {
            freqCacheDic.Add(node.Value.freq, new LinkedList<Cache>() { });
        }

        freqCacheDic[node.Value.freq].AddLast(node);

        if (freqCacheDic[minFreq].Count == 0)
        {
            minFreq++;
        }

        return node.Value.val;
    }

    public void Put(int key, int value)
    {
        if (size <= 0)
        {
            return;
        }

        int cacheValue = Get(key);

        if (cacheValue != -1)
        {
            cacheDic[key].Value.val = value;
        }
        else
        {
            if (cacheDic.Count == size)
            {
                LinkedListNode<Cache> node = freqCacheDic[minFreq].First;
                cacheDic.Remove(node.Value.key);
                freqCacheDic[minFreq].Remove(node);
            }

            Cache cache = new Cache(key, value, 1);

            if (!freqCacheDic.ContainsKey(1))
            {
                freqCacheDic.Add(1, new LinkedList<Cache>());
            }

            LinkedListNode<Cache> cacheNode = freqCacheDic[1].AddLast(cache);
            cacheDic.Add(key, cacheNode);
            minFreq = 1;
        }
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */