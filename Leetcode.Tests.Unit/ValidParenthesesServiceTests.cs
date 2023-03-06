using Leetcode.Services;

namespace Leetcode.Tests.Unit;

[TestClass]
public class ValidParenthesesServiceTests
{
    [TestMethod]
    [DataRow(true, "()")]
    [DataRow(true, "()[]{}")]
    [DataRow(false, "(]")]
    [DataRow(true, "{[]}")]
    [DataRow(false, "]")]
    public void ValidParentheses(bool expected, string input)
    {
        var result = ValidParenthesesService.IsValid(input);

        Assert.AreEqual(expected, result);
    }
}