using BenchmarkDotNet.Disassemblers;
using Iced.Intel;
using Leetcode.Services.Models;
using System.Collections.Generic;

namespace Leetcode.Services;

public class GenerateParenthesisService
{
    /*
     *Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

     Example 1:
     Input: n = 3
     Output: ["((()))","(()())","(())()","()(())","()()()"]

     Example 2:
     Input: n = 1
     Output: ["()"]
     *
     */
    public const string a = "(";
    public const string b = ")";

    public static IList<string> Do(int n)
    {
        var t = new List<string>();
        var arr = new string[n];

        var g = n;
        while (g > 0)
        {
            OpenClose(ref arr, g, 2 * n, t);
            g--;
        }

        return new List<string>();
    }

    public static void OpenClose(ref string[] arr, int n, int max, List<string> t)
    {
        var g = n;

        while (g > 0)
        {
            OpenA(arr, g, max);
            g--;
        }

        g = n;
        while (g > 0)
        {
            CloseB(arr, g, max);
            g--;
        }

        t.AddRange(arr.Where(x => x.Length == max));
        var t1 = arr.ToList();
        t1.RemoveAll(x => x.Length == max);
        arr = t1.ToArray();
    }

    public static void OpenA(string[] arr, int n, int max)
    {
        for (var i = 0; i < n; i++)
        {
            if (i >= arr.Length)
            {
                return;
            }

            if (arr[i] == null || arr[i].Length != max - 1)
            {
                arr[i] += a;
            }
        }
    }

    public static void CloseB(string[] arr, int n, int max)
    {
        for (var i = 0; i < n; i++)
        {
            if (i >= arr.Length)
            {
                return;
            }

            if (arr[i] == null || arr[i].Length != max)
                arr[i] += b;
        }
    }
}