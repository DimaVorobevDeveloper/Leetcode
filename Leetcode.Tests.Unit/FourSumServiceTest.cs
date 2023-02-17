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

    [DataTestMethod]
    [DynamicData(nameof(CombinationTests), DynamicDataSourceType.Method)]
    public void FourSum(TestData testData)
    {
        var result = FourSumService.GetUniqueQuadruplets(testData.nums, testData.target);

        Assert.AreEqual(testData.expected, result);
    }

    public class TestData
    {
        public int[][] expected { get; set; }
        public int target { get; set; }
        public int[] nums { get; set; }

        public TestData(int[][] expected, int target, int[] nums)
        {
            this.expected = expected;
            this.target = target;
            this.nums = nums;
        }
    }

    public static IEnumerable<TestData[]> CombinationTests()
    {
        yield return new TestData[] { new TestData(new int[][] { new[] { -2, -1, 1, 2 }, new[] { -2, -1, 1, 2 } }, 8, new[] { 2, 2, 2, 2, 2 }) };
    }
}