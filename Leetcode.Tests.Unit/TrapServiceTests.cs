using Leetcode.Services;

namespace Leetcode.Tests.Unit;

[TestClass]
public class TrapServiceTests
{
    [TestMethod]
    [DataRow(6, new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 })]
    [DataRow(9, new[] { 4, 2, 0, 3, 2, 5 })]
    [DataRow(1, new[] { 4, 2, 3 })]
    [DataRow(7, new[] { 0, 7, 1, 4, 6 })]
    [DataRow(26, new[] { 0, 1, 2, 0, 3, 0, 1, 2, 0, 0, 4, 2, 1, 2, 5, 0, 1, 2, 0, 2 })] // 238 / 322 testcases passed
    [DataRow(1, new[] { 4, 9, 4, 5, 3, 2 })] // 256 / 322 testcases passed
    [DataRow(3, new[] { 9, 6, 8, 8, 5, 6, 3 })] // 308 / 322 testcases passed
    // [DataRow(18, new[] { 3, 3, 8, 6, 8, 9, 0, 6, 5 })]
    [DataRow(22, new[] { 3, 3, 8, 6, 8, 9, 0, 6, 5, 9, 4, 8})]
    public void Trap(int expected, int[] nums)
    {
        // var result = new TrapService().Trap(nums);
        var result = new TrapService().Trap2(nums);
        Assert.AreEqual(expected, result);
    }
}

