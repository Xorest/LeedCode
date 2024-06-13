
namespace ConsoleApp1;

public static class Solution
{
    #region Metods

    public static int MinMovesToSeat_2037(int[] seats, int[] students) 
    {
        Array.Sort(seats);
        Array.Sort(students);

        return seats.Select((t, i) => Math.Abs(t - students[i])).Sum();   
        
        // var result = 0;
        //
        // for (var i = 0; i < seats.Length; i++) 
        //     result += Math.Abs(seats[i] - students[i]);
        //
        // return result;
    }
    
    public static int[] RelativeSortArray_1122(int[] arr1, int[] arr2) 
    {
        var temp = arr2.ToDictionary(a => a, a => 0);
        var end = new List<int>();
        foreach (var a in arr1)
        {
            if (temp.ContainsKey(a)) 
                temp[a]++;
            else
                end.Add(a);
        }

        end.Sort();
        var start = new List<int>();

        foreach (var (n, c) in temp)
            for (var i = 0; i < c; i++) 
                start.Add(n);
        
        start.AddRange(end);
        return start.ToArray();
    }
    
    public static int HeightChecker_1051(int[] heights)
    {
        var order = heights.OrderBy(h => h).ToList();
        return order.Where((t, i) => t != heights[i]).Count();
    }
    
    public static int SubarraysDivByK_974(int[] nums, int k)
    {
        var prefixMod = 0;
        var result = 0;

        var modGroups = new int[k];
        modGroups[0] = 1;

        foreach (var num in nums)
        {
            prefixMod = (prefixMod + num % k + k) % k;
            result += modGroups[prefixMod];
            modGroups[prefixMod]++;
        }    

        return result;
    }
    
    public static bool CheckSubarraySum_523(int[] nums, int k)
    {
        var remainderDict = new Dictionary<int, int>();
        remainderDict[0] = -1; 
        var prefixSum = 0;
        
        for (var i = 0; i < nums.Length; i++) 
        {
            prefixSum += nums[i];
            var remainder = prefixSum % k;

            if (remainderDict.TryAdd(remainder, i)) 
                continue;
            
            if (i - remainderDict[remainder] > 1)
                return true;
        }
        
        return false;
    }

    public static string ReplaceWords_648(IList<string> dictionary, string sentence)
    {
        var roots = dictionary.OrderBy(x => x).ToList();
        var words = sentence.Split(" ");

        for (var i = 0; i < words.Length; i++)
        {
            var value = roots.Find(s => words[i].StartsWith(s));
            if (value != null) 
                words[i] = value;
        }
        
        return string.Join(" ", words);
    }
    
    public static bool IsNStraightHand_846(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
            return false;
        
        var cardCount = new Dictionary<int, int>();
        
        foreach (var card in hand)
        {
            cardCount.TryAdd(card, 0);
            cardCount[card]++;
        }

        Array.Sort(hand);
        
        foreach (var card in hand)
        {
            if (cardCount[card] == 0)
                continue;

            for (var i = 0; i < groupSize; i++)
            { 
                var currentCard = card + i;
                
                if (!cardCount.TryGetValue(currentCard, out var value) || value == 0)
                    return false;
                
                cardCount[currentCard] = --value;
            }
        }

        return true;
    }
    
    public static IList<string> CommonChars_1002(string[] words)
    {
        var minFreq = new int[26];
        Array.Fill(minFreq, int.MaxValue);
        
        foreach (var word in words)
        {
            var freq = new int[26];

            foreach (var c in word) 
                freq[c - 'a']++;
            
            for (var i = 0; i < 26; i++) 
                minFreq[i] = Math.Min(minFreq[i], freq[i]);
        }
        
        var result = new List<string>();
        
        for (var i = 0; i < 26; i++)
        {
            for (var j = 0; j < minFreq[i]; j++)
            {
                var c = (char)(i + 'a');
                result.Add(c.ToString());
            }
        }

        return result;
    }
    
    public static int LongestPalindrome_409(string s)
    {
        var result = 0;

        if (s.Length > 0)
            result++;

        var dict = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (!dict.TryAdd(c, 1))
                dict[c]++;
        }

        foreach (var (c, i) in dict)
        {
            result += (i / 2) * 2;
        }
        
        if (result > s.Length)
            result = s.Length;
        
