using Leetcode.Services;

namespace Leetcode.Tests.Unit;

[TestClass]
public class GenerateParenthesisServiceTests
{
    /*
     Example 1:
     Input: n = 3
     Output: ["((()))","(()())","(())()","()(())","()()()"]
     
     Example 2:
     Input: n = 1
     Output: ["()"]
    */
    [TestMethod]
    [DataRow(new[] { "((()))", "(()())", "(())()", "()(())", "()()()" }, 4)]
    [DataRow(new[] { "((()))", "(()())", "(())()", "()(())", "()()()" }, 3)]
    [DataRow(new[] { "()" }, 1)]
    public void ValidParentheses(string[] expected, int n)
    {
        var result = GenerateParenthesisService.Do(n);

        CollectionAssert.AreEqual(expected, result.ToArray());
    }
}
