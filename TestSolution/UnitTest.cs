using System.Collections;
using ConsoleApp1;
using ListNode = ConsoleApp1.Solution.ListNode;

namespace TestSolution;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test (Description = "974. Subarray Sums Divisible by K")]
    [TestCase(new [] {4,5,0,-2,-3,1}, 5, 7)]
    public void TestSubarraysDivByK_974(int[] nums, int k, int expected)
    {
        var result = Solution.SubarraysDivByK_974(nums, k);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test (Description = "523. Continuous Subarray Sum")]
    [TestCase(new [] {23,2,4,6,7}, 6, true)]
    [TestCase(new [] {23,2,6,4,7}, 6, true)]
    [TestCase(new [] {23,2,6,4,7}, 13, false)]
    [TestCase(new [] {23,2,4,6,6}, 7, true)]
    public void TestCheckSubarraySum_523(int[] nums, int k, bool expected)
    {
        var result = Solution.CheckSubarraySum_523(nums, k);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test (Description = "648. Replace Words")]
    [TestCase(new [] {"cat","bat","rat"}, "the cattle was rattled by the battery", "the cat was rat by the bat")]
    [TestCase(new [] {"a","b","c"}, "aadsfasf absbs bbab cadsfafs", "a a b c")]
    [TestCase(new [] {"a", "aa", "aaa", "aaaa"}, "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa", "a a a a a a a a bbb baba a")]
    public void TestReplaceWords_648(IList<string> dictionary, string sentence, string expected)
    {
        var result = Solution.ReplaceWords_648(dictionary, sentence);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test (Description = "846. Hand of Straights")]
    [TestCase(new [] {1,2,3,6,2,3,4,7,8}, 3, true)]
    [TestCase(new [] {1,2,3,4,5}, 4, false)]
    [TestCase(new [] {8,10,12}, 3, false)]
    [TestCase(new [] {1,1,2,2,3,3}, 2, false)]
    [TestCase(new [] {1,1,2,2,3,3}, 3, true)]
    [TestCase(new [] {34,80,89,15,38,69,19,17,97,98,26,77,8,31,79,70,103,3,13,21,81,53,33,14,60,68,33,59,84,23,97,90,76,82,66,83,23,22,16,18,98,25,16,61,84,100,4,68,101,25,23,9,10,55,2,67,39,52,102,99,40,11,83,24,81,53,96,23,13,24,99,67,22,51,31,58,78,88,5,15,24,32,81,91,96,16,54,22,56,69,14,82,32,34,83,24,37,82,54,21}, 4, true)]
    public void TestIsNStraightHand_846(int[] hand, int groupSize, bool expected)
    {
        var result = Solution.IsNStraightHand_846(hand, groupSize);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test(Description = "Longest Substring")]
    [TestCase("abcbada", 4)]
    [TestCase("axbxcxd", 3)]
    [TestCase("aaaaaaa", 1)]
    [TestCase("abcdefg", 7)]
    [TestCase("abccccdd", 3)]
    [TestCase("a", 1)]
    public void TestLongestSubstring(string str, int expected)
    {
        var result = Solution.LongestSubstring(str);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test(Description = "Find Max")]
    [TestCase(new double[] {1, -3, 0.1, -5}, 150)]
    public void TestFindMax(double[] input, double expected)
    {
        var result = Solution.FindMax(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test(Description = "NumRescueBoats")]
    [TestCase(new[] {1, 2}, 3, 1)]
    [TestCase(new[] {3,2,2,1}, 3, 3)]
    [TestCase(new[] {3,5,3,4}, 5, 4)]
    public void TestNumRescueBoats(int[] people, int limit, int expected)
    {
        var result = Solution.NumRescueBoats(people, limit);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test(Description = "StealMoney")]
    [TestCase(new[] { 1, 2, 3, 1 }, 4)]
    [TestCase(new[] { 2, 5, 4, 6 }, 11)]
    [TestCase(new[] { 2, 7, 9, 3, 1, 6 }, 17)]
    [TestCase(new[] { 4, 11, 10, 2, 1, 8, 5 }, 22)]
    public void TestStealMoney(int[] moneyInHouses, int expected)
    {
        var result = Solution.StealMoney(moneyInHouses);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test(Description = "TwoSum")]
    [TestCase(new[] { -3, 0, 1, 3, 4 }, 5, new int[] { 1, 4 })]
    [TestCase(new[] { -1, 2, 5, 8 }, 7, new int[] { -1, 8 })]
    [TestCase(new[] { -3, -1, 0, 2, 6 }, 6, new int[] { 0, 6 })]
    [TestCase(new[] { 2, 4, 5, }, 8, new int[] { })]
    [TestCase(new[] { -2, -1, 1, 2}, 0, new int[] { -2, 2})]
    public void TestTwoSum(int[] nums, int k, int [] expected)
    {
        var result = Solution.TwoSum(nums, k);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test(Description = "Remove Nodes")]
    [TestCase(new[] {5,2,13,3,8}, new int[] {13,8})]
    [TestCase(new[] {1,1,1,1}, new int[] {1,1,1,1})]
    [TestCase(new[] {998,112,660,961,943}, new int[] {998,961,943})]
    [TestCase(new[]
    {
        138,466,216,67,642,978,264,136,463,331,60,600,223,275,856,809,167,101,846,165,575,276,409,590,733,200,839,515,852,615,8,584,250,337,537,63,797,900,670,636,112,701,334,422,780,552,912,506,313,474,183,792,822,661,37,164,601,271,902,792,501,184,559,140,506,94,161,167,622,288,457,953,700,464,785,203,729,725,422,76,191,195,157,854,730,577,503,401,517,692,42,135,823,883,255,111,334,365,513,338,65,600,926,607,193,763,366,674,145,229,700,11,984,36,185,475,204,604,191,898,876,762,654,770,774,575,276,165,610,649,235,749,440,607,962,747,891,943,839,403,655,22,705,416,904,765,905,574,214,471,451,774,41,365,703,895,327,879,414,821,363,30,130,14,754,41,494,548,76,825,899,499,188,982,8,890,563,438,363,32,482,623,864,161,962,678,414,659,612,332,164,580,14,633,842,969,792,777,705,436,750,501,395,342,838,493,998,112,660,961,943,721,480,522,133,129,276,362,616,52,117,300,274,862,487,715,272,232,543,275,68,144,656,623,317,63,908,565,880,12,920,467,559,91,698
    }, new int[] {998,961,943,920,698})]
    public void TestRemoveNodes(int[] listValues, int [] expected)
    {
        var root = ListNode.GetListNodeByArray(listValues);
        var result = Solution.RemoveNodes(root);
        var array = ListNode.GetArrayByListNode(result);
        Assert.That(array, Is.EqualTo(expected));
    }

    [Test(Description = "DoubleIt Nodes")]
    [TestCase(new[] { 1,8,9 }, new[] { 3,7,8 })]
    [TestCase(new[] { 3,4,5,4,2,5,5,9,9,9 }, new[] { 6,9,0,8,5,1,1,9,9,8 })]
    public void TestDubleItNode(int[] listValues, int[] expected)
    {
        var root = ListNode.GetListNodeByArray(listValues);
        var result = Solution.DoubleIt(root);
        var array = ListNode.GetArrayByListNode(result);
        Assert.That(array, Is.EqualTo(expected));
    }
    
    [Test(Description = "DoubleItDFC Nodes")]
    [TestCase(new[] { 1,8,9 }, new[] { 3,7,8 })]
    [TestCase(new[] { 3,4,5,4,2,5,5,9,9,9 }, new[] { 6,9,0,8,5,1,1,9,9,8 })]
    public void TestDoubleItDFCNode(int[] listValues, int[] expected)
    {
        var root = ListNode.GetListNodeByArray(listValues);
        var result = Solution.DoubleItDFC(root);
        var array = ListNode.GetArrayByListNode(result);
        Assert.That(array, Is.EqualTo(expected));
    }
    
    
    public static IEnumerable TestCasesMaximumValueSum
    {
        get
        {
            yield return new TestCaseData(
                new[] {1,2,1},
                3,
                new[] 
                {
                    new[] {0,1},
                    new[] {0,2},
                },
                6
            );
        }
    }

    public static IEnumerable TestCasesMaximumValueSum1
    {
        get
        {
            yield return new TestCaseData(
                new[] {24,78,1,97,44},
                6,
                new[] 
                {
                    new[] {0,2},
                    new[] {1,2},
                    new[] {4,2},
                    new[] {3,4},
                },
                260
            );
        }
    }
    
    public static IEnumerable TestCasesMaximumValueSum2
    {
        get
        {
            yield return new TestCaseData(
                new[] {78,43,92,97,95,94},
                6,
                new[] 
                {
                    new[] {1,2},
                    new[] {3,0},
                    new[] {4,0},
                    new[] {0,1},
                    new[] {1,5},
                },
                507
            );
        }
    }
    
    [Test(Description="Find the Maximum Sum of Node Values")]
    [TestCaseSource(nameof(TestCasesMaximumValueSum))]
    [TestCaseSource(nameof(TestCasesMaximumValueSum1))]
    [TestCaseSource(nameof(TestCasesMaximumValueSum2))]
    public void TestMaximumValueSum(int[] nums, int k, int[][] edges, int expected)
    {
        var result = Solution.MaximumValueSum(nums, k, edges); 
        Assert.AreEqual(expected, result);
    }

    [Test(Description = "Score Of String")]
    [TestCase( "hello", 13)]
    [TestCase( "zaz", 50)]
    public void TestScoreOfString_3110(string str, int expected)
    {
        var result = Solution.ScoreOfString_3110(str);
        Assert.That(expected, Is.EqualTo(result));
    }

    [Test(Description = "Reverse String")]
    [TestCase(new [] {'h','e','l','l','o'}, new [] {'o','l','l','e','h'})]
    [TestCase(new [] {'H','a','n','n','a','h'}, new [] {'h','a','n','n','a', 'H'})]
    public void TestReverseString_344(char[] str, char[]  expected)
    {
        Solution.ReverseString_344(str);
        Assert.That(str, Is.EqualTo(expected));
    }

    [Test(Description = "2486. Append Characters to String to Make Subsequence")]
    [TestCase("coaching", "coding", 4)]
    [TestCase("abcde", "a", 0)]
    [TestCase("z", "abcde", 5)]
    public void TestAppendCharacters_2486(string s, string t, int expected)
    {
        var result = Solution.AppendCharacters_2486(s, t);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test(Description = "409. Longest Palindrome")]
    [TestCase("abccccdd", 7)]
    [TestCase("a", 1)]
    [TestCase("bb", 2)]
    public void TestLongestPalindrome_409(string s, int expected)
    {
        var result = Solution.LongestPalindrome_409(s);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test(Description = "1002. Find Common Characters")]
    [TestCase(new [] {"bella","label","roller"}, new [] {"e","l","l"})]
    [TestCase(new [] {"cool","lock","cook"}, new [] {"c","o"})]
    public void TestCommonChars_1002(string[] words, IList<string> expected)
    {
        var result = Solution.CommonChars_1002(words);
        Assert.That(result, Is.EqualTo(expected));
    }
}