        return result;
    }
    
    public static int AppendCharacters_2486(string s, string t)
    {
        var index = 0;

        foreach (var str in s)
        {
            if (index > t.Length - 1)
                return 0;

            if (t[index] == str)
                index++;
        }

        return t.Length - index;
    }
    
    public static void ReverseString_344(char[] s)
    {
        var leftIndex = 0;
        var rightIndex = s.Length - 1;

        while (leftIndex < rightIndex)
        {
            (s[leftIndex], s[rightIndex]) = (s[rightIndex], s[leftIndex]);
            leftIndex++;
            rightIndex--;
        }
    }
    
    public static bool IsSameTree_100(TreeNode? p, TreeNode? q)
    {
        if (p == null && q == null)
            return true;

        if (p?.val != q?.val)
            return false;

        return IsSameTree_100(p?.left, q?.left) && IsSameTree_100(p?.right, q?.right);
    }
    
    public static int ScoreOfString_3110(string str)
    {
        var result = 0;
        
        for (var s = 0;  s < str.Length - 1; s++)
        {
            var left = str[s];
            var right = str[s + 1];
            
            if (left == right)
                continue;
            
            result += Math.Abs(left - right);
        }
        
        return result;
    }
    
    public static long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        var memo = new long[nums.Length][];
        
        for (var i = 0; i < nums.Length; i++) 
            memo[i] = [-1, -1];
        
        return MaxSumOfNodes(0, 1, nums, k, memo);
    }

    private static long MaxSumOfNodes(int index, int isEven, int[] nums, int k, long[][] memo)
    {
        if (index == nums.Length)
            return isEven == 1 ? 0 : long.MinValue;
        
        if (memo[index][isEven] != -1)
            return memo[index][isEven];

        var noXorDone = nums[index] + MaxSumOfNodes(index + 1, isEven, nums, k, memo);
        var xorDone = (nums[index] ^ k) + MaxSumOfNodes(index + 1, isEven ^ 1, nums, k, memo);

        return memo[index][isEven] = Math.Max(xorDone, noXorDone);
    }
    
    public static ListNode DoubleItDFC(ListNode head)
    {
        var root = new ListNode(0);
        root.next = head;

        _ = DFCforListNode(root);

        return root.val == 0 ? head : root;
    }

    private static int DFCforListNode(ListNode? head)
    {
        if (head == null)
            return 0;

        var carry = DFCforListNode(head.next);
        var result = (head.val << 1) + carry;
        head.val = result % 10;

        return result / 10;
    }


    public static ListNode DoubleIt(ListNode head)
    {
        var stack = new Stack<ListNode>();
        var current = head;

        while (current != null)
        {
            stack.Push(current);
            current = current.next;
        }

        var needAdd = 0;
        
        while (stack.Count != 0)
        {
            current = stack.Pop();
            var temp = (current.val << 1) + needAdd;
            needAdd = temp >= 10 ? 1 : 0;
            current.val = temp % 10;
        }

        var root = needAdd > 0 ? new ListNode(needAdd) {next = head} : head;
        
        return root;
    }
    
    public static ListNode RemoveNodes(ListNode head)
    {
        var current = head;
        var stackNode = new Stack<ListNode>();
        
        while (current != null)
        {
            stackNode.Push(current);
            current = current.next;
        }
        
        var maxVal = int.MinValue;
        ListNode? result = null;
        
        while (stackNode.Count != 0)
        {
            current = stackNode.Pop();

            if (maxVal > current.val) 
                continue;
            
            maxVal = current.val;
            
            if (result == null)
            {
                result = new ListNode(current.val) { next = current.next };
                continue;
            }

            var temp = new ListNode(result.val){next = result.next};
            result.val = current.val;
            result.next = temp;
        }

        return result!;
    }
    
    public static void DeleteNode(ref ListNode node)
    {
        node.val = node.next!.val;
        node.next = node.next.next;
    }
    
    public static int[] TwoSum(int[] nums, int k)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var sum = nums[left] + nums[right];

            if (sum== k)
                return [nums[left], nums[right]];

            if (sum < k)
                left++;

            if (sum > k)
                right--;
        }
        
        return [];
    }

    public static int StealMoney(int[] moneyInHouses)
    {
        switch (moneyInHouses.Length)
        {
            case 0:
                return 0;
            case 1:
                return moneyInHouses[0];
            default:
                var dp = new List<int>();

                dp.Add(moneyInHouses[0]);
                dp.Add(Math.Max(dp[0], moneyInHouses[1]));

                for (var i = 2; i < moneyInHouses.Length; i++)
                {
                    dp.Add(Math.Max(moneyInHouses[i] + dp[i - 2], dp[i - 1]));
                }

                return dp.Last();
        }
    }
    
    public static int NumRescueBoats(int[] people, int limit) 
    {
        Array.Sort(people);
        var left = 0;
        var right = people.Length - 1;
        var bouthCount = 0;
        
        while (left <= right)
        {
            var weightFirst = people[left];
            var weightLast = people[right];
            
            if (weightLast + weightFirst <= limit)
            {
                left++;
            }
        
            right--;
            bouthCount++;
        }
        
        return bouthCount;
    }
    
    /// <summary>
    /// Sliding Window Algorithm
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int LongestSubstring(string str)
    {
        var indexLeft = 0;
        var indexRight = 0;
        var sortedSet = new SortedSet<char>();
        var max = 0;

        while (indexRight < str.Length)
        {
            if (!sortedSet.Add(str[indexRight]))
            {
                max = Math.Max(sortedSet.Count, max);
                sortedSet.Remove(str[indexLeft++]);
                continue;
            }

            indexRight++;
        }
        
        return max != 0 ? max : sortedSet.Count;
    }
    
    public static double FindMax(double[] input)
    {
        if (input.Length == 0)
            return 0;
        
        var fMax = input[0];
        var fMin = input[0];
        
        for (var i = 1; i < input.Length; i ++)
        {
            var f = FindMaxAndMin(fMax, input[i]);
            var s = FindMaxAndMin(fMin, input[i]);

            fMax = Math.Max(f.Max, s.Max);
            fMin = Math.Min(f.Max, s.Min);
        }

        return Math.Max(fMax, fMin);
    }

    private static MaxAndMin FindMaxAndMin(double numA, double numB)
    {
        var max = double.MinValue;
        var min = double.MaxValue;
        
        foreach (Operators op in Enum.GetValues(typeof(Operators)))
        {
            var t = Calculate(numA, numB, op);
            if (t == null)
                continue;
            
            max = Math.Max(max, (double)t);
            min = Math.Min(min, (double)t);
        }

        return new(max, min);
    }

    private record MaxAndMin(double Max, double Min);
    
    private static double? Calculate(double first, double second, Operators op)
    {
        return op switch
        {
            Operators.Multiplication => first * second,
            Operators.Division => second != 0 ? first / second : null,
            Operators.Addition => first + second,
            Operators.Subtraction => first - second,
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };
    }

    public static int FindDistance(int targetX, int targetY)
    {
        var layerNum = 0;
        var previousLayer = new SortedSet<(int, int)>();
        var currentLayer = new SortedSet<(int, int)>();
        currentLayer.Add(new(0, 0));

        while (currentLayer.Contains((targetX, targetY)))
        {
            var nextLayer = new SortedSet<(int, int)>();
            foreach (var (x, y) in currentLayer)
            {
                foreach (var nextCell in Moves(x, y))
                {
                    if (!previousLayer.Contains(nextCell))
                    {
                        nextLayer.Add(nextCell);
                    }
                }
            }

            previousLayer = currentLayer;
            currentLayer = nextLayer;
            layerNum++;
        }

        return layerNum;
    }

    private static List<(int, int)> Moves(int x, int y)
    {
        return new()
        {
            (x - 2, y + 1), (x - 2, y - 1),
            (x - 1, y + 2), (x - 1, y - 2),
            (x + 1, y + 2), (x + 1, y - 2),
            (x + 2, y + 1), (x + 2, y - 1),
        };
    }
    
    #endregion

    #region Classes And Enums

    public enum Operators
    {
        Multiplication ,
        Division,
        Addition,
        Subtraction,
    }

    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public int val = val;
        public TreeNode? left = left;
        public TreeNode? right = right;
    }

    public class ListNode 
    {
        public int val;
        public ListNode? next; 
        public ListNode(int x, ListNode? node = null) 
        {
            val = x;
            next = node;
        }

        public override string ToString()
        {
            var prev = this;
            var afterStr = string.Empty;
            while (prev != null) 
            {
                afterStr += string.IsNullOrEmpty(afterStr) ? $"{prev.val}" : $", {prev.val}";
                prev = prev.next;
            }

            return afterStr;
        }
        
        public static ListNode GetListNodeByArray(int[] valuses)
        {
            var result = new ListNode(valuses[0]);
            var current = result;

            for (var i = 1; i < valuses.Length; i++)
            {
                var next = new ListNode(valuses[i]);
                current.next = next;
                current = next;
            }

            return result;
        }

        public static int[] GetArrayByListNode(ListNode root)
        {
            var result = new List<int>();

            var current = root;
            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }

            return result.ToArray();
        }
    }

    #endregion
}