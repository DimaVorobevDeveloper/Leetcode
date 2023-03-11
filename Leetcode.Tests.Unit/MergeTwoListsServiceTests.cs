using Leetcode.Services;
using Leetcode.Services.Models;
using Leetcode.Tests.Unit.Models;

namespace Leetcode.Tests.Unit;

[TestClass]
public class MergeTwoListsServiceTests
{
    /* Example 1:
    Input: list1 = [1,2,4], list2 = [1,3,4]
    Output: [1,1,2,3,4,4]
    
    Example 2:
    Input: list1 = [], list2 = []
    Output: []
    
    Example 3:
    Input: list1 = [], list2 = [0]
    Output: [0]    */
    [DataTestMethod]
    [DynamicData(nameof(MergeTwoListsDynamicData), DynamicDataSourceType.Method)]
    public void RemoveNthFromEnd(MergeTwoListsServiceTestData td)
    {
        var result = MergeTwoListsService.MergeTwoLists(td.ListNode1, td.ListNode2);
        CollectionAssert.AreEqual(td.Expected, result);
    }

    public static IEnumerable<MergeTwoListsServiceTestData[]> MergeTwoListsDynamicData()
    {
        yield return new[] { new MergeTwoListsServiceTestData(Array.Empty<int>(), null, null) };
        yield return new[] { new MergeTwoListsServiceTestData(new[] { 0 }, null, new ListNode(0, null)) };
        yield return new[] { new MergeTwoListsServiceTestData(new[] { 1, 1, 2, 3, 4, 4 },
            new ListNode(1, new ListNode(2, new ListNode(4, null))),
            new ListNode(1, new ListNode(3, new ListNode(4,null)))
            ) };
    }
}
