namespace Leetcode.Services;

/// <summary>
/// https://leetcode.com/problems/trapping-rain-water/
/// Улавливание дождевой воды
/// </summary>
public static class TrapService
{
    /// <summary>
    /// [0,1,0,2,1,0,1,3,2,1,2,1] -> 6
    /// [4,2,0,3,2,5] -> 9
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public static int Trap(int[] height)
    {
        var currentMaxValue = 0;
        var isCounting = false;
        var prevHeight = 0;
        var currentHeigts = new List<int>();
        var volumes = new List<int>();

        foreach (var heightItem in height)
        {
            // если встретился 0 и сейчас сбит флаг подсчета
            if (heightItem == 0 && !isCounting)
            {
                continue;
            }

            currentHeigts.Add(heightItem);

            if (currentMaxValue > heightItem && prevHeight < heightItem)
            {
                volumes.Add(CalculateVolume());
                isCounting = false;
                currentMaxValue = heightItem; 
                continue;
            }

            if (currentMaxValue < heightItem)
            {
                currentMaxValue = heightItem;
            }

            isCounting = true;
            prevHeight = heightItem;
        }

        return 0;
    }

    private static int CalculateVolume()
    {
        // currentHeigts
        return 0;
    }
}

