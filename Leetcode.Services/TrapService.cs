namespace Leetcode.Services;

/// <summary>
/// https://leetcode.com/problems/trapping-rain-water/
/// Улавливание дождевой воды
/// </summary>
public class TrapService
{
    /// <summary>
    /// [0,1,0,2,1,0,1,3,2,1,2,1] -> 6
    /// [4,2,0,3,2,5] -> 9
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int Trap(int[] height)
    {
        var volume = 0;
        var cicle = 100;
        CalculateVolume(height, ref volume, ref cicle);

        return volume;
    }

    private int CalculateVolume(int[] height, ref int volume, ref int cicle)
    {
        cicle--;
        if (cicle < 0 || height.Length < 3)
        {
            return volume;
        }

        var prevHeight = 0;
        var currentMaxValue = 0;
        int i = 0;
        var isCounting = false;
        var isLeft = true;
        var isFirst = true;
        int currentVolume = 0;
        var currentHeigts = new List<int>();
        var isFirstAlreadyHere = false;
        foreach (var heightItem in height)
        {
            i++;
            // если встретился 0 и сейчас сбит флаг подсчета
            if (heightItem == 0 && !isCounting) //  || prevHeight == heightItem)
            {
                continue;
            }

            // когда идет увеличение, но еще нет подсчета
            if (!isCounting && prevHeight < heightItem)
            {
                continue;
            }

            // если мы еще только хотим считать,
            // но уже понимаем, что текущее значение меньше предыдущего
            if (isCounting && !currentHeigts.Any() && prevHeight < heightItem)
            {
                isCounting = false;
                isFirst = true;
                currentVolume = 0;
                continue;
            }

            // если мы имеем дело с левой границей емкости
            if ((!isFirst && currentMaxValue > heightItem) || prevHeight > heightItem)
            {
                if (i != height.Length)
                    currentVolume += currentMaxValue - heightItem;

                currentHeigts.Add(heightItem);
            }

            // если мы имеем дело с левой границей емкости и она равна следующему значению, то можно ее убрать
            if (!isFirst && currentHeigts.Count == 0 && prevHeight == heightItem)
            {
                continue;
            }

            // в случае если правая сторона больше или равна левой (левая как бы считается максимальной)
            // и проверяем чтобы текущая точно была больше предыдущей
            if (isCounting && currentMaxValue <= heightItem && prevHeight < heightItem)
            {
                volume += currentVolume;
                currentVolume = 0;
                isCounting = false;
                isFirst = true;
                currentMaxValue = heightItem;
                prevHeight = currentMaxValue;
                currentHeigts = new List<int>()
                {
                    heightItem
                };
                isFirstAlreadyHere = true;
                continue;
            }

            if (currentMaxValue < heightItem)
            {
                currentMaxValue = heightItem;
            }

            // если счетчик не включен еще, то получается, что уже первый прошел
            if (!isCounting && isFirst)
            {
                isFirst = false;
            }

            isCounting = true;
            prevHeight = heightItem;

            // если мы на последнем шаге входного массива
            // и левая граница больше текущей, то 
            // нужен пересчет или заново запустить CalculateVolume()
            // с новыми параметрами
            if (i == height.Length && currentMaxValue > heightItem)
            {
                if (currentMaxValue != heightItem && !isFirstAlreadyHere)
                {
                    currentHeigts.Insert(0, heightItem);
                    isFirstAlreadyHere = false;
                }

                if (currentHeigts.Count < 3)
                {
                    isLeft = false;
                    break;
                }

                isLeft = true;
                var a = currentHeigts[0];
                var b = currentHeigts[^1];

                if (a > b)
                    currentHeigts[0] = a - 1;

                break;
            }
        }

        if (isLeft)
        {
            return CalculateVolume(currentHeigts.ToArray(), ref volume, ref cicle);
        }

        return volume;
    }
}

