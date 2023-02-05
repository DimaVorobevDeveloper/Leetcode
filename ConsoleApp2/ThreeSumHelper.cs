using System.Text;

namespace Leetcode.Services;

public class ThreeSumHelper
{
    //var nums = new[] { -1, 0, 1, 2, -1, -4 };
    //var result1 = ThreeSumHelper.ThreeSumD(nums);

    //nums = new[] { 1, 1, -2 };
    //var result2 = ThreeSumHelper.ThreeSumD(nums);

    //nums = new[] { -1, 0, 1 };
    //var result3 = ThreeSumHelper.ThreeSumD(nums);

    //nums = new[] { 0, -4, -1, -4, -2, -3, 2 };
    //var result4 = ThreeSumHelper.ThreeSumD(nums);

    //nums = new[] { -1, 0, 1, 0 };
    //var result5 = ThreeSumHelper.ThreeSumD(nums);

    //nums = new[] { -13, 5, 13, 12, -2, -11, -1, 12, -3, 0, -3, -7, -7, -5, -3, -15, -2, 14, 14, 13, 6, -11, -11, 5, -15, -14, 5, -5, -2, 0, 3, -8, -10, -7, 11, -5, -10, -5, -7, -6, 2, 5, 3, 2, 7, 7, 3, -10, -2, 2, -12, -11, -1, 14, 10, -9, -15, -8, -7, -9, 7, 3, -2, 5, 11, -13, -15, 8, -3, -7, -12, 7, 5, -2, -6, -3, -10, 4, 2, -5, 14, -3, -1, -10, -3, -14, -4, -3, -7, -4, 3, 8, 14, 9, -2, 10, 11, -10, -4, -15, -9, -1, -1, 3, 4, 1, 8, 1 };
    //var result6 = ThreeSumHelper.ThreeSumD(nums);

    /// <summary>
    /// Возьми вход, запиши его в 2 переменные - в словарь, где ключ - число, значение количество раз сколько встречается, и в массив
    //Отсортируй массив.
    //    Иди по массиву по всем элементом
    //    Во внутреннем цикле иди по массиву от текущего элемента внешнего массива
    //Проверяй 0 - mass[i] - mass[j] есть в словаре?
    //    Если есть - создавай hashset из 3 элементов, а не лист, и записывай в хешсет троек.
    //    Будет сложность n* n/2
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        Console.WriteLine($"input data count - {nums.Length}");
        var distinctNums = nums.Distinct().ToArray();
        // Возьми вход, запиши его в 2 переменные - в словарь, где ключ -число, значение количество раз сколько встречается,
        var dict = distinctNums.ToDictionary(x => x, x => nums.Count(n => n == x));
        // и в массив ??? зачем?

        var h = new HashSet<(int, int, int)>();
        for (int i = 0; i < nums.Length; i++) // Иди по массиву по всем элементом
        {
            for (int j = i; j < nums.Length; j++) // Во внутреннем цикле иди по массиву от текущего элемента внешнего массива
            {
                // Проверяй 0 - mass[i] - mass[j] есть в словаре ?
                if (i != j && dict.TryGetValue(-nums[i] - nums[j], out int k))
                {
                    var r = new[] { -nums[i] - nums[j], nums[i], nums[j] };
                    Array.Sort(r);
                    // Если есть - создавай hashset из 3 элементов, а не лист, и записывай в хешсет троек.
                    h.Add((r[0], r[1], r[2]));
                }
                // Если есть -создавай hashset из 3 элементов, а не лист, и записывай в хешсет троек.
            }
        }

        var result = (IList<IList<int>>)h.Select(x => (IList<int>)new List<int> { x.Item1, x.Item2, x.Item3 }).ToList();

        Console.WriteLine($"--------------" + result.Count);

