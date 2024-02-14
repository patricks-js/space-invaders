using System.Collections.Generic;

namespace SpaceInvadersRetro.Utils;

public readonly struct MARGIN
{
    public static readonly Dictionary<string, int> X = new() { { "min", 20 }, { "max", 96 } };
    public static readonly Dictionary<string, int> Y = new() { { "top", 200 }, { "bottom", 82 } };
}

public readonly struct SCREEN
{
    public static readonly int WIDTH = 720;
    public static readonly int HEIGHT = 896;
}
