using Leetcode.Services;

namespace Leetcode.Tests.Unit;

[TestClass]
public class TrapServiceTests
{
    [TestMethod]
    // [DataRow(6, new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 })]
    [DataRow(9, new[] { 4, 2, 0, 3, 2, 5 })]
    public void Trap(int expected, int[] nums)
    {
        var result = TrapService.Trap(nums);

        Assert.AreEqual(expected, result);
    }
}

