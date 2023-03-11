using Leetcode.Services;
using Leetcode.Services.Models;
using Leetcode.Tests.Unit.Models;

namespace Leetcode.Tests.Unit;

[TestClass]
public class RemoveNthFromEndTests
{
    /* Examples
       Input: head = [1,2,3,4,5], n = 2
       Output: [1,2,3,5]
       
       Input: head = [1], n = 1
       Output: []
       
       Input: head = [1,2], n = 1
       Output: [1] */
    [DataTestMethod]
    [DynamicData(nameof(RemoveNthFromEndDynamicData), DynamicDataSourceType.Method)]
    public void RemoveNthFromEnd(RemoveNthFromEndTestData td) // int[] expected, int n, ListNode head)
    {
        var result = RemoveNthFromEndService.Do(td.ListNode, td.N);
        CollectionAssert.AreEqual(td.Expected, result);
    }

    public static IEnumerable<RemoveNthFromEndTestData[]> RemoveNthFromEndDynamicData()
    {
        yield return new[] { new RemoveNthFromEndTestData(Array.Empty<int>(), 1, new ListNode(1, null)) };
        yield return new[] { new RemoveNthFromEndTestData(new[] { 1 }, 1, new ListNode(1, new ListNode(2, null))) };
        yield return new[] { new RemoveNthFromEndTestData(new[] { 1, 2, 3, 5 }, 2, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))))) };
    }
}