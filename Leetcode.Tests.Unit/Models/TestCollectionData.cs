using Leetcode.Services.Models;

namespace Leetcode.Tests.Unit.Models
{
    public class TestCollectionData
    {
        public List<IList<int>> Expected { get; set; }

        public ListNode ListNode { get; set; }

        public int Target { get; set; }

        public int[] Nums { get; set; }

        public TestCollectionData(List<IList<int>> expected, int target, int[] nums)
        {
            Expected = expected;
            Target = target;
            Nums = nums;
        }

        public TestCollectionData(int[] expected, int target, ListNode listNode)
        {
            Nums = expected;
            Target = target;
            ListNode = listNode;
        }
    }
}
