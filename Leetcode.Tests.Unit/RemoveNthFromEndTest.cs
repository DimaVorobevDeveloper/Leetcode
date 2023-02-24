using Leetcode.Services;

namespace Leetcode.Tests.Unit
{
    [TestClass]
    public class RemoveNthFromEndTest
    {
        /* Examples
           Input: head = [1,2,3,4,5], n = 2
           Output: [1,2,3,5]
           
           Input: head = [1], n = 1
           Output: []
           
           Input: head = [1,2], n = 1
           Output: [1] */
        [TestMethod]
        [DataRow(new[] { 1, 2, 3, 5 }, 2, new[] { 1, 2, 3, 4, 5 })]
        [DataRow(new int[] { }, 1, new[] { 1 })]
        [DataRow(new[] { 1 }, 1, new[] { 1, 2 })]
        public void RemoveNthFromEnd(int[] expected, int n, int[] head)
        {
            var result = RemoveNthFromEndService.Get(null, n);

            // CollectionAssert.AreEqual(expected, result);
        }
    }
}
