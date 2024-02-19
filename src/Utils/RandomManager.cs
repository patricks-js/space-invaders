using System;

namespace SpaceInvadersRetro.Utils;

public static class RandomManager
{
    private static readonly Random random = new();

    public static Random Random => random;

    public static double GetRandomTime()
    {
        var rTime = random.Next(1, 4);

        if (rTime == 1)
            return 40;
        if (rTime == 2)
            return 90;
        return 120;
    }

    public static int GetRandomPoints()
    {
        return random.Next(1, 4) * 100 / 2; // 50p, 100p or 150p
    }
}
