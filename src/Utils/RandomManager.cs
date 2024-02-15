using System;

namespace SpaceInvadersRetro.Utils;

public static class RandomManager
{
    private static readonly Random random = new();

    public static double GetRandomTime()
    {
        return random.Next(3, 6) * 10 / 2; // 15s, 20s or 25s
    }

    public static int GetRandomPoints()
    {
        return random.Next(1, 4) * 100 / 2; // 50p, 100p or 150p
    }
}
