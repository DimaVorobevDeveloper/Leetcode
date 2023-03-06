using Leetcode.Services.Models;

namespace Leetcode.Tests.Unit.Models;

public class RemoveNthFromEndTestData
{
    public ListNode ListNode { get; set; }

    public int N { get; set; }

    public int[] Expected { get; set; }

    public RemoveNthFromEndTestData(int[] expected, int n, ListNode listNode)
    {
        Expected = expected;
        N = n;
        ListNode = listNode;
    }
}
