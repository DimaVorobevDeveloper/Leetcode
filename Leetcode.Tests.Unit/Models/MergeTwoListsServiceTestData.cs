using Leetcode.Services.Models;

namespace Leetcode.Tests.Unit.Models;

public class MergeTwoListsServiceTestData
{
    public ListNode ListNode1 { get; set; }

    public ListNode ListNode2 { get; set; }

    public int[] Expected { get; set; }

    public MergeTwoListsServiceTestData(int[] expected, ListNode listNode1, ListNode listNode2)
    {
        Expected = expected;
        ListNode1 = listNode1;
        ListNode2 = listNode2;
    }
}