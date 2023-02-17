namespace Leetcode.Services;

public class ThreeSumService
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        var h = new HashSet<(int, int, int)>();
        if (nums.Count(x => x == 0) >= 3)
        {
            h.Add((0, 0, 0));
        }

        if (nums.Count(x => x == 0) > 1)
        {
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
        for (int i = 0; i < nums.Length; i++)
        {
            list.Add((nums[i], i));
        }
        var dict1 = list.GroupBy(x => x.Item1).ToDictionary(x => x.Key, x => x.Select(x => x.Item2).ToArray());

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i; j < nums.Length; j++)
            {
                if (i != j && dict1.TryGetValue(-nums[i] - nums[j], out int[] indexes))
                {
                    if (indexes.Any(idx => idx == i || idx == j))
                        continue;

                    var r = new[] { -nums[i] - nums[j], nums[i], nums[j] };
                    Array.Sort(r);
                    h.Add((r[0], r[1], r[2]));
                }
            }
        }

        var result = (IList<IList<int>>)h.Select(x => (IList<int>)new List<int> { x.Item1, x.Item2, x.Item3 }).ToList();
        return result;
    }

    public static IList<IList<int>> ThreeSumWithoutOptimizeWay(int[] nums)
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

        result.AddRange(FindSumsWithoutOptimizeWay(nums.Count(x => x <= 0), numsLength, nums));
        result.AddRange(FindSumsWithoutOptimizeWay(nums.Count(x => x > 0), numsLength, nums.Reverse().ToArray()));

        Console.WriteLine($"count " + result.Count);

        return result;
    }

    private static IList<List<int>> FindSumsWithoutOptimizeWay(int negIdx, int numsLength, int[] nums)
    {
        var subResult = new List<List<int>>();
        long arr = 0;

        var d0 = new HashSet<int>();
        var d1 = new HashSet<int>();

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
                        if (d1.Add(hc))
                        {
                            subResult.Add(new List<int> { nums[i], nums[j], nums[k] });
                        }
                    }
                    arr++;
                }
            }
        }
        Console.WriteLine(arr + "- самый внутренний дубликат, что надо делать - минимальным");

        return subResult;
    }
}
