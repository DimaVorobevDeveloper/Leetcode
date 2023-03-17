using Leetcode.Services.Models;

namespace Leetcode.Services;
public class ValidParenthesesService
{
    /*Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
      determine if the input string is valid.
      An input string is valid if:
      Open brackets must be closed by the same type of brackets.
      Open brackets must be closed in the correct order.
      Every close bracket has a corresponding open bracket of the same type. */
    public static bool IsValid(string s)
    {
        Stack<char> st = new();
        foreach (var ch in s)
        {
            if (CommonConstants.CharDict.TryGetValue(ch, out var charClose))
            {
                st.Push(ch);
                continue;
            }

            if (st.Count == 0)
            {
                return false;
            }

            var last = st.Pop();
            if (CommonConstants.CharDict[last] != ch)
            {
                return false;
            }
        }

        return st.Count == 0;
    }
}

