namespace Leetcode.Services;

public class ClosestSumService
{
    public static int Get(int[] nums, int target)
    {
        var minValue = Math.Abs(nums[0] + nums[1] + nums[2] - target);
        var sign = Math.Sign(nums[0] + nums[1] + nums[2] - target);

        if (nums.Length == 3)
        {
            return nums.Sum();
        }

        if (nums.Count(x => x == 0) >= 3)
        {
            minValue = Math.Abs(target);
            sign = -1;
        }

        nums = nums.OrderByDescending(x => x).ToArray();

        var ij = 0;
        var hMore = new HashSet<int>();
        var hLess = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    ij = nums[i] + nums[j] + nums[k] - target;
                    if (ij > 0)
                        hMore.Add(ij);
                    else hLess.Add(-ij);
                }
            }
        }

        var minMore = hMore.Any() ? hMore.Min() : int.MaxValue;
        var minLess = hLess.Any() ? hLess.Min() : int.MaxValue;

        minValue = new[] { minMore, minLess }.Min();
        sign = minMore < minLess ? 1 : -1;

        var result = target + sign * minValue;

        return result;
    }
}
