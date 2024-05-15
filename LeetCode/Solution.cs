using System.Net;

namespace ConsoleApp1;

public static class Solution
{
    #region Metods

    public static ListNode DoubleIt(ListNode head) //todo
    {
        return null;
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