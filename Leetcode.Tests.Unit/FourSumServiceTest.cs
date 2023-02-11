using Leetcode.Services;
using System.Diagnostics;

namespace Leetcode.Tests.Unit;

[TestClass]
public class FourSumServiceTest
{
    /*
     *Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
     *
     * Input: nums = [2,2,2,2,2], target = 8
Output: [[2,2,2,2]]
     *
     */

    public static IEnumerable<(int[][] expected, int target, int[] nums)> CombinationTests()
    {
        yield return new(new int[][] { new[] { -2, -1, 1, 2 }, new[] { -2, -1, 1, 2 } }, 8, new[] { 2, 2, 2, 2, 2 });
    }

    public (int[][] expected, int target, int[] nums) combination_tests1()
    {
        return new(new int[][] { new[] { -2, -1, 1, 2 }, new[] { -2, -1, 1, 2 } }, 8, new[] { 2, 2, 2, 2, 2 });
    }

    [TestMethod]
    [DynamicData(nameof(CombinationTests))]
    public void FourSum(int[][] expected, int target, int[] nums)
    {
        var t = new Stopwatch();
        Console.WriteLine($"run... ");
        t.Start();
        var result = FourSumService.FourSum(nums, target);
        t.Stop();
        Console.WriteLine($"ElapsedMilliseconds = {t.ElapsedMilliseconds}");
        Console.WriteLine($"expected = {expected}, result = {result}");
        Assert.AreEqual(expected, result);
    }
}