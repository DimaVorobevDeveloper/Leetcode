using Leetcode.Services;

namespace Leetcode.Tests.Unit;

[TestClass]
public class ArrayComparatorTests
{
    [TestMethod] 
    [DataRow(true, new[] { "supe", "r" }, new[] { "s", "u", "p", "e", "r" })]
    [DataRow(true, new[] { "sup", "er" }, new[] { "su", "pe", "r" })]
    [DataRow(false, new[] { "sup", "er" }, new[] { "su", "pe", "rable" })]
    [DataRow(false, new[] { "nosup", "er" }, new[] { "su", "pe", "r" })]
    public void IsEqualsTest(bool expected, IEnumerable<string> word1, IEnumerable<string> word2)
    {
        var result = ArrayComparator.IsEquals(word1, word2);
        Assert.AreEqual(expected, result);
    }
}