        return result;
    }

    public static IList<IList<int>> ThreeSumD(int[] nums)
    {
        Console.WriteLine($"input data count - {nums.Length}");

        var h = new HashSet<(int, int, int)>();
        if (nums.Count(x => x == 0) >= 3)
        {
            h.Add((0, 0, 0));
        }

        if (nums.Count(x => x == 0) > 1)
        {
            // remove 0 > 1 count
            var newNums = nums.ToList();
            newNums.RemoveAll(x => x == 0);
            newNums.Add(0);
            nums = newNums.ToArray();
        }

        if (nums.All(x => x > 0) || nums.All(x => x < 0))
        {
            return new List<IList<int>>();
        }

        var list = new List<(int, int)>();
        for (int i = 0; i < nums.Length; i++) // Иди по массиву по всем элементом
        {
            list.Add((nums[i], i));
        }
        var dict1 = list.GroupBy(x => x.Item1).ToDictionary(x => x.Key, x => x.Select(x => x.Item2).ToArray());

        for (int i = 0; i < nums.Length; i++) // Иди по массиву по всем элементом
        {
            for (int j = i; j < nums.Length; j++) // Во внутреннем цикле иди по массиву от текущего элемента внешнего массива
            {
                // Проверяй 0 - mass[i] - mass[j] есть в словаре ?
                if (i != j && dict1.TryGetValue(-nums[i] - nums[j], out int[] indexes))
                {
                    if (indexes.Any(idx => idx == i || idx == j))
                        continue;

                    var r = new[] { -nums[i] - nums[j], nums[i], nums[j] };
                    Array.Sort(r);
                    // Если есть - создавай hashset из 3 элементов, а не лист, и записывай в хешсет троек.
                    h.Add((r[0], r[1], r[2]));
                }
            }
        }

        var result = (IList<IList<int>>)h.Select(x => (IList<int>)new List<int> { x.Item1, x.Item2, x.Item3 }).ToList();

        Console.WriteLine($"--------------count of result: " + result.Count);

        return result;
    }

    public static IList<IList<int>> ThreeSum3(int[] nums)
    {
        Console.WriteLine($"input data count - {nums.Length}");
        var result = new List<IList<int>>();

        if (nums.Count(x => x == 0) >= 3)
        {
            result.Add(new List<int> { 0, 0, 0 });
        }
        if (nums.All(x => x > 0) || nums.All(x => x < 0))
        {
            return result;
        }
        Array.Sort(nums);
        var numsLength = nums.Length;

        result.AddRange(FindSums3(nums.Count(x => x <= 0), numsLength, nums));
        result.AddRange(FindSums3(nums.Count(x => x > 0), numsLength, nums.Reverse().ToArray()));

        Console.WriteLine($"--------------" + result.Count);

        return result;
    }

    private static IList<List<int>> FindSums3(int negIdx, int numsLength, int[] nums)
    {
        var subResult = new List<List<int>>();
        long arr = 0;

        var d0 = new HashSet<int>();
        var d1 = new HashSet<int>();
        var d2 = new HashSet<int>();

        for (int i = 0; i < negIdx; i++)
        {
            if (!d0.Add(nums[i]))
            {
                continue;
            }

            for (int j = negIdx; j < numsLength; j++)
            {
                for (int k = negIdx; k < numsLength; k++)
                {
                    if (j != k && nums[j] + nums[k] == -nums[i])
                    {
                        var hc = nums[j] > nums[k] ? $"{nums[k]}{nums[j]}".GetHashCode() : $"{nums[j]}{nums[k]}".GetHashCode();
                        if (d2.Add(hc))
                        {
                            // Console.WriteLine($"{String.Join(" ", new[] { nums[i], nums[j], nums[k] })}");
                            subResult.Add(new List<int> { nums[i], nums[j], nums[k] });
                        }
                    }
                    // Console.Write(".");
                    arr++;
                }
            }
        }
        Console.WriteLine(arr + "- самый внутренний дубликат, что надо делать - минимальным");
        //Console.WriteLine(dublicate2 + "- пресек на первой итерации повторение");
        //Console.WriteLine(d.Count + "- сколько идет - всего итераций глобальных");

        return subResult;
    }

    private static IList<int[]> FindSums4(int negIdx, int numsLength, int[] nums)
    {
        var subResult = new List<int[]>();
        var arr = new int[3];
        // var arr2 = new int[2];
        //int dublicate = 0;
        //int dublicate2 = 0;

        // var d = new int[negIdx];
        int dIndex = 0;
        var d1 = new HashSet<int>();
        var d2 = new HashSet<int>();

        for (int i = 0; i < negIdx; i++)
        {
            //if (d.Contains(nums[i]))
            //{
            //    //dublicate2++;
            //    continue;
            //}
            //d[dIndex++] = nums[i];

            for (int j = negIdx; j < numsLength; j++)
            {
                for (int k = negIdx; k < numsLength; k++)
                {
                    if (j != k && nums[j] + nums[k] == -nums[i])
                    {
                        // arr2 = nums[j] > nums[k] ? new[] { nums[k], nums[j] } : new[] { nums[j], nums[k] };
                        // Array.Sort(arr2);

                        var hc = nums[j] > nums[k] ? $"{nums[k]}{nums[j]}".GetHashCode() : $"{nums[j]}{nums[k]}".GetHashCode();
                        if (d2.Add(hc))
                        {
                            // Console.WriteLine($"{String.Join(" ", new[] { nums[i], nums[j], nums[k] })}");
                            subResult.Add(arr);
                        }

                        //var hc = nums[j] > nums[k] ? $"{nums[k]}{nums[j]}".GetHashCode() : $"{nums[j]}{nums[k]}".GetHashCode();
                        //if (!d2.AsParallel().Any(x => x == hc))
                        //{
                        //    // Console.WriteLine($"{String.Join(" ", new[] { nums[i], nums[j], nums[k] })}");
                        //    subResult.Add(arr);
                        //    d2.Add(hc);
                        //}

                    }
                }
            }
        }
        //Console.WriteLine(dublicate + "- самый внутренний дубликат, что надо делать - минимальным");
        //Console.WriteLine(dublicate2 + "- пресек на первой итерации повторение");
        //Console.WriteLine(d.Count + "- сколько идет - всего итераций глобальных");

        return subResult;
    }

    public static IList<IList<int>> ThreeSum2(int[] nums)
    {
        Console.WriteLine($"input data {String.Join(" ", nums)}");

        var result = new List<IList<int>>();
        var subResultTest = new List<IList<int>>();

        if (nums.Count(x => x == 0) >= 3)
        {
            result.Add(new List<int> { 0, 0, 0 });
        }

        if (nums.All(x => x > 0) || nums.All(x => x < 0))
        {
            return result;
        }

        Array.Sort(nums);
        var middleIdx = nums.Count(x => x <= 0);
        var numsLength = nums.Length;

        subResultTest.AddRange(FindSums2(middleIdx, numsLength, nums, result));

        nums = nums.Reverse().ToArray();
        middleIdx = nums.Count(x => x > 0);

        subResultTest.AddRange(FindSums2(middleIdx, numsLength, nums, result));

        Console.WriteLine($"--------------");

        return result;
    }

    private static IList<IList<int>> FindSums2(int negIdx, int numsLength, int[] nums, List<IList<int>> result)
    {
        var arr = new List<int>();

        for (int i = 0; i < negIdx; i++)
        {
            for (int j = negIdx; j < numsLength; j++)
            {
                for (int k = negIdx; k < numsLength; k++)
                {
                    if (j != k && nums[i] + nums[j] + nums[k] == 0)
                    {
                        arr = new List<int> { nums[i], nums[j], nums[k] };
                        arr.Sort();
                        if (!result.Any(x => Enumerable.SequenceEqual(x, arr)))
                        {
                            Console.WriteLine($"{String.Join(" ", new[] { nums[i], nums[j], nums[k] })}");
                            result.Add(arr);
                        }
                    }
                }
            }
        }

        return result;
    }


    // Input: nums = [-1,0,1,2,-1,-4]
    // Output: [[-1,-1,2],[-1,0,1]]
    // Console.WriteLine($"{String.Join(" ", arr)} {arr.Sum()}");
    public static IList<IList<int>> ThreeSum1(int[] nums)
    {
        Console.WriteLine($"input data {String.Join(" ", nums)}");

        var result = new List<IList<int>>();

        if (nums.Count(x => x == 0) >= 3)
        {
            result.Add(new List<int>() { 0, 0, 0 });
        }

        if (nums.All(x => x > 0))
        {
            return result;
        }

        var arr = new List<int>();
        int a, b, c = 0;
        var more = nums.Where(x => x > 0).ToList();
        var less = nums.Where(x => x <= 0).ToList();
        var isAddM1 = false;

        foreach (var m1 in more)
        {
            var restMore = more.ToList();
            if (more.Count > 1)
            {
                arr.Add(m1);
                restMore.Remove(m1);
            }

            isAddM1 = more.Count > 1;

            var t = new StringBuilder();
            foreach (var m2 in restMore)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (i == 0)
                    {
                        arr.Add(m2);
                    }

                    foreach (var l in less)
                    {
                        var rest = less.ToList();
                        rest.Remove(l);

                        if (arr.Count < 3)
                        {
                            arr.Add(l);
                        }

                        if (CheckAndAddToResult(result, arr)) continue;

                        foreach (var r in rest)
                        {
                            if (arr.Count < 3)
                            {
                                arr.Add(r);
                            }

                            CheckAndAddToResult(result, arr);

                            if (arr.Count == 3)
                            {
                                arr.Clear();
                                if (i == 0)
                                {
                                    arr.Add(m2);
                                }

                                if (isAddM1)
                                {
                                    arr.Add(m1);
                                }

                                arr.Add(l);
                            }
                        }
                    }
                }
                arr.Clear();
            }
        }

        Console.WriteLine($"--------------");

        return result;
    }

    public static IList<IList<int>> ThreeSum5(int[] nums)
    {
        // Console.WriteLine($"input data {String.Join(" ", nums)}");
        var result = new List<IList<int>>();
        if (nums.Count(x => x == 0) >= 3)
        {
            result.Add(new List<int> { 0, 0, 0 });
        }
        if (nums.All(x => x > 0) || nums.All(x => x < 0))
        {
            return result;
        }

        Array.Sort(nums);
        var numsLength = nums.Length;

        var result1 = FindSums5(nums.Count(x => x <= 0), numsLength, nums);
        var result2 = FindSums5(nums.Count(x => x > 0), numsLength, nums.Reverse().ToArray());

        Task.WaitAll(result1, result2);
        result.AddRange(result1.Result);
        result.AddRange(result2.Result);

        Console.WriteLine($"--------------");

        return result;
    }

    private static async Task<IList<IList<int>>> FindSums5(int negIdx, int numsLength, int[] nums)
    {
        await Task.CompletedTask;

        var subResult = new List<IList<int>>();
        var arr = new int[3];

        for (int i = 0; i < negIdx; i++)
        {
            for (int j = negIdx; j < numsLength; j++)
            {
                for (int k = negIdx; k < numsLength; k++)
                {
                    if (j != k && nums[i] + nums[j] + nums[k] == 0)
                    {
                        arr = new[] { nums[i], nums[j], nums[k] };
                        Array.Sort(arr);
                        if (!subResult.Any(x => x[0] == arr[0] && x[1] == arr[1] && x[2] == arr[2]))
                        {
                            // Console.WriteLine($"{String.Join(" ", new[] { nums[i], nums[j], nums[k] })}");
                            subResult.Add(arr);
                        }
                    }
                }
            }
        }

        return subResult;
    }

    private static bool CheckAndAddToResult(IList<IList<int>> result, List<int> arr)
    {
        arr.Sort();

        if (arr.All(x => x == 0)) return false;

        if (arr.Count == 3 && !result.Any(x => Enumerable.SequenceEqual(x, arr)) && arr.Sum() == 0)
        {
            var added = new int[3];
            arr.CopyTo(added);
            result.Add(added);
            Console.WriteLine($"{String.Join(" ", arr)} {arr.Sum()}");
            return true;
        }

        return false;
    }
}